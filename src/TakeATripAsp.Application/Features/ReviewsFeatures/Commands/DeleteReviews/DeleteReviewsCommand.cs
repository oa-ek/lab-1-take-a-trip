using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeTripAsp.Application.Features.ReviewsFeatures.Commands.DeleteReviews
{
    public class DeleteReviewsCommand
        : IRequest<int>
    {
        public int Id { get; set; }
    }
}
