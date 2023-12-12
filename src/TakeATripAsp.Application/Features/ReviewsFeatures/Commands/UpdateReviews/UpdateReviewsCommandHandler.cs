using AutoMapper;
using MediatR;
using TakeTripAsp.Application.Features.ReviewsFeatures.ReviewsDtos;
using TakeTripAsp.Application.Repository;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Application.Features.ReviewsFeatures.Commands.UpdateReviews
{
    public class UpdateReviewsCommandHandler
     : IRequestHandler<UpdateReviewsCommand, ReadReviewsDto >
    {
        protected readonly IBaseRepository<Reviews, int> _reviewsRepository;
        protected readonly IMapper _mapper;

        public UpdateReviewsCommandHandler(
            IBaseRepository<Reviews, int> reviewsRepository,
            IMapper mapper)
        {
            (_reviewsRepository, _mapper) = (reviewsRepository, mapper);
        }

        public async Task<ReadReviewsDto> Handle(
            UpdateReviewsCommand request,
            CancellationToken cancellationToken)
        {
            var reviews = await _reviewsRepository.GetAsync(request.Id);

            reviews.Comment = request.Comment;
            reviews.ClientId = request.ClientId;
            reviews.TourId = request.TourId;

            await _reviewsRepository.UpdateAsync(reviews);

            return _mapper.Map<Reviews, ReadReviewsDto>(reviews);
        }
    }
}