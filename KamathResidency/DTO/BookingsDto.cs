using System;

namespace KamathResidency.DTO;

public class BookingsDto
{
    public Guid BookingId { get; set; }

    public DateTime CheckIn { get; set; }

    public DateTime CheckOut { get; set; }
}
