using MediatR;
using Microsoft.AspNetCore.Mvc;
using TakeTripAsp.Application.Features.BookingStatusFeatures.BookingStatusDtos;
using TakeTripAsp.Application.Features.BookingStatusFeatures.Commands.CreateBookingStatus;
using TakeTripAsp.Application.Features.BookingStatusFeatures.Commands.DeleteBookingStatus;
using TakeTripAsp.Application.Features.BookingStatusFeatures.Commands.UpdateBookingStatus;
using TakeTripAsp.Application.Features.BookingStatusFeatures.Queries.GetAllBookingStatus;


namespace TakeTripAsp.WebApp.Controllers
{
    public class BookingStatusController : Controller
    {
        private readonly IMediator _mediator;

        public BookingStatusController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _mediator.Send(new GetAllBookingStatusQueries()));
        }

        public async Task<IActionResult> Create()
        {
            return View("Create");
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateBookingStatusDto dto)
        {
            await _mediator.Send(new CreateBookingStatusCommand
            {
                Name = dto.Name
            });

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id, string name)
        {
            var bookingStatus = new ReadBookingStatusDto
            {
                Id = id,
                Name = name
            };

            return View(bookingStatus);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ReadBookingStatusDto dto)
        {
            await _mediator.Send(new DeleteBookingStatusCommand
            {
                Id = dto.Id
            });

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id, string name)
        {
            var bookingStatus = new ReadBookingStatusDto
            {
                Id = id,
                Name = name
            };

            return View(bookingStatus);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ReadBookingStatusDto dto)
        {
            await _mediator.Send(new UpdateBookingStatusCommand
            {
                Id = dto.Id,
                Name = dto.Name
            });

            return RedirectToAction("Index");
        }
    }
}

