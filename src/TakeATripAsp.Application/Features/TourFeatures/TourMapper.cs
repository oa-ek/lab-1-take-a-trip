using AutoMapper;
using TakeTripAsp.Application.Features.TourFeatures.TourDtos;
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

            CreateMap<Tour, ReadTourDto>();
            CreateMap<ReadTourDto, Tour>();

            CreateMap<Tour, UpdateTourDto>();
            CreateMap<UpdateTourDto, Tour>();
        }
    }
}
