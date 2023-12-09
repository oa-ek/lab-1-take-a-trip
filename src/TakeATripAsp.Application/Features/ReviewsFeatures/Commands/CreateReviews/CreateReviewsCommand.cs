using MediatR;
using TakeTripAsp.Application.Features.ReviewsFeatures.ReviewsDtos;

namespace TakeTripAsp.Application.Features.ReviewsFeatures.Commands.CreateReviews
{
    public class CreateReviewsCommand
    : IRequest<CreateReviewsDto>
    {
        public required string Comment { get; set; }

        public string ClientId { get; set; }

        public required int TourId { get; set; }

    }
}