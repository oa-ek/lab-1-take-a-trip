using AutoMapper;
using MediatR;
using TakeTripAsp.Application.Features.CityFeatures.CityDtos;
using TakeTripAsp.Application.Repository;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Application.Features.CityFeatures.Commands.CreateCity
{
    public class CreateCityCommandHandler 
        : IRequestHandler<CreateCityCommand, CreateCityDto>
    {
        private readonly IBaseRepository<City, int> _cityRepository;
        private readonly IMapper _mapper;

        public CreateCityCommandHandler(
            IBaseRepository<City, int> cityRepository, 
            IMapper mapper)
        {
            (_cityRepository, _mapper) = (cityRepository, mapper);
        }

        public async Task<CreateCityDto> Handle(
            CreateCityCommand request, 
            CancellationToken cancellationToken)
        {
            var city = await _cityRepository.CreateAsync(new City { 
                CityName = request.CityName, 
                CountryId = request.CountryId });

            return _mapper.Map<City, CreateCityDto>(city);
        }
    }
}
