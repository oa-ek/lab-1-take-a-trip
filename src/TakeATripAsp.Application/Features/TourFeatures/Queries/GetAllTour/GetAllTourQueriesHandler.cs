using AutoMapper;
using MediatR;
using TakeTripAsp.Application.Features.TourFeatures.TourDtos;
using TakeTripAsp.Application.Repository;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Application.Features.TourFeatures.Queries.GetAllTour
{
    public class GetAllTourQueriesHandler
        : IRequestHandler<GetAllTourQueries, IEnumerable<ReadTourDto>>
    {
        protected readonly IBaseRepository<Tour, int> _tourRepository;
        protected readonly IMapper _mapper;

        public GetAllTourQueriesHandler(IBaseRepository<Tour, int> tourRepository, IMapper mapper)
        {
            (_tourRepository, _mapper) = (tourRepository, mapper);
        }

        public async Task<IEnumerable<ReadTourDto>> Handle(
            GetAllTourQueries request,
            CancellationToken cancellationToken)
        {
            var tourList = await _tourRepository.GetAllAsync();
            var readDtoList = _mapper.Map<IEnumerable<Tour>, IEnumerable<ReadTourDto>>(tourList);

            foreach (var tour in tourList)
            {
                foreach (var categories in tour.Categories)
                {
                    readDtoList.FirstOrDefault(x => x.Id == tour.Id)
                        .CategoryNames.Add(categories.Name);
                }

                foreach (var cities in tour.Cities)
                {
                    readDtoList.FirstOrDefault(x => x.Id == tour.Id)
                        .CityNames.Add(cities.CityName);
                }

                readDtoList.FirstOrDefault(x => x.Id == tour.Id)
                    .Country = tour.Cities.FirstOrDefault(x => x.Id != null).Country.CountryName;
            }

            return readDtoList;
        }
    }
}