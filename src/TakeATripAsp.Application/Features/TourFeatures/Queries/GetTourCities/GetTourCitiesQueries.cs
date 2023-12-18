using MediatR;
using TakeTripAsp.Application.Features.TourFeatures.TourDtos;

namespace TakeTripAsp.Application.Features.TourFeatures.Queries.GetTourCities
{
    public class GetTourCitiesQueries : IRequest<IEnumerable<TourLocationDto>>
    {
        public int Id { get; set; }

        public HttpClient httpClient { get; set; }
    }
}
