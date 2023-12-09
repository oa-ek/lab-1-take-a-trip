using MediatR;
using Microsoft.AspNetCore.Mvc;
using TakeTripAsp.Application.Features.BookingFeatures.BookingsDtos;
using TakeTripAsp.Application.Features.BookingFeatures.Commands.CreateBookings;
using TakeTripAsp.Application.Features.BookingFeatures.Commands.DeleteBookings;
using TakeTripAsp.Application.Features.BookingFeatures.Commands.UpdateBookings;
using TakeTripAsp.Application.Features.BookingFeatures.Queries.GetAllBookings;


namespace TakeTripAsp.WebApp.Controllers
{

    public class BookingsController : Controller
    {
        private readonly IMediator _mediator;

        public BookingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var bookings = await _mediator.Send(new GetAllBookingsQueries());
            return View(bookings);
        }

        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBookingsDto dto)
        {
            await _mediator.Send(new CreateBookingsCommand
            {
                IsFullPayment = dto.IsFullPayment,
                Payment = dto.Payment,
                ClientId = dto.ClientId,
                TourId = dto.TourId,
                BookingStatusId = dto.BookingStatusId
            });

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var booking = new ReadBookingsDto
            {
                Id = id
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
            var booking = new ReadBookingsDto
            {
                Id = id
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
                Payment = dto.Payment,
                ClientId = dto.ClientId,
                TourId = dto.TourId,
                BookingStatusId = dto.BookingStatusId
            });

            return RedirectToAction("Index");
        }
    }
}

//    public class BookingsController : Controller
//    {
//        private readonly IRepository<Bookings, int> bookingsrepository;
//        private readonly IRepository<Tour, int> tourrepository;
//        private readonly IRepository<BookingStatus, int> bookingstatusreposotory;
//        private readonly UserManager<AppUser> _userManager;

//        public BookingsController(IRepository<Tour, int> repository,
//            IRepository<Bookings, int> bookingsrepository,
//            IRepository<BookingStatus, int> bookingstatusreposotory,
//            UserManager<AppUser> userManager)
//        {
//            this.tourrepository = repository;
//            this.bookingsrepository = bookingsrepository;
//            this.bookingstatusreposotory = bookingstatusreposotory;
//            this._userManager = userManager;

//        }
//        public IActionResult Index()
//        {
//            return View(bookingsrepository.GetAll());
//        }

//        public IActionResult Create()
//        {
//            ViewBag.Status = bookingstatusreposotory.GetAll();
//            ViewBag.Tours = tourrepository.GetAll();
//            return View("Create");
//        }

//        [HttpPost]
//        public IActionResult Create(Bookings model, int tourId, int statusId)
//        {
//            var userId = _userManager.GetUserId(User);
//            var booking = new Bookings
//            {
//                IsFullPayment = model.IsFullPayment,
//                ClientId = userId,
//                BookingStatusId = statusId,
//                TourId = tourId,
//            };
//            if (booking.IsFullPayment)
//            {
//                booking.Payment = tourrepository.Get(booking.TourId).FullPrice;
//            }
//            else
//            {
//                booking.Payment = tourrepository.Get(booking.TourId).BookingPrice;
//            }
//            bookingsrepository.Create(booking);
//            return RedirectToAction("Index");
//        }


//        public IActionResult Delete(int id)
//        {
//            return View(bookingsrepository.Get(id));
//        }

//        [HttpPost]
//        public IActionResult Delete(Bookings booking)
//        {
//            bookingsrepository.Delete(booking);

//            return RedirectToAction("Index");
//        }

//        public IActionResult Edit(int id)
//        {
//            ViewBag.Tours = tourrepository.GetAll();
//            ViewBag.Status = bookingstatusreposotory.GetAll();
//            return View(bookingsrepository.Get(id));
//        }

//        [HttpPost]
//        public IActionResult Edit(Bookings model, int tourId, int statusId)
//        {
//            var existingBooking = bookingsrepository.Get(model.Id);

//            if (existingBooking == null)
//            {
//                return NotFound();
//            }

//            existingBooking.IsFullPayment = model.IsFullPayment;
//            existingBooking.TourId = tourId;
//            existingBooking.BookingStatusId = statusId;

//            bookingsrepository.Update(existingBooking);

//            return RedirectToAction("Index");
//        }
//    }
//}
