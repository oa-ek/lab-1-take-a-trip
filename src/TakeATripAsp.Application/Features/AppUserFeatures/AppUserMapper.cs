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
            CreateMap<ReadAppUserDto, AppUser>();
            CreateMap<AppUser, ReadAppUserDto>();

            CreateMap<CreateAppUserDto, AppUser>();
            CreateMap<AppUser, CreateAppUserDto>();
        }
    }
}
