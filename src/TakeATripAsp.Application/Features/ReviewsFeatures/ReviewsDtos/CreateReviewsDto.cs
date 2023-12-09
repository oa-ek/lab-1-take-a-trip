namespace TakeTripAsp.Application.Features.ReviewsFeatures.ReviewsDtos
{
    public class CreateReviewsDto
    {
        public required string Comment { get; set; }

        public string ClientId { get; set; }

        public int TourId { get; set; }
    }
}
