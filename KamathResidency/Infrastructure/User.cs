using System;
using System.Collections.Generic;

namespace KamathResidency.Infrastructure;

public partial class User
{
    public string Id { get; set; } = null!;

    public byte[] CreatedAt { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public byte[]? PhoneNumber { get; set; }

    public string IdProof { get; set; } = null!;

    public virtual ICollection<Booking> Bookings { get; } = new List<Booking>();
}
