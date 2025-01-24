using System;
using System.Collections.Generic;

namespace KamathResidency.Infrastructure;

public partial class Booking
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime ModifiedAt { get; set; } = DateTime.UtcNow;
    public string UserId { get; set; }
    public User User { get; set; }
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    public double TotalBill { get; set; }
    public double? AdvanceAmount { get; set; }

    public ICollection<Room> Rooms { get; set; }
}
