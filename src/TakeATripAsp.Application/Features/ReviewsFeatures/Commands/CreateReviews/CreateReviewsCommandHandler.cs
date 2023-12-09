using AutoMapper;
using MediatR;
using TakeTripAsp.Application.Features.ReviewsFeatures.ReviewsDtos;
using TakeTripAsp.Application.Repository;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Application.Features.ReviewsFeatures.Commands.CreateReviews
{
    public class CreateReviewsCommandHandler
       : IRequestHandler<CreateReviewsCommand, CreateReviewsDto>
    {
        protected readonly IBaseRepository<Reviews, int>? _reviewsRepository;
        protected readonly IMapper _mapper;

        public CreateReviewsCommandHandler(
            IBaseRepository<Reviews, int> reviewsRepository,
            IMapper mapper)
        {
            (_reviewsRepository, _mapper) = (reviewsRepository, mapper);
        }

        public async Task<CreateReviewsDto> Handle(
            CreateReviewsCommand request,
            CancellationToken cancellationToken)
        {
            var reviews = await _reviewsRepository.CreateAsync(
                new Reviews { Comment = request.Comment, TourId = request.TourId, ClientId = request.ClientId });

            return _mapper.Map<Reviews, CreateReviewsDto>(reviews);
        }
    }
}
