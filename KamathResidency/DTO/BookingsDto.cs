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
    public UsersDto User { get; set; }
    public List<RoomDto> Rooms { get; set; }
}


public class CreateBookingsDto
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime ModifiedAt { get; set; } = DateTime.UtcNow;
    public string UserId { get; set; }
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    public double TotalBill { get; set; }
    public double? AdvanceAmount { get; set; }
    public List<int> RoomIds { get; set; }
}
