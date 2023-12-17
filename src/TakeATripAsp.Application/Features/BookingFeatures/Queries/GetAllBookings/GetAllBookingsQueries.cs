using MediatR;
using TakeTripAsp.Application.Features.BookingFeatures.BookingsDtos;

namespace TakeTripAsp.Application.Features.BookingFeatures.Queries.GetAllBookings
{
    public class GetAllBookingsQueries 
        : IRequest<IEnumerable<ReadBookingsDto>> { }
}
