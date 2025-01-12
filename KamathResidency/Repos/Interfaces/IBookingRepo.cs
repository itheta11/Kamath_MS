using System;
using KamathResidency.DTO;

namespace KamathResidency.Repos.Interfaces;

public interface IBookingRepo
{
    Task<List<RoomBookingsDto>> GetAllRoomBookings(DateTime fromDate, DateTime toDate);

}
