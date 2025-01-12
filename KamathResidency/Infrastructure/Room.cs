using System;
using System.Collections.Generic;

namespace KamathResidency.Infrastructure;

public partial class Room
{
    public long Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public int? Floor { get; set; }

    public string? RoomType { get; set; }

    public bool? IsAc { get; set; }

    public virtual ICollection<Booking> Bookings { get; } = new List<Booking>();
}
