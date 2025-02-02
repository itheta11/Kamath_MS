using System;
using KamathResidency.DTO;
using KamathResidency.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace KamathResidency.Repos.Interfaces;

public interface IBookingRepo
{
    Task<List<BookingsDto>> GetAllRoomBookings(DateTime? fromDate, DateTime? toDate);
    Task<BookingsDto> AddBooking(CreateBookingsDto details);
    Task UpdateBooking(Guid bId, CreateBookingsDto updatedData);
    Task<BookingsDto> GetBookingDetailsById(Guid bId);


}
