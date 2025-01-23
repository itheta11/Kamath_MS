using System;
using System.Collections.Generic;

namespace KamathResidency.Infrastructure;

public partial class Booking
{
    public string Id { get; set; } = null!;

    public byte[] CreatedAt { get; set; } = null!;

    public byte[]? ModifiedAt { get; set; }

    public string UserId { get; set; } = null!;

    public byte[] CheckIn { get; set; } = null!;

    public byte[] CheckOut { get; set; } = null!;

    public double TotalBill { get; set; }

    public double? AdvanceAmount { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual ICollection<Room> Rooms { get; } = new List<Room>();
}
