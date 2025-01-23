using System;
using System.Collections.Generic;

namespace KamathResidency.Infrastructure;

public partial class Room
{
    public long Id { get; set; }

    public byte[] CreatedAt { get; set; } = null!;

    public long? Floor { get; set; }

    public string? RoomType { get; set; }

    public byte[]? IsAc { get; set; }

    public virtual ICollection<Booking> Bookings { get; } = new List<Booking>();
}
