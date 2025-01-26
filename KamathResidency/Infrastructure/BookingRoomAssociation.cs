using System;
using System.Collections.Generic;

namespace KamathResidency.Infrastructure;

public partial class BookingRoomAssociation
{
    public Guid Id { get; set; }

    public Guid BookingId { get; set; }

    public long RoomId { get; set; }

    public virtual Booking Booking { get; set; } = null!;

    public virtual Room Room { get; set; } = null!;
}
