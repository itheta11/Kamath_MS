using System;
using System.Collections.Generic;

namespace KamathResidency.Infrastructure;

public partial class User
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public string Name { get; set; }
    public string Address { get; set; }
    public decimal? PhoneNumber { get; set; }
    public string IdProof { get; set; }

    public ICollection<Booking>? Bookings { get; set; }
}
