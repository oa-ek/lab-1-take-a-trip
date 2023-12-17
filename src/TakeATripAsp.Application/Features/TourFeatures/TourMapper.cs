using AutoMapper;
using TakeTripAsp.Application.Features.TourFeatures.TourDtos;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Application.Features.TourFeatures
{
    public class TourMapper : Profile
    {
        public TourMapper()
        {
            CreateMap<Tour, CreateTourDto>();
            CreateMap<CreateTourDto, Tour>();

            CreateMap<Tour, ReadTourDto>()
                .ForMember(dest => dest.CategoryNames, opt => opt.MapFrom(src => src.Categories.Select(c => c.Name).ToList()))
                .ForMember(dest => dest.CityNames, opt => opt.MapFrom(src => src.Cities.Select(c => c.CityName).ToList()))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Cities.Select(c => c.Country.CountryName).FirstOrDefault()));
            CreateMap<ReadTourDto, Tour>();

            CreateMap<Tour, UpdateTourDto>()
                .ForMember(dest => dest.CategoryIds, opt => opt.MapFrom(src => src.Categories.Select(c => c.Id).ToList()))
                .ForMember(dest => dest.CityIds, opt => opt.MapFrom(src => src.Cities.Select(c => c.Id).ToList()));
            CreateMap<UpdateTourDto, Tour>();
        }
    }
}
