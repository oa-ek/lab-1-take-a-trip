using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeTripAsp.Application.Features.AppUserFeatures.AppUserDto;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Application.Features.AppUserFeatures
{
    public class AppUserMapper: Profile
    {
        public AppUserMapper()
        {
            CreateMap<AppUser, ReadAppUserDto>()
                //.ForMember(dest => dest.Role, opt => opt.MapFrom(src => new List<string>()))
                .ForMember(dest => dest.IsConfirmed, opt => opt.MapFrom(src => src.EmailConfirmed));

            CreateMap<CreateAppUserDto, AppUser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.NormalizedUserName, opt => opt.MapFrom(src => src.Email.ToUpper()))
                .ForMember(dest => dest.NormalizedEmail, opt => opt.MapFrom(src => src.Email.ToUpper()))
                .ForMember(dest => dest.EmailConfirmed, opt => opt.MapFrom(src => true)); 

            CreateMap<AppUser, CreateAppUserDto>()
                .ForMember(dest => dest.Password, opt => opt.Ignore()); 
        }
    }
}
