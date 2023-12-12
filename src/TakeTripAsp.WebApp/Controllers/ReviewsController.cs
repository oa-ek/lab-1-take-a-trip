using MediatR;
using Microsoft.AspNetCore.Mvc;
using TakeTripAsp.Application.Features.ReviewsFeatures.Commands.CreateReviews;
using TakeTripAsp.Application.Features.ReviewsFeatures.Commands.DeleteReviews;
using TakeTripAsp.Application.Features.ReviewsFeatures.Commands.UpdateReviews;
using TakeTripAsp.Application.Features.ReviewsFeatures.Queries.GetAllReviews;
using TakeTripAsp.Application.Features.ReviewsFeatures.ReviewsDtos;

namespace TakeTripAsp.WebApp.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly IMediator _mediator;

        public ReviewsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _mediator.Send(new GetAllReviewsQueries()));
        }

        public async Task<IActionResult> Create()
        {
            return View("Create");
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateReviewsDto dto)
        {
            await _mediator.Send(new CreateReviewsCommand
            {
                //ClientId = dto.ClientId,
                Comment = dto.Comment,
                TourId = dto.TourId,
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
            var category = new ReadReviewsDto
            {
                Id = id,
                Comment = comment
            };

            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ReadReviewsDto dto)
        {
            await _mediator.Send(new UpdateReviewsCommand
            {
                Id = dto.Id,
                ClientId = dto.ClientId,
                Comment = dto.Comment,
                TourId = dto.TourId,
            });

            return RedirectToAction("Index");
        }
    }
}