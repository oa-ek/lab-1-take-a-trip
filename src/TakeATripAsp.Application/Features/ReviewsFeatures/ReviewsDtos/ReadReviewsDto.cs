namespace TakeTripAsp.Application.Features.ReviewsFeatures.ReviewsDtos
{
    public class ReadReviewsDto
    {
        public int TourId { get; set; }

        public int Id { get; set; }

        public required string Comment { get; set; }

        public string ClientId { get; set; }
    }
}
