using TakeTripAsp.Application.Features.AppUserFeatures.AppUserDto;
using TakeTripAsp.Application.Features.Tourfeatures.TourDtos;

namespace TakeTripAsp.Application.Features.ReviewsFeatures.ReviewsDtos
{
    public class ReadReviewsDto
    {
        public int Id { get; set; }

        public string Comment { get; set; }

        public ReadAppUserDto Client { get; set; }

        public string ClientId { get; set; }

        public ReadTourDto Tour { get; set; }

        public int TourId { get; set; }
    }
}
