﻿using System;
using System.Collections.Generic;

namespace KamathResidency.Infrastructure;

public partial class Booking
{
    public Guid Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public Guid UserId { get; set; }

    public DateTime CheckIn { get; set; }

    public DateTime CheckOut { get; set; }

    public double TotalBill { get; set; }

    public double? AdvanceAmount { get; set; }

    public virtual ICollection<BookingRoomAssociation> BookingRoomAssociations { get; } = new List<BookingRoomAssociation>();

    public virtual User User { get; set; } = null!;
}
