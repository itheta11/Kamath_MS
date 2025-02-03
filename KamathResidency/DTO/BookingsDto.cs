using System;

namespace KamathResidency.DTO;

public class BookingsDto
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    public double TotalBill { get; set; }
    public double? AdvanceAmount { get; set; }
    public UserDto User { get; set; }
    public List<RoomDto> Rooms { get; set; }
}


public class CreateBookingsDto
{
    public Guid UserId { get; set; }
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    public double TotalBill { get; set; }
    public double? AdvanceAmount { get; set; }
    public List<long> RoomIds { get; set; }
}

public class PartialBookingUpdateApi
{
    public DateTime? CheckIn { get; set; }
    public DateTime? CheckOut { get; set; }
    public List<long>? AddedRoomIds { get; set; }
    public List<long>? DeletedRoomIds { get; set; }

}
