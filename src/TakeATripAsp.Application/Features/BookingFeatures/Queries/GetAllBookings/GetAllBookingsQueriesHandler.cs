using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeTripAsp.Application.Features.BookingFeatures.BookingsDtos;
using TakeTripAsp.Application.Repository;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Application.Features.BookingFeatures.Queries.GetAllBookings
{
    public class GetAllBookingsQueriesHandler : IRequestHandler<GetAllBookingsQueries, IEnumerable<ReadBookingsDto>>
    {
        protected readonly IBaseRepository<Bookings, int>? _bookingsRepository;
        protected readonly IMapper _mapper;

        public GetAllBookingsQueriesHandler(
            IBaseRepository<Bookings, int> bookingsRepository,
            IMapper mapper)
        {
            (_bookingsRepository, _mapper) = (bookingsRepository, mapper);
        }

        public async Task<IEnumerable<ReadBookingsDto>> Handle(
            GetAllBookingsQueries request,
            CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<Bookings>, IEnumerable<ReadBookingsDto>>(await _bookingsRepository.GetAllAsync());
        }
    }
}
