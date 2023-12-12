using TakeTripAsp.Application.Features.AppUserFeatures.AppUserDto;
using TakeTripAsp.Application.Features.Tourfeatures.TourDtos;

namespace TakeTripAsp.Application.Features.ReviewsFeatures.ReviewsDtos
{
    public class CreateReviewsDto
    {
        public required string Comment { get; set; }

        public string ClientId { get; set; }

        public required int TourId { get; set; }
    }
}
