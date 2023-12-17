using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TakeTripAsp.Application.Features.AppUserFeatures.Queries.GetAllAppUser;
using TakeTripAsp.Application.Features.ReviewsFeatures.Commands.CreateReviews;
using TakeTripAsp.Application.Features.ReviewsFeatures.Commands.DeleteReviews;
using TakeTripAsp.Application.Features.ReviewsFeatures.Commands.UpdateReviews;
using TakeTripAsp.Application.Features.ReviewsFeatures.Queries.GetAllReviews;
using TakeTripAsp.Application.Features.ReviewsFeatures.ReviewsDtos;
using TakeTripAsp.Application.Features.TourFeatures.Queries.GetAllTour;
using TakeTripAsp.Application.Features.TourFeatures.Queries.GetTour;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.WebApp.Controllers
{ 
    public class ReviewsController : Controller
    {
        private readonly IMediator _mediator;
        private readonly UserManager<AppUser> _userManager;

        public ReviewsController(IMediator mediator, UserManager<AppUser> userManager)
        {
            _mediator = mediator;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Tours = await _mediator.Send(new GetAllTourQueries());
            ViewBag.Users = await _mediator.Send(new GetAllAppUserQueries());
            return View(await _mediator.Send(new GetAllReviewsQueries()));
        }

        public async Task<IActionResult> Create(int id)
        {
            ViewBag.Tours = await _mediator.Send(new GetAllTourQueries());

            var tour = await _mediator.Send(new GetTourQueries { Id = id });

            var model = new CreateReviewsDto
            {
                TourId = tour.Id,
                TourName = tour.Name,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateReviewsDto dto)
        {
            var userId = _userManager.GetUserId(User);

            await _mediator.Send(new CreateReviewsCommand
            {
                Comment = dto.Comment,
                TourId = dto.TourId,
                ClientId = userId
            });

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Delete(int id, string comment)
        {
            var category = new ReadReviewsDto
            {
                Id = id,
                Comment = comment
            };

            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ReadReviewsDto dto)
        {
            await _mediator.Send(new DeleteReviewsCommand
            {
                Id = dto.Id
            });

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Edit(int id, string comment)
        {
            ViewBag.Tours = await _mediator.Send(new GetAllTourQueries());

            var reviews = new ReadReviewsDto
            {
                Id = id,
                Comment = comment
            };

            return View(reviews);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(ReadReviewsDto dto)
        {
            await _mediator.Send(new UpdateReviewsCommand
            {
                Id = dto.Id,
                Comment = dto.Comment,
            });

            return RedirectToAction("Index");
        }
    }
}