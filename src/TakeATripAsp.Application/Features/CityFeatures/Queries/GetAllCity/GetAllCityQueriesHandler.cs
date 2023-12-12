using AutoMapper;
using MediatR;
using TakeTripAsp.Application.Features.CityFeatures.CityDtos;
using TakeTripAsp.Application.Repository;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Application.Features.CityFeatures.Queries.GetAllCity
{
    public class GetAllCityQueriesHandler 
        : IRequestHandler<GetAllCityQueries, IEnumerable<ReadCityDto>>
    {
        private readonly IBaseRepository<City, int> _cityRepository;
        private readonly IMapper _mapper;

        public GetAllCityQueriesHandler(
            IBaseRepository<City, int> cityRepository, 
            IMapper mapper)
        {
            (_cityRepository, _mapper) = (cityRepository, mapper);
        }

        public async Task<IEnumerable<ReadCityDto>> Handle(
            GetAllCityQueries request, 
            CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<City>, 
            IEnumerable<ReadCityDto>>(await _cityRepository.GetAllAsync());
          
        }
    }
}
