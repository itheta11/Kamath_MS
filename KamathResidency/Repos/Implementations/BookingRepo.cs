using System;
using System.ComponentModel.Design;
using AutoMapper;
using KamathResidency.DTO;
using KamathResidency.Infrastructure;
using KamathResidency.Repos.Interfaces;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KamathResidency.Repos.Implementations;

public class BookingRepo : IBookingRepo
{

    private readonly HotelDbContext _context;
    private readonly IMapper _mapper;
    public BookingRepo(HotelDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<List<BookingsDto>> GetAllRoomBookings(DateTime? fromDate, DateTime? toDate)
    {
        var query = _context.Bookings
                    .Include(b => b.User)
                    .Include(b => b.BookingRoomAssociations)
                        .ThenInclude(ba => ba.Room)
                    .AsQueryable();

        if (fromDate.HasValue && toDate.HasValue)
        {
            query = query.Where(b =>
                (b.CheckIn >= fromDate && b.CheckIn <= toDate) ||
                (b.CheckOut >= fromDate && b.CheckOut <= toDate) ||
                (b.CheckIn <= fromDate && b.CheckOut >= toDate));
        }

        var bookings = await query.ToListAsync();

        var bookingDetails = bookings.Select(b => new BookingsDto
        {
            Id = b.Id,
            CreatedAt = b.CreatedAt,
            ModifiedAt = b.ModifiedAt,
            CheckIn = b.CheckIn,
            CheckOut = b.CheckOut,
            TotalBill = b.TotalBill,
            AdvanceAmount = b.AdvanceAmount,
            User = new UserDto
            {
                Id = b.User.Id,
                Name = b.User.Name,
                Address = b.User.Address,
                PhoneNumber = b.User.PhoneNumber,
                IdProof = b.User.IdProof
            },
            Rooms = b.BookingRoomAssociations.Select(r => new RoomDto
            {
                Id = r.Room.Id,
                Floor = r.Room.Floor,
                RoomType = r.Room?.RoomType,
                IsAc = r.Room?.IsAc
            }).ToList()
        }).ToList();


        return bookingDetails;
    }

    public async Task<BookingsDto> AddBooking(CreateBookingsDto details)
    {
        var unavailableRooms = await _context.BookingRoomAssociations
        .Include(ba => ba.Booking)
        .Where(ba =>
            details.RoomIds.Contains(ba.RoomId) &&
            (ba.Booking.CheckIn <= details.CheckOut && ba.Booking.CheckOut >= details.CheckIn))
        .Select(ba => ba.RoomId)
        .ToListAsync();

        if (unavailableRooms.Any())
        {
            throw new Exception("Some rooms are not available during the selected dates");
        }
        Booking bookingData = new Booking();
        bookingData.Id = Guid.NewGuid();
        bookingData.UserId = details.UserId;
        bookingData.CheckIn = details.CheckIn;
        bookingData.CheckOut = details.CheckOut;
        bookingData.TotalBill = details.TotalBill;
        bookingData.AdvanceAmount = details.AdvanceAmount;
        bookingData.CreatedAt = DateTime.Now;
        _context.Bookings.Add(bookingData);

        var bookingRoomAssociations = details.RoomIds.Select(roomId => new BookingRoomAssociation
        {
            Id = Guid.NewGuid(),
            BookingId = bookingData.Id,
            RoomId = roomId
        }).ToList();

        _context.BookingRoomAssociations.AddRange(bookingRoomAssociations);
        await _context.SaveChangesAsync();
        var booking = _mapper.Map<BookingsDto>(bookingData);
        return booking;
    }

    public async Task UpdateBooking(Guid bId, CreateBookingsDto updatedData)
    {
        var data = await _context.Bookings
                   .Where(x => x.Id == bId)
                   .Include(b => b.BookingRoomAssociations)
                       .ThenInclude(ba => ba.Room)
                   .FirstOrDefaultAsync();
        if (data == null)
        {
            throw new Exception("No booking details found.");
        }
        data.CheckIn = updatedData.CheckIn;
        data.CheckOut = updatedData.CheckOut;
        data.TotalBill = updatedData.TotalBill;
        data.AdvanceAmount = updatedData.AdvanceAmount;
        _context.Bookings.Update(data);

        var bookingRoomAssociations = updatedData.RoomIds.Select(roomId => new BookingRoomAssociation
        {
            Id = Guid.NewGuid(),
            BookingId = data.Id,
            RoomId = roomId
        }).ToList();

        _context.BookingRoomAssociations.RemoveRange(data.BookingRoomAssociations);
        _context.BookingRoomAssociations.AddRange(bookingRoomAssociations);
        await _context.SaveChangesAsync();
    }

    public async Task<BookingsDto> GetBookingDetailsById(Guid bId)
    {
        var booking = await _context.Bookings
                    .Where(x => x.Id == bId)
                    .Include(b => b.User)
                    .Include(b => b.BookingRoomAssociations)
                        .ThenInclude(ba => ba.Room)
                    .FirstOrDefaultAsync();

        if (booking == null)
        {
            throw new Exception("Booking not found");
        }

        BookingsDto response = new BookingsDto
        {
            Id = booking.Id,
            CreatedAt = booking.CreatedAt,
            ModifiedAt = booking.ModifiedAt,
            CheckIn = booking.CheckIn,
            CheckOut = booking.CheckOut,
            TotalBill = booking.TotalBill,
            AdvanceAmount = booking.AdvanceAmount,
            User = new UserDto
            {
                Id = booking.User.Id,
                Name = booking.User.Name,
                Address = booking.User.Address,
                PhoneNumber = booking.User.PhoneNumber,
                IdProof = booking.User.IdProof
            },
            Rooms = booking.BookingRoomAssociations.Select(r => new RoomDto
            {
                Id = r.Room.Id,
                Floor = r.Room.Floor,
                RoomType = r.Room?.RoomType,
                IsAc = r.Room?.IsAc
            }).ToList()
        };

        return response;
    }

    public async Task PartialBookingUpdate(Guid id, PartialBookingUpdateApi updatedBooking)
    {
        var transaction = _context.Database.BeginTransaction();
        try
        {
            if (updatedBooking.CheckIn != null && updatedBooking.CheckOut != null)
            {

                await _context.Bookings
                .Where(b => b.Id == id)
                .ExecuteUpdateAsync(s =>
                    s.SetProperty(booking => booking.CheckIn, b => updatedBooking.CheckIn)
                    .SetProperty(booking => booking.CheckIn, b => updatedBooking.CheckIn))
                ;
                await _context.SaveChangesAsync();
            }

            /// remove bookings
            if (updatedBooking.DeletedRoomIds != null && updatedBooking.DeletedRoomIds.Count > 0)
            {

                await _context.BookingRoomAssociations.
                Where(ba => ba.BookingId == id && updatedBooking.DeletedRoomIds.Contains(ba.RoomId))
                .ExecuteDeleteAsync();
                await _context.SaveChangesAsync();

            }

            if (updatedBooking.DeletedRoomIds != null && updatedBooking.DeletedRoomIds.Count > 0)
            {
                List<BookingRoomAssociation> newBookingAssos = new List<BookingRoomAssociation>();
                foreach (var roomId in updatedBooking.AddedRoomIds)
                {
                    BookingRoomAssociation bookingRoomAssociation = new BookingRoomAssociation()
                    {
                        Id = Guid.NewGuid(),
                        BookingId = id,
                        RoomId = roomId
                    };
                    newBookingAssos.Add(bookingRoomAssociation);
                }
                await _context.BookingRoomAssociations.AddRangeAsync(newBookingAssos);
                await _context.SaveChangesAsync();
            }

            await transaction.CommitAsync();
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
        }



    }
}
