using AutoMapper;
using MediatR;
using TakeTripAsp.Application.Features.CountryFeatures.CountryDtos;
using TakeTripAsp.Application.Repository;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Application.Features.CountryFeatures.Commands.UpdateCountry
{
    public class UpdateCountryCommandHandler
    : IRequestHandler<UpdateCountryCommand, ReadCountryDto>
    {
        protected readonly IBaseRepository<Country, int> _countryRepository;
        protected readonly IMapper _mapper;

        public UpdateCountryCommandHandler(
            IBaseRepository<Country, int> countryRepository,
            IMapper mapper)
        {
            (_countryRepository, _mapper) = (countryRepository, mapper);
        }

        public async Task<ReadCountryDto> Handle(
            UpdateCountryCommand request,
            CancellationToken cancellationToken)
        {
            var country = await _countryRepository.GetAsync(request.Id);

            country.CountryName = request.Name;

            await _countryRepository.UpdateAsync(country);

            return _mapper.Map<Country, ReadCountryDto>(country);
        }
    }      
}

