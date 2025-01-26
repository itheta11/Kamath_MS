using System;

namespace KamathResidency.DTO;

public class RoomDto
{
    public long Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public int? Floor { get; set; }
    public string RoomType { get; set; }
    public bool? IsAc { get; set; }
    public long BasePrice { get; set; }

}
