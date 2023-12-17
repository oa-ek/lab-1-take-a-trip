using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeTripAsp.Application.Features.CategoryFeatures.CategoryDtos;
using TakeTripAsp.Application.Features.ReviewsFeatures.ReviewsDtos;

namespace TakeTripAsp.Application.Features.ReviewsFeatures.Commands.UpdateReviews
{
    public class UpdateReviewsCommand
        : IRequest<ReadReviewsDto>
    {
        public int Id { get; set; }

        public required string Comment { get; set; }

    }
}
