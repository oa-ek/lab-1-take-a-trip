using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TakeTripAsp.Application.Features.AppUserFeatures.Queries.GetAllAppUser;
using TakeTripAsp.Application.Features.BookingFeatures.BookingsDtos;
using TakeTripAsp.Application.Features.BookingFeatures.Commands.CreateBookings;
using TakeTripAsp.Application.Features.BookingFeatures.Commands.DeleteBookings;
using TakeTripAsp.Application.Features.BookingFeatures.Commands.UpdateBookings;
using TakeTripAsp.Application.Features.BookingFeatures.Queries.GetAllBookings;
using TakeTripAsp.Application.Features.BookingStatusFeatures.Queries.GetAllBookingStatus;
using TakeTripAsp.Application.Features.TourFeatures.Queries.GetAllTour;
using TakeTripAsp.Application.Features.TourFeatures.Queries.GetTour;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.WebApp.Controllers
{

    public class BookingsController : Controller
    {
        private readonly IMediator _mediator;
        private readonly UserManager<AppUser> _userManager;

        public BookingsController(IMediator mediator, UserManager<AppUser> userManager)
        {
            _mediator = mediator;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Tours = await _mediator.Send(new GetAllTourQueries());
            ViewBag.Users = await _mediator.Send(new GetAllAppUserQueries());
            ViewBag.BookingStatuses = await _mediator.Send(new GetAllBookingStatusQueries());
            var bookings = await _mediator.Send(new GetAllBookingsQueries());
            return View(bookings);
        }

        public async Task<IActionResult> Create(int id)
        {
            ViewBag.Tours = await _mediator.Send(new GetAllTourQueries());
            ViewBag.BookingStatuses = await _mediator.Send(new GetAllBookingStatusQueries());

            var tour = await _mediator.Send(new GetTourQueries { Id = id });

            var model = new CreateBookingsDto
            {
                TourId = tour.Id,
                TourName = tour.Name,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBookingsDto dto)
        {
            var userId = _userManager.GetUserId(User);

            await _mediator.Send(new CreateBookingsCommand
            {
                IsFullPayment = dto.IsFullPayment,
                ClientId = userId,
                TourId = dto.TourId,
            });

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Delete(int id, int Payment, string ClientId, int TourId)
        {
            ViewBag.Tours = await _mediator.Send(new GetAllTourQueries());

            var booking = new ReadBookingsDto
            {
                Id = id,
                Payment = Payment,
                ClientId = ClientId,
                TourId = TourId
            };

            return View(booking);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ReadBookingsDto dto)
        {
            await _mediator.Send(new DeleteBookingsCommand
            {
                Id = dto.Id
            });

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Tours = await _mediator.Send(new GetAllTourQueries());
            ViewBag.BookingStatuses = await _mediator.Send(new GetAllBookingStatusQueries());
            var booking = new ReadBookingsDto
            {
                Id = id,
            };

            return View(booking);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ReadBookingsDto dto)
        {
            await _mediator.Send(new UpdateBookingsCommand
            {
                Id = dto.Id,
                IsFullPayment = dto.IsFullPayment,
                BookingStatusId = dto.BookingStatusId
            });

            return RedirectToAction("Index");
        }
    }
}