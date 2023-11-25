//using Microsoft.AspNetCore.Mvc;
//using TakeTripAsp.Domain.Entity;
//using TakeTripAsp.Repository;

//namespace TakeTripAsp.WebApp.Controllers
//{
//    public class BookingStatusController : Controller
//    {
//        private readonly IRepository<BookingStatus, int> repository;

//        public BookingStatusController(IRepository<BookingStatus, int> repository)
//        {
//            this.repository = repository;
//        }
//        public IActionResult Index()
//        {
//            return View(repository.GetAll());
//        }

//        public IActionResult Create()
//        {
//            return View("Create");
//        }

//        [HttpPost]
//        public IActionResult Create(BookingStatus model)
//        {
//            if (ModelState.IsValid)
//            {
//                var bookingStatus = new BookingStatus { BookingStatusName = model.BookingStatusName };
//                repository.Create(bookingStatus);
//                return RedirectToAction("Index");
//            }
//            return View();
//        }

//        public IActionResult Delete(int id)
//        {
//            return View(repository.Get(id));
//        }

//        [HttpPost]
//        public IActionResult Delete(BookingStatus bookingStatus)
//        {
//            repository.Delete(bookingStatus);

//            return RedirectToAction("Index");
//        }

//        public IActionResult Edit(int id)
//        {
//            return View(repository.Get(id));
//        }

//        [HttpPost]
//        public IActionResult Edit(BookingStatus bookingStatus)
//        {
//            repository.Update(bookingStatus);

//            return RedirectToAction("Index");
//        }
//    }


//}
