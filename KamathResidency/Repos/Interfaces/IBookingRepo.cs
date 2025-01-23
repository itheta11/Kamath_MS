using System;
using KamathResidency.DTO;
using KamathResidency.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace KamathResidency.Repos.Interfaces;

public interface IBookingRepo
{
    Task<List<RoomBookingsDto>> GetAllRoomBookings(DateTime fromDate, DateTime toDate);
    Task<Booking> AddBooking(BookingsDto details);
    Task<Booking> UpdateBooking(Guid bId, BookingsDto updatedData);
    Task<Booking> GetBookingDetailsById(Guid BId);


}
