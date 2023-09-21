using Microsoft.AspNetCore.Mvc;
using TakeTripAsp.Core.Entity;
using TakeTripAsp.Repository;

namespace TakeTripAsp.WebApp.Controllers
{
    public class SelectedTourController : Controller
    {
        public readonly IRepository<SelectedTour, int> repository;
        public readonly IRepository<Tour, int> tourrepository;

        public SelectedTourController(IRepository<SelectedTour, int> repository,
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
        public IActionResult Create(SelectedTour model, int tourId)
        {
            if (ModelState.IsValid)
            {
                var selectedtour = new SelectedTour
                {
                    UserId = 1,
                    TourId = tourId
                };
                repository.Create(selectedtour);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            return View(repository.Get(id));
        }

        [HttpPost]
        public IActionResult Delete(SelectedTour selectedtour)
        {
            repository.Delete(selectedtour);

            return RedirectToAction("Index");
        }


    }
}
