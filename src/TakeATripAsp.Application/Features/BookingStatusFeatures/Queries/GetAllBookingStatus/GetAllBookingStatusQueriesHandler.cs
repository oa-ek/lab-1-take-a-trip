using AutoMapper;
using MediatR;
using TakeTripAsp.Application.Features.BookingStatusFeatures.BookingStatusDtos;
using TakeTripAsp.Application.Repository;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Application.Features.BookingStatusFeatures.Queries.GetAllBookingStatus
{
    public class GetAllBookingStatusQueriesHandler
    : IRequestHandler<GetAllBookingStatusQueries, IEnumerable<ReadBookingStatusDto>>
    {
        protected readonly IBaseRepository<BookingStatus, int>? _bookingStatusRepository;
        protected readonly IMapper _mapper;

        public GetAllBookingStatusQueriesHandler(
            IBaseRepository<BookingStatus, int> bookingStatusRepository,
            IMapper mapper)
        {
            (_bookingStatusRepository, _mapper) = (bookingStatusRepository, mapper);
        }

        public async Task<IEnumerable<ReadBookingStatusDto>> Handle(
            GetAllBookingStatusQueries request,
            CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<BookingStatus>,
                IEnumerable<ReadBookingStatusDto>>(await _bookingStatusRepository.GetAllAsync());
        }
    }
}
