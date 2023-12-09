using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeTripAsp.Application.Repository;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Application.Features.ReviewsFeatures.Commands.DeleteReviews
{
    public class DeleteReviewsCommandHandler
        : IRequestHandler<DeleteReviewsCommand, int>
    {
                protected readonly IBaseRepository<Reviews, int> _reviewsrepository;

        public DeleteReviewsCommandHandler(IBaseRepository<Reviews, int> repository ) 
        { 
            _reviewsrepository = repository;
        }

        public async Task<int> Handle( 
            DeleteReviewsCommand request,
            CancellationToken cancellationToken)
        {
            var reviews = await _reviewsrepository.GetAsync(request.Id);

            await _reviewsrepository.DeleteAsync(reviews);

            return reviews.Id;
        }
    }
}
