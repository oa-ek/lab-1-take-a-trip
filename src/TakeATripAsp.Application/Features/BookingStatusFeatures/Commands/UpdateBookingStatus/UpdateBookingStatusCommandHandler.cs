using AutoMapper;
using MediatR;
using TakeTripAsp.Application.Features.BookingStatusFeatures.BookingStatusDtos;
using TakeTripAsp.Application.Repository;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Application.Features.BookingStatusFeatures.Commands.UpdateBookingStatus
{
    public class UpdateBookingStatusCommandHandler
     : IRequestHandler<UpdateBookingStatusCommand, ReadBookingStatusDto>
    {
        protected readonly IBaseRepository<BookingStatus, int> _bookingStatusRepository;
        protected readonly IMapper _mapper;

        public UpdateBookingStatusCommandHandler(
            IBaseRepository<BookingStatus, int> bookingStatusRepository,
            IMapper mapper)
        {
            (_bookingStatusRepository, _mapper) = (bookingStatusRepository, mapper);
        }

        public async Task<ReadBookingStatusDto> Handle(
            UpdateBookingStatusCommand request,
            CancellationToken cancellationToken)
        {
            var bookingStatus = await _bookingStatusRepository.GetAsync(request.Id);

            bookingStatus.BookingStatusName = request.Name;

            await _bookingStatusRepository.UpdateAsync(bookingStatus);

            return _mapper.Map<BookingStatus, ReadBookingStatusDto>(bookingStatus);
        }
    }
}

