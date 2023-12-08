using MediatR;
using TakeTripAsp.Application.Features.BookingStatusFeatures.BookingStatusDtos;

namespace TakeTripAsp.Application.Features.BookingStatusFeatures.Queries.GetAllBookingStatus
{
    public class GetAllBookingStatusQueries
        : IRequest<IEnumerable<ReadBookingStatusDto>>
    { }
}

