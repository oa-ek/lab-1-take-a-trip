using AutoMapper;
using TakeTripAsp.Application.Features.CityFeatures.CityDtos;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Application.Features.CityFeatures
{
    public class CityMapper : Profile
    {
        public CityMapper() {
            CreateMap<City, CreateCityDto>();
            CreateMap<CreateCityDto, City>();

            CreateMap<City, ReadCityDto>();
            CreateMap<ReadCityDto, City>();
        }
    }
}
