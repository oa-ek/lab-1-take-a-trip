using AutoMapper;
using TakeTripAsp.Application.Features.TourManagerRequestFeatures.TourManagerRequestDtos;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Application.Features.TourManagerRequestFeatures
{
    public class TourManagerRequestMapper : Profile
    {
        public TourManagerRequestMapper()
        {
            CreateMap<TourManagerRequest, CreateTourManagerRequestDto>();
            CreateMap<CreateTourManagerRequestDto, TourManagerRequest>();

            CreateMap<TourManagerRequest, ReadTourManagerRequestDto>();
            CreateMap<ReadTourManagerRequestDto, TourManagerRequest>();
        }
    }
}
