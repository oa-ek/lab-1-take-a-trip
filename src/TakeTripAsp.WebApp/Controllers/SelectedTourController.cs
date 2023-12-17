using MediatR;
using Microsoft.AspNetCore.Mvc;
using TakeTripAsp.Application.Features.SelectedTourFeatures.Commands.CreateSelectedTour;
using TakeTripAsp.Application.Features.SelectedTourFeatures.Commands.DeleteSelectedTour;
using TakeTripAsp.Application.Features.SelectedTourFeatures.Commands.UpdateSelectedTour;
using TakeTripAsp.Application.Features.SelectedTourFeatures.Queries.GetAllSelectedTour;
using TakeTripAsp.Application.Features.SelectedTourFeatures.SelectedTourDtos;

namespace TakeTripAsp.WebApp.Controllers
{
    public class SelectedTourController : Controller
    {
        private readonly IMediator _mediator;

        public SelectedTourController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _mediator.Send(new GetAllSelectedTourQueries()));
        }

        public async Task<IActionResult> Create()
        {
            return View("Create");
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSelectedTourDto dto)
        {
            await _mediator.Send(new CreateSelectedTourCommand
            {
                TourId = dto.TourId,
                UserId = dto.UserId
            });

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View("selectedTour");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ReadSelectedTourDto dto)
        {
            await _mediator.Send(new DeleteSelectedTourCommand
            {
                Id = dto.Id
            });

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View("selectedTour");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ReadSelectedTourDto dto)
        {
            await _mediator.Send(new UpdateSelectedTourCommand
            {
                Id = dto.Id,
                TourId = dto.TourId,
                UserId = dto.UserId
            });

            return RedirectToAction("Index");
        }
    }
}
