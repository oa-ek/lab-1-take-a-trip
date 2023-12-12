using MediatR;
using TakeTripAsp.Application.Features.CityFeatures.CityDtos;

namespace TakeTripAsp.Application.Features.CityFeatures.Queries.GetAllCity
{
    public class GetAllCityQueries 
        : IRequest<IEnumerable<ReadCityDto>>
    { }
 }
