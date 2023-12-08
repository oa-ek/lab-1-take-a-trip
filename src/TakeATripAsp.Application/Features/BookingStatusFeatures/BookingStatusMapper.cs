using AutoMapper;
using TakeTripAsp.Application.Features.BookingStatusFeatures.BookingStatusDtos;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Application.Features.BookingStatusFeatures
{
    public class BookingStatusMapper : Profile
    {
        public BookingStatusMapper()
        {
            CreateMap<BookingStatus, CreateBookingStatusDto>();
            CreateMap<CreateBookingStatusDto, BookingStatus>();

            CreateMap<BookingStatus, ReadBookingStatusDto>();
            CreateMap<ReadBookingStatusDto, BookingStatus>();
        }
    }
}
