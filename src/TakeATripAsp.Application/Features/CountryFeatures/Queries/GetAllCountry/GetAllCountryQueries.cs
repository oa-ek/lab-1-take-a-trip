using MediatR;
using TakeTripAsp.Application.Features.CountryFeatures.CountryDtos;

namespace TakeTripAsp.Application.Features.CountryFeatures.Queries.GetAllCountry
{
    public class GetAllCountryQueries
        : IRequest<IEnumerable<ReadCountryDto>>
    { }
}

