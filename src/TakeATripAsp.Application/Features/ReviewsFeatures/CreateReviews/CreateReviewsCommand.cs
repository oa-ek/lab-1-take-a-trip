using MediatR;
using TakeTripAsp.Application.Features.ReviewsFeatures.ReviewsDtos;

namespace TakeTripAsp.Application.Features.ReviewsFeatures.CreateReviews
{
    public class CreateReviewsCommand
    : IRequest<CreateReviewsDto>
    {
        public required string Name { get; set; }
        public required int TourId { get; set; }

    }
}