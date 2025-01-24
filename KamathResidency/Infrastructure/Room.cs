using System;
using System.Collections.Generic;

namespace KamathResidency.Infrastructure;

public partial class Room
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public int? Floor { get; set; }
    public string RoomType { get; set; }
    public bool? IsAc { get; set; }

    public ICollection<Booking>? Bookings { get; set; }
}
