using System;

namespace KamathResidency.DTO;

public class RoomBookingsDto
{
    public long RoomId { get; set; }

    public string? RoomType { get; set; }

    public bool? IsAc { get; set; }

    public List<BookingsDto> Bookings { get; set; } = null!;
}
