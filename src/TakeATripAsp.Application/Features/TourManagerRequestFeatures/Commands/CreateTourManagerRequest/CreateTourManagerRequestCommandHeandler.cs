using AutoMapper;
using MediatR;
using TakeTripAsp.Application.Features.TourManagerRequestFeatures.TourManagerRequestDtos;
using TakeTripAsp.Application.Repository;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Application.Features.TourManagerRequestFeatures.Commands.CreateTourManagerRequest
{
    public class CreateTourManagerRequestCommandHandler : IRequestHandler<CreateTourManagerRequestCommand, ReadTourManagerRequestDto>
    {
        protected readonly IBaseRepository<TourManagerRequest, int> _tourManagerRequestRepository;
        protected readonly IMapper _mapper;

        public CreateTourManagerRequestCommandHandler(
            IBaseRepository<TourManagerRequest, int> tourManagerRequestRepository,
            IMapper mapper)
        {
            (_tourManagerRequestRepository, _mapper) = (tourManagerRequestRepository, mapper);
        }

        public async Task<ReadTourManagerRequestDto> Handle(
            CreateTourManagerRequestCommand request,
            CancellationToken cancellationToken)
        {
            var tourManagerRequest = await _tourManagerRequestRepository.CreateAsync(
                new TourManagerRequest
                {
                    ClientId = request.ClientId,
                    RequestDate = request.RequestDate,
                    IsApproved = request.IsApproved,
                    IsCompanyMember = request.IsCompanyMember,
                    IsSeller = request.IsSeller
                });

            return _mapper.Map<TourManagerRequest, ReadTourManagerRequestDto>(tourManagerRequest);
        }
    }
}