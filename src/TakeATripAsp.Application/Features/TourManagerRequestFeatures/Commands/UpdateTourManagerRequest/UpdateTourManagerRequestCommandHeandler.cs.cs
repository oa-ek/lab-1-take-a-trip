using AutoMapper;
using MediatR;
using TakeTripAsp.Application.Features.TourManagerRequestFeatures.TourManagerRequestDtos;
using TakeTripAsp.Application.Repository;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Application.Features.TourManagerRequestFeatures.Commands.UpdateTourManagerRequest
{
    public class UpdateTourManagerRequestCommandHandler : IRequestHandler<UpdateTourManagerRequestCommand, ReadTourManagerRequestDto>
    {
        protected readonly IBaseRepository<TourManagerRequest, int> _tourManagerRequestRepository;
        protected readonly IMapper _mapper;

        public UpdateTourManagerRequestCommandHandler(
            IBaseRepository<TourManagerRequest, int> tourManagerRequestRepository,
            IMapper mapper)
        {
            (_tourManagerRequestRepository, _mapper) = (tourManagerRequestRepository, mapper);
        }

        public async Task<ReadTourManagerRequestDto> Handle(
            UpdateTourManagerRequestCommand request,
            CancellationToken cancellationToken)
        {
            var tourManagerRequest = await _tourManagerRequestRepository.GetAsync(request.Id);


            tourManagerRequest.ClientId = request.ClientId;
            tourManagerRequest.RequestDate = request.RequestDate;
            tourManagerRequest.IsApproved = request.IsApproved;
            tourManagerRequest.IsCompanyMember = request.IsCompanyMember;
            tourManagerRequest.IsSeller = request.IsSeller;

            await _tourManagerRequestRepository.UpdateAsync(tourManagerRequest);

            return _mapper.Map<TourManagerRequest, ReadTourManagerRequestDto>(tourManagerRequest);
        }
    }
}
