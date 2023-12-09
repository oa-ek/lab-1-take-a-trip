using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeTripAsp.Application.Features.CategoryFeatures.CategoryDtos;
using TakeTripAsp.Application.Features.ReviewsFeatures.ReviewsDtos;
using TakeTripAsp.Application.Repository;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Application.Features.ReviewsFeatures.Queries.GetAllReviews
{
    public class GetAllReviewsQueriesHandler
        : IRequestHandler<GetAllReviewsQueries, IEnumerable<ReadReviewsDto>>
    {
        protected readonly IBaseRepository<Reviews, int>? _reviewsRepository;
        protected readonly IMapper _mapper;

        public GetAllReviewsQueriesHandler(
            IBaseRepository<Reviews, int> repository,
            IMapper mapper)
        {
            (_reviewsRepository, _mapper) = (repository, mapper);
        }

        public async Task<IEnumerable<ReadReviewsDto>> Handle(
            GetAllReviewsQueries reguest,
            CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<Reviews>,
                IEnumerable<ReadReviewsDto>>(await _reviewsRepository.GetAllAsync());
        }
    }
}
