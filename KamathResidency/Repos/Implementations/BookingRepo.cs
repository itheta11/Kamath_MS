using System;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using KamathResidency.DTO;
using KamathResidency.Infrastructure;
using KamathResidency.Repos.Interfaces;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KamathResidency.Repos.Implementations;

public class BookingRepo : IBookingRepo
{

    private readonly KamahResidencyContext _context;
    public BookingRepo(KamahResidencyContext context)
    {
        _context = context;
    }
    public async Task<List<BookingsDto>> GetAllRoomBookings(DateTime? fromDate, DateTime? toDate)
    {
        var query = _context.Bookings
            .Include(b => b.User)
            .Include(b => b.Rooms)
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
            Id = new Guid(b.Id),
            CreatedAt = b.CreatedAt,
            ModifiedAt = b.ModifiedAt,
            CheckIn = b.CheckIn,
            CheckOut = b.CheckOut,
            TotalBill = b.TotalBill,
            AdvanceAmount = b.AdvanceAmount,
            User = new UsersDto
            {
                Id = new Guid(b.User.Id),
                Name = b.User.Name,
                Address = b.User.Address,
                PhoneNumber = b.User.PhoneNumber,
                IdProof = b.User.IdProof
            },
            Rooms = b.Rooms.Select(r => new RoomDto
            {
                Id = r.Id,
                Floor = r.Floor,
                RoomType = r.RoomType,
                IsAc = r.IsAc
            }).ToList()
        }).ToList();


        return bookingDetails;
    }

    public async Task<Booking> AddBooking(CreateBookingsDto details)
    {
        var overlappingBookings = await _context.Bookings
    .Include(b => b.Rooms) // Include the associated rooms
    .Where(b =>
        b.CheckIn < details.CheckOut && b.CheckOut > details.CheckIn &&
        b.Rooms.Any(r => details.RoomIds.Contains(r.Id)))
    .ToListAsync();

        if (overlappingBookings.Any())
        {
            throw new Exception("One or more rooms are already booked during the given date range.");
        }


        Booking bookingData = new Booking();
        bookingData.Id = Guid.NewGuid().ToString();
        bookingData.UserId = details.UserId;
        bookingData.CheckIn = details.CheckIn;
        bookingData.CheckOut = details.CheckOut;
        bookingData.TotalBill = details.TotalBill;
        bookingData.AdvanceAmount = details.AdvanceAmount;
        bookingData.Rooms = await _context.Rooms.Where(r => details.RoomIds.Contains(r.Id)).ToListAsync();
        _context.Bookings.Add(bookingData);
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
        return null;
    }
}
