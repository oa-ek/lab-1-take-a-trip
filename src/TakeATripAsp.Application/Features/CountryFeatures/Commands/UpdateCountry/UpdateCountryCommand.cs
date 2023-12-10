using MediatR;
using TakeTripAsp.Application.Features.CountryFeatures.CountryDtos;

namespace TakeTripAsp.Application.Features.CountryFeatures.Commands.UpdateCountry
{
    public class UpdateCountryCommand
     : IRequest<ReadCountryDto>
    {
        public int Id { get; set; }

        public required string Name { get; set; }
    }
}
