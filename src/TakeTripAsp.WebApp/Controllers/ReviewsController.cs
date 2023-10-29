using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TakeTripAsp.Core.Entity;
using TakeTripAsp.Repository;

namespace TakeTripAsp.WebApp.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly IRepository<Reviews, int> repository;
        private readonly IRepository<Tour, int> tourrepository;
        private readonly UserManager<AppUser> _userManager;

        public ReviewsController(IRepository<Reviews, int> repository,
            IRepository<Tour, int> tourrepository,
            UserManager<AppUser> userManager)
        {
            this.repository = repository;
            this.tourrepository = tourrepository;
            this._userManager = userManager;
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
            var userId = _userManager.GetUserId(User);

            var reviews = new Reviews
            {
                Comment = model.Comment,
                ClientId = userId,
                TourId = tourId
            };
            repository.Create(reviews);
            return RedirectToAction("Index");

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