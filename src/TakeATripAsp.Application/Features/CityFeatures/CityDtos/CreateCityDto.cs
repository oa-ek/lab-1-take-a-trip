namespace TakeTripAsp.Application.Features.CityFeatures.CityDtos
{
    public class CreateCityDto
    {
        public required string CityName { get; set; }

        public int CountryId { get; set; }
    }
}
