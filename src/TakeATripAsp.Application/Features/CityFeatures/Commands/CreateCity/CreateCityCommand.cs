using MediatR;
using TakeTripAsp.Application.Features.CityFeatures.CityDtos;

namespace TakeTripAsp.Application.Features.CityFeatures.Commands.CreateCity
{
    public class CreateCityCommand : IRequest<CreateCityDto>
    {
        public string CityName { get; set; }
        public int CountryId { get; set; }
    }
}
