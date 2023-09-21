using Microsoft.AspNetCore.Mvc;
using TakeTripAsp.Core.Entity;
using TakeTripAsp.Repository;

namespace TakeTripAsp.WebApp.Controllers
{
    public class ReviewsController : Controller
    {
        public readonly IRepository<Reviews, int> repository;
        public readonly IRepository<Tour, int> tourrepository;

        public ReviewsController(IRepository<Reviews, int> repository,
            IRepository<Tour, int> tourrepository)
        {
            this.repository = repository;
            this.tourrepository = tourrepository;
        }
        public IActionResult Index()
        {
            return View(repository.GetAll());
        }

        public IActionResult Create()
        {
            ViewBag.Tours = tourrepository.GetAll();
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(Reviews model, int tourId)
        {
            if (ModelState.IsValid)
            {
                var reviews = new Reviews
                {
                    Comment = model.Comment,
                    UserId = 1,
                    TourId = tourId
                };
                repository.Create(reviews);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            return View(repository.Get(id));
        }

        [HttpPost]
        public IActionResult Delete(Reviews reviews)
        {
            repository.Delete(reviews);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Tours = tourrepository.GetAll();
            return View(repository.Get(id));
        }

        [HttpPost]
        public IActionResult Edit(Reviews model, int tourId)
        {
            var existingReviews = repository.Get(model.Id);

            if (existingReviews == null)
            {
                return NotFound();
            }
            existingReviews.Comment = model.Comment;
            existingReviews.TourId = tourId;
            repository.Update(existingReviews);

            return RedirectToAction("Index");
        }
    }
}