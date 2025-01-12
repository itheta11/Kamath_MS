using System;
using System.Collections.Generic;

namespace KamathResidency.Infrastructure;

public partial class User
{
    public Guid Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public decimal? PhoneNumber { get; set; }

    public string IdProof { get; set; } = null!;

    public virtual ICollection<Booking> Bookings { get; } = new List<Booking>();
}
