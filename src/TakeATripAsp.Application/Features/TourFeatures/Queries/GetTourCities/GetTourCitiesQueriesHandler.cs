using MediatR;
using System.Text.Json;
using TakeTripAsp.Application.Features.TourFeatures.TourDtos;
using TakeTripAsp.Application.Repository;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Application.Features.TourFeatures.Queries.GetTourCities
{
    public class GetTourCitiesQueriesHandler : IRequestHandler<GetTourCitiesQueries, IEnumerable<TourLocationDto>>
    {
        protected IBaseRepository<Tour, int>? _tourRepository;

        public GetTourCitiesQueriesHandler(IBaseRepository<Tour, int> tourRepository)
        {
            _tourRepository = tourRepository;
        }

        public async Task<IEnumerable<TourLocationDto>> Handle(GetTourCitiesQueries request,
        CancellationToken cancellationToken)
        {
            var apiKey = "AjlJddqbUvLjnHySK9UuHYlb4xmpuK_UYAfdQyCF9rUbjn80fhm6OiUB99uG3A4a";
            var tour = await _tourRepository.GetAsync(request.Id);

            var cities = tour.Cities.ToList();

            List<TourLocationDto> locationDtos = new List<TourLocationDto>();

            foreach (var city in cities)
            {
                var geocodingUrl = "https://dev.virtualearth.net/REST/v1/Locations?query=" + city.CityName + "&key=" + apiKey;
                var response = await request.httpClient.GetStringAsync(geocodingUrl);

                var jsonObject = JsonDocument.Parse(response).RootElement;

                var coordinates = jsonObject
                    .GetProperty("resourceSets")[0]
                    .GetProperty("resources")[0]
                    .GetProperty("point")
                    .GetProperty("coordinates");

                locationDtos.Add(new TourLocationDto
                {
                    LocationId = city.Id,
                    Title = city.CityName,
                    Description = $"{city.CityName}, {city.Country.CountryName}",
                    Latitude = coordinates[0].GetDouble(),
                    Longitude = coordinates[1].GetDouble(),
                });
            }

            return locationDtos;
        }
    }
}
