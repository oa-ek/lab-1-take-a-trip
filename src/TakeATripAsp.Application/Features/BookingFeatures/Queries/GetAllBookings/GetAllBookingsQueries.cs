using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeTripAsp.Application.Features.BookingFeatures.BookingsDtos;

namespace TakeTripAsp.Application.Features.BookingFeatures.Queries.GetAllBookings
{
    public class GetAllBookingsQueries 
        : IRequest<IEnumerable<ReadBookingsDto>> { }
}
