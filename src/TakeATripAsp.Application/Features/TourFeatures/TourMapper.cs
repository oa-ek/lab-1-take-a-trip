using AutoMapper;
using TakeTripAsp.Application.Features.Tourfeatures.TourDtos;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Application.Features.Tourfeatures
{
    public class TourMapper : Profile
    {
        public TourMapper()
        {
            CreateMap<Tour, CreateTourDto>();
            CreateMap<CreateTourDto, Tour>();

            CreateMap<Tour, ReadTourDto>();
            CreateMap<ReadTourDto, Tour>();
        }
    }
}
