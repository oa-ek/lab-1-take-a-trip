using AutoMapper;
using MediatR;
using TakeTripAsp.Application.Features.BookingStatusFeatures.BookingStatusDtos;
using TakeTripAsp.Application.Repository;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Application.Features.BookingStatusFeatures.Commands.CreateBookingStatus
{
    public class CreateBookingStatusCommandHandler
          : IRequestHandler<CreateBookingStatusCommand, CreateBookingStatusDto>
    {
        protected readonly IBaseRepository<BookingStatus, int>? _bookingStatusRepository;
        protected readonly IMapper _mapper;

        public CreateBookingStatusCommandHandler(
            IBaseRepository<BookingStatus, int> bookingStatusRepository,
            IMapper mapper)
        {
            (_bookingStatusRepository, _mapper) = (bookingStatusRepository, mapper);
        }

        public async Task<CreateBookingStatusDto> Handle(
            CreateBookingStatusCommand request,
            CancellationToken cancellationToken)
        {
            var bookingStatus = await _bookingStatusRepository.CreateAsync(
                new BookingStatus { BookingStatusName = request.Name });

            return _mapper.Map<BookingStatus, CreateBookingStatusDto>(bookingStatus);
        }
    }
}
