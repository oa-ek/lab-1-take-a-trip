namespace TakeTripAsp.Application.Features.TourManagerRequestFeatures.TourManagerRequestDtos
{
    public class ReadTourManagerRequestDto
    {
        public string ClientId { get; set; }

        public DateTime RequestDate { get; set; }

        public bool IsApproved { get; set; }

        public bool IsCompanyMember { get; set; }

        public bool IsSeller { get; set; }
        public int Id { get; set; }

    }
}
