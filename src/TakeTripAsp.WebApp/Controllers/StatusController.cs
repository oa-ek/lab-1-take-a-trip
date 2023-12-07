using MediatR;
using Microsoft.AspNetCore.Mvc;
using TakeTripAsp.Application.Features.StatusFeatures.Commands.CreateStatus;
using TakeTripAsp.Application.Features.StatusFeatures.Commands.DeleteStatus;
using TakeTripAsp.Application.Features.StatusFeatures.Commands.UpdateStatus;
using TakeTripAsp.Application.Features.StatusFeatures.Queries.GetAllStatus;
using TakeTripAsp.Application.Features.StatusFeatures.StatusDtos;


namespace TakeTripAsp.WebApp.Controllers
{
    public class StatusController : Controller
    {
        private readonly IMediator _mediator;

        public StatusController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _mediator.Send(new GetAllStatusQueries()));
        }

        public async Task<IActionResult> Create()
        {
            return View("Create");
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateStatusDto dto)
        {
            await _mediator.Send(new CreateStatusCommand
            {
                Name = dto.Name
            });

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id, string name)
        {
            var status = new ReadStatusDto
            {
                Id = id,
                Name = name
            };

            return View(status);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ReadStatusDto dto)
        {
            await _mediator.Send(new DeleteStatusCommand
            {
                Id = dto.Id
            });

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id, string name)
        {
            var status = new ReadStatusDto
            {
                Id = id,
                Name = name
            };

            return View(status);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ReadStatusDto dto)
        {
            await _mediator.Send(new UpdateStatusCommand
            {
                Id = dto.Id,
                StatusName = dto.Name
            });

            return RedirectToAction("Index");
        }
    }
}