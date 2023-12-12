namespace TakeTripAsp.Application.Features.TourManagerRequestFeatures.TourManagerRequestDtos
{
    public class CreateTourManagerRequestDto
    {
        public string ClientId { get; set; }

        public DateTime RequestDate { get; set; }

        public bool IsApproved { get; set; }

        public bool IsCompanyMember { get; set; }

        public bool IsSeller { get; set; }


    }
}
