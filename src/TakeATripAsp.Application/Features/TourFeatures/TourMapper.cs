using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
