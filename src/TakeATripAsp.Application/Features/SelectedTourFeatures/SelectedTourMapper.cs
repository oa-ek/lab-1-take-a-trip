using AutoMapper;
using TakeTripAsp.Application.Features.SelectedTourFeatures.SelectedTourDtos;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Application.Features.SelectedTourFeatures
{
    public class SelectedTourMapper : Profile
    {
        public SelectedTourMapper()
        {
            CreateMap<SelectedTour, CreateSelectedTourDto>();
            CreateMap<CreateSelectedTourDto, SelectedTour>();

            CreateMap<SelectedTour, ReadSelectedTourDto>();
            CreateMap<ReadSelectedTourDto, SelectedTour>();
        }
    }
}
