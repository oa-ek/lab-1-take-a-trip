using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TakeTripAsp.Core.Entity;
using TakeTripAsp.Repository;

namespace TakeTripAsp.WebApp.Controllers
{
    public class SelectedTourController : Controller
    {
        private readonly IRepository<SelectedTour, int> repository;
        private readonly IRepository<Tour, int> tourrepository;
        private readonly UserManager<AppUser> _userManager;


        public SelectedTourController(IRepository<SelectedTour, int> repository,
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
        public IActionResult Create(SelectedTour model, int tourId)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);
                var selectedtour = new SelectedTour
                {
                    UserId = userId,
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
