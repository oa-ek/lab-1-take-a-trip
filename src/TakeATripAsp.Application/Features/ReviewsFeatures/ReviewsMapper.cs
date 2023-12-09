using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeTripAsp.Application.Features.ReviewsFeatures.ReviewsDtos;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Application.Features.ReviewsFeatures
{
    public class ReviewsMapper: Profile
    {
        public ReviewsMapper()
        {
            CreateMap<Reviews, CreateReviewsDto>();
            CreateMap<CreateReviewsDto, Reviews>();

            CreateMap<Reviews, ReadReviewsDto>();
            CreateMap<ReadReviewsDto, Reviews>();
        }
    }
}
