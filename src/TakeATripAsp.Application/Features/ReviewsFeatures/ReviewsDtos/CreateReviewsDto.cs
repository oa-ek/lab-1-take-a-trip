namespace TakeTripAsp.Application.Features.ReviewsFeatures.ReviewsDtos
{
    public class CreateReviewsDto
    {
        public required string Comment { get; set; }
        public required int TourId { get; set; }
    }
}
