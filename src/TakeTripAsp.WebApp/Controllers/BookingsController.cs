using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using System.Security.Claims;
using TakeTripAsp.Core.Entity;
using TakeTripAsp.Repository;

namespace TakeTripAsp.WebApp.Controllers
{
    public class BookingsController : Controller
    {
        public readonly IRepository<Bookings, int> bookingsrepository;
        public readonly IRepository<Tour, int> tourrepository;
        public readonly IRepository<BookingStatus, int> bookingstatusreposotory;
        private readonly UserManager<AppUser> _userManager;

        public BookingsController(IRepository<Tour, int> repository,
            IRepository<Bookings, int> bookingsrepository,
            IRepository<BookingStatus, int> bookingstatusreposotory,
            UserManager<AppUser> userManager)
        {
            this.tourrepository = repository;
            this.bookingsrepository = bookingsrepository;
            this.bookingstatusreposotory = bookingstatusreposotory;
            this._userManager = userManager;

        }
        public IActionResult Index()
        {
            return View(bookingsrepository.GetAll());
        }

        public IActionResult Create()
        {
            ViewBag.Status = bookingstatusreposotory.GetAll();
            ViewBag.Tours = tourrepository.GetAll();
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(Bookings model, int tourId, int statusId)
        {
            var userId = _userManager.GetUserId(User);
            var booking = new Bookings
            {
                IsFullPayment = model.IsFullPayment,
                ClientId = userId,
                BookingStatusId = statusId,
                TourId = tourId,
            };
            if (booking.IsFullPayment)
            {
                booking.Payment = tourrepository.Get(booking.TourId).FullPrice;
            }
            else
            {
                booking.Payment = tourrepository.Get(booking.TourId).BookingPrice;
            }
            bookingsrepository.Create(booking);
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            return View(bookingsrepository.Get(id));
        }

        [HttpPost]
        public IActionResult Delete(Bookings booking)
        {
            bookingsrepository.Delete(booking);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Tours = tourrepository.GetAll();
            ViewBag.Status = bookingstatusreposotory.GetAll();
            return View(bookingsrepository.Get(id));
        }

        [HttpPost]
        public IActionResult Edit(Bookings model, int tourId, int statusId)
        {
            var existingBooking = bookingsrepository.Get(model.Id);

            if (existingBooking == null)
            {
                return NotFound();
            }

            existingBooking.IsFullPayment = model.IsFullPayment;
            existingBooking.TourId = tourId;
            existingBooking.BookingStatusId = statusId;

            bookingsrepository.Update(existingBooking);

            return RedirectToAction("Index");
        }
    }
}
