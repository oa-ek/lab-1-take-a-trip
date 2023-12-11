using AutoMapper;
using MediatR;
using TakeTripAsp.Application.Features.CountryFeatures.CountryDtos;
using TakeTripAsp.Application.Repository;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Application.Features.CountryFeatures.Queries.GetAllCountry
{
    public class GetAllCountryQueriesHandler
   : IRequestHandler<GetAllCountryQueries, IEnumerable<ReadCountryDto>>
    {
        protected readonly IBaseRepository<Country, int>? _countryRepository;
        protected readonly IMapper _mapper;

        public GetAllCountryQueriesHandler(
            IBaseRepository<Country, int> countryRepository,
            IMapper mapper)
        {
            (_countryRepository, _mapper) = (countryRepository, mapper);
        }

        public async Task<IEnumerable<ReadCountryDto>> Handle(
            GetAllCountryQueries request,
            CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<Country>,
                IEnumerable<ReadCountryDto>>(await _countryRepository.GetAllAsync());
        }
    }   
}


