using System;

namespace KamathResidency.DTO;

public class BookingsDto
{
    public Guid BookingId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public long RoomNo { get; set; }

    public Guid UserId { get; set; }

    public DateTime CheckIn { get; set; }

    public DateTime CheckOut { get; set; }

    public double TotalBill { get; set; }

    public double? AdvanceAmount { get; set; }
}
