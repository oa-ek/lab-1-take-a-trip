using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using TakeTripAsp.Application.Features.ReviewsFeatures.ReviewsDtos;
using TakeTripAsp.Application.Repository;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Application.Features.ReviewsFeatures.Commands.CreateReviews
{
    public class CreateReviewsCommandHandler
       : IRequestHandler<CreateReviewsCommand, CreateReviewsDto>
    {
        protected readonly IBaseRepository<Reviews, int> _reviewsRepository;
        protected readonly IUserRepository _appUserRepository;
        protected readonly IBaseRepository<Tour, int> _tourRepository;
        protected readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public CreateReviewsCommandHandler(
            IBaseRepository<Reviews, int> reviewsRepository,
            IUserRepository appUserRepository,
            IBaseRepository<Tour, int> tourRepository,
            IMapper mapper,
            UserManager<AppUser> userManager)
        {
            (_reviewsRepository, _appUserRepository, _tourRepository, _mapper, _userManager) =
                (reviewsRepository, appUserRepository, tourRepository, mapper, userManager);
        }

        public async Task<CreateReviewsDto> Handle(CreateReviewsCommand request, CancellationToken cancellationToken)
        {
            var client = await _appUserRepository.GetAsync(request.ClientId);
            var tour = await _tourRepository.GetAsync(request.TourId);

            var reviews = await _reviewsRepository.CreateAsync(new Reviews
            {
                Comment = request.Comment,
                //Client = client,
                Tour = tour
            });

            return _mapper.Map<Reviews, CreateReviewsDto>(reviews);
        }
    }
}
