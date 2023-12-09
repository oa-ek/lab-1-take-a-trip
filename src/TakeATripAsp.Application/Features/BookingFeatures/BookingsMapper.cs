using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeTripAsp.Application.Features.BookingFeatures.BookingsDtos;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Application.Features.BookingFeatures
{
    public class BookingsMapper : Profile
    {
        public BookingsMapper()
        {
            CreateMap<Bookings, CreateBookingsDto>();
            CreateMap<CreateBookingsDto, Bookings>();

            CreateMap<Bookings, ReadBookingsDto>();
            CreateMap<ReadBookingsDto, Bookings>();
        }
    }
}
