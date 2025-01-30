using System;
using AutoMapper;
using KamathResidency.DTO;
using KamathResidency.Infrastructure;

namespace KamathResidency.Mappings;

public class BookingMapping : Profile
{
    public BookingMapping()
    {
        CreateMap<Booking, BookingsDto>();
        CreateMap<BookingsDto, Booking>();
    }
}
