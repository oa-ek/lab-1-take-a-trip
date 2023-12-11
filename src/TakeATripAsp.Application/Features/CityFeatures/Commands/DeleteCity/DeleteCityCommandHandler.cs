using MediatR;
using TakeTripAsp.Application.Repository;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Application.Features.CityFeatures.Commands.DeleteCity
{
    public class DeleteCityCommandHandler : IRequestHandler<DeleteCityCommand, int>
    {
        private readonly IBaseRepository<City, int> _cityRepository;

        public DeleteCityCommandHandler(IBaseRepository<City, int> cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<int> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {
            var city = await _cityRepository.GetAsync(request.Id);

            await _cityRepository.DeleteAsync(city);

            return city.Id;
        }
    }
}



