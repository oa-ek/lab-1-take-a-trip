using AutoMapper;
using MediatR;
using TakeTripAsp.Application.Features.CountryFeatures.CountryDtos;
using TakeTripAsp.Application.Repository;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Application.Features.CountryFeatures.Commands.CreateCountry
{
    public class CreateCountryCommandHandler
    : IRequestHandler<CreateCountryCommand, CreateCountryDto>
    {
        protected readonly IBaseRepository<Country, int>? _countyRepository;
        protected readonly IMapper _mapper;

        public CreateCountryCommandHandler(
            IBaseRepository<Country, int> countryRepository,
            IMapper mapper)
        {
            (_countyRepository, _mapper) = (countryRepository, mapper);
        }

        public async Task<CreateCountryDto> Handle(
            CreateCountryCommand request,
            CancellationToken cancellationToken)
        {
            var country = await _countyRepository.CreateAsync(
                new Country { CountryName = request.Name });

            return _mapper.Map<Country, CreateCountryDto>(country);
        }
    }
}


