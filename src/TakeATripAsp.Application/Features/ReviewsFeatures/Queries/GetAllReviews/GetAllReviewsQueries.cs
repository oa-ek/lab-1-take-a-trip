using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeTripAsp.Application.Features.ReviewsFeatures.ReviewsDtos;

namespace TakeTripAsp.Application.Features.ReviewsFeatures.Queries.GetAllReviews
{
    public class GetAllReviewsQueries
        : IRequest<IEnumerable<ReadReviewsDto>>
    { }

}
