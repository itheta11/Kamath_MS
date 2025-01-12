using System;
using System.ComponentModel.Design;
using KamathResidency.DTO;
using KamathResidency.Infrastructure;
using KamathResidency.Repos.Interfaces;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;

namespace KamathResidency.Repos.Implementations;

public class BookingRepo : IBookingRepo
{

    private readonly KamathDbContext _context;
    public BookingRepo(KamathDbContext context)
    {
        _context = context;
    }
    public async Task<List<RoomBookingsDto>> GetAllRoomBookings(DateTime fromDate, DateTime toDate)
    {
        var data = await (from r in _context.Rooms
                          join b in _context.Bookings on r.Id equals b.RoomNo
                          where b.CheckIn >= fromDate && b.CheckIn <= toDate
                          select new
                          {
                              RoomId = r.Id,
                              RoomType = r.RoomType,
                              IsAc = r.IsAc,
                              bookingId = b.Id,
                              checkin = b.CheckIn,
                              Checkout = b.CheckOut
                          }).ToListAsync();
        List<RoomBookingsDto> roomBookingList = new List<RoomBookingsDto>();

        foreach (var item in data)
        {
            BookingsDto bookingData = new BookingsDto();
            bookingData.BookingId = item.bookingId;
            bookingData.CheckIn = item.checkin;
            bookingData.CheckOut = item.Checkout;
            var room = roomBookingList.Where(x => x.RoomId == item.RoomId).FirstOrDefault();
            if (room == null)
            {
                RoomBookingsDto roomData = new RoomBookingsDto();
                roomData.RoomId = item.RoomId;
                roomData.RoomType = item.RoomType;
                roomData.IsAc = item.IsAc;
                roomData.Bookings = new List<BookingsDto>();
                roomData.Bookings.Add(bookingData);
                roomBookingList.Add(roomData);
            }
            else
            {
                room.Bookings.Add(bookingData);
            }

        }

        return roomBookingList;
    }
}
