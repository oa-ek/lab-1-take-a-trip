using MediatR;
using TakeTripAsp.Application.Features.CityFeatures.CityDtos;

namespace TakeTripAsp.Application.Features.CityFeatures.Commands.UpdateCity
{
    public class UpdateCityCommand : IRequest<ReadCityDto>
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public int CountryId { get; set; }
    }
}


