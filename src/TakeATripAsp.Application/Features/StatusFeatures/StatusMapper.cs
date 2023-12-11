using AutoMapper;
using TakeTripAsp.Application.Features.StatusFeatures.StatusDtos;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Application.Features.StatusFeatures
{
    public class StatusMapper : Profile
    {
        public StatusMapper()
        {
            CreateMap<Status, CreateStatusDto>();
            CreateMap<CreateStatusDto, Status>();

            CreateMap<Status, ReadStatusDto>().ForMember(dest => dest.Name, act => act.MapFrom(src => src.StatusName));
            CreateMap<ReadStatusDto, Status>();
        }
    }

}




