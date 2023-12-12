using TakeTripAsp.Application.Features.AppUserFeatures.AppUserDto;
using TakeTripAsp.Application.Features.Tourfeatures.TourDtos;

namespace TakeTripAsp.Application.Features.ReviewsFeatures.ReviewsDtos
{
    public class ReadReviewsDto
    {
        public int Id { get; set; }

        public string Comment { get; set; }

        public string ClientId { get; set; }

        public int TourId { get; set; }
    }
}
