using MediatR;
using TakeTripAsp.Application.Features.CountryFeatures.CountryDtos;

namespace TakeTripAsp.Application.Features.CountryFeatures.Commands.CreateCountry
{
    public class CreateCountryCommand
        : IRequest<CreateCountryDto>
    {
        public required string Name { get; set; }
    }
}
