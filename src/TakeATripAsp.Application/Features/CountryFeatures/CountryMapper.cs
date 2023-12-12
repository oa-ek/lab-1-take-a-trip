using AutoMapper;
using TakeTripAsp.Application.Features.CountryFeatures.CountryDtos;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Application.Features.CountryFeatures
{
    public class CountryMapper: Profile
    {
        public CountryMapper()
        {
            CreateMap<Country, CreateCountryDto>();
            CreateMap<CreateCountryDto, Country>();

            CreateMap<Country, ReadCountryDto>().ForMember(dest => dest.Name, act => act.MapFrom(src => src.CountryName));
            CreateMap<ReadCountryDto, Country>();
        }
    }
}
