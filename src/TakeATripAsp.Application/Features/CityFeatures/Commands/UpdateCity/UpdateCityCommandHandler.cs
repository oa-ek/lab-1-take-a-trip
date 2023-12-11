using AutoMapper;
using MediatR;
using TakeTripAsp.Application.Features.CityFeatures.CityDtos;
using TakeTripAsp.Application.Repository;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Application.Features.CityFeatures.Commands.UpdateCity
{
    public class UpdateCityCommandHandler : IRequestHandler<UpdateCityCommand, ReadCityDto>
    {
        private readonly IBaseRepository<City, int> _cityRepository;
        private readonly IMapper _mapper;

        public UpdateCityCommandHandler(
            IBaseRepository<City, int> cityRepository, 
            IMapper mapper)
        {
            (_cityRepository, _mapper) = (cityRepository, mapper);
        }

        public async Task<ReadCityDto> Handle(
            UpdateCityCommand request, 
            CancellationToken cancellationToken)
        {
            var city = await _cityRepository.GetAsync(request.Id);

            city.CityName = request.CityName;
            city.CountryId = request.CountryId;

            await _cityRepository.UpdateAsync(city);

            return _mapper.Map<City, ReadCityDto>(city);
        }
    }
}