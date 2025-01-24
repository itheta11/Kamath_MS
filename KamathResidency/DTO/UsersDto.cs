using System;

namespace KamathResidency.DTO;

public class UsersDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public decimal? PhoneNumber { get; set; }
    public string IdProof { get; set; }

}
