using MediatR;

namespace TakeTripAsp.Application.Features.CityFeatures.Commands.DeleteCity
{
    public class DeleteCityCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
