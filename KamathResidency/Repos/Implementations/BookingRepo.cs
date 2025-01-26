using System;
using System.ComponentModel.Design;
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
    public BookingRepo(HotelDbContext context)
    {
        _context = context;
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

    public async Task<Booking> AddBooking(CreateBookingsDto details)
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
        return bookingData;
    }

    public async Task<Booking> UpdateBooking(Guid bId, BookingsDto updatedData)
    {
        // var data = await _context.Bookings.Where(b => b.Id == bId).FirstOrDefaultAsync();
        // if (data == null)
        // {
        //     throw new Exception("No booking details found.");
        // }

        // data.RoomNo = updatedData.RoomNo;
        // data.CheckOut = updatedData.CheckOut;
        // data.TotalBill = updatedData.TotalBill;
        // data.AdvanceAmount = updatedData.AdvanceAmount;
        // _context.Bookings.Update(data);
        // _context.SaveChanges();
        return null;

    }

    public async Task<Booking> GetBookingDetailsById(Guid bId)
    {
        var bookigData = await _context.Bookings.Where(b => b.Id == bId).FirstOrDefaultAsync();
        return bookigData;
    }
}
