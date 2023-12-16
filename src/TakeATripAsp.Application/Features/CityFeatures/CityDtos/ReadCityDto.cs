namespace TakeTripAsp.Application.Features.CityFeatures.CityDtos
{
    public class ReadCityDto
    {
        public required string CityName { get; set; }

        public int CountryId { get; set; }

        public int Id { get; set; }
    }
}
