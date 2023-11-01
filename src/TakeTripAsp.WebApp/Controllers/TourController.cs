using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TakeTripAsp.Core.Entity;
using TakeTripAsp.Repository;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TakeTripAsp.WebApp.Controllers
{
    public class TourController : Controller
    {
        private readonly IRepository<Tour, int> repository;
        private readonly IRepository<Category, int> categoryrepository;
        private readonly IRepository<Status, int> statusrepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly IWebHostEnvironment webHostEnvironment;

        public TourController(IRepository<Tour, int> repository,
            IRepository<Category, int> categoryrepository,
            IWebHostEnvironment webHostEnvironment,
            IRepository<Status, int> statusrepository,
            UserManager<AppUser> _userManager)
        {
            this.repository = repository;
            this.categoryrepository = categoryrepository;
            this.webHostEnvironment = webHostEnvironment;
            this.statusrepository = statusrepository;
            this._userManager = _userManager;
        }
        public IActionResult Index()
        {
            return View(repository.GetAll());
        }

        public IActionResult Create()
        {
            ViewBag.Categories = categoryrepository.GetAll();
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(Tour model, List<int> selectedCategories)
        {
            var userId = _userManager.GetUserId(User);
            var tour = new Tour
            {
                Name = model.Name,
                Description = model.Description,
                Continent = model.Continent,
                City = model.City,
                Start = model.Start,
                End = model.End,
                FullPrice = model.FullPrice,
                BookingPrice = model.BookingPrice,
                StatusId = 1,
                ManagerId = userId
            };

            List<Category> categories = new List<Category>();

            foreach (int id in selectedCategories)
            {
                categories.Add(categoryrepository.Get(id));
            }

            tour.Categories = categories;

            string wwwRootPath = webHostEnvironment.WebRootPath;

            string fileName = Path.GetFileNameWithoutExtension(model.CoverFile.FileName);

            string extension = Path.GetExtension(model.CoverFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            tour.CoverPath = "/img/tour/" + fileName;
            string path = Path.Combine(wwwRootPath + "/img/tour/", fileName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                model.CoverFile.CopyTo(fileStream);
            }

            repository.Create(tour);
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            return View(repository.Get(id));
        }

        [HttpPost]
        public IActionResult Delete(Tour tour)
        {
            repository.Delete(tour);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var tour = repository.Get(id);
            ViewBag.Statuses = statusrepository.GetAll();
            ViewBag.Categories = categoryrepository.GetAll();
            return View(repository.Get(id));
        }

        [HttpPost]
        public IActionResult Edit(Tour model, List<int> selectedCategories)
        {
            var existingTour = repository.Get(model.Id);
            var userId = _userManager.GetUserId(User);

            existingTour.Name = model.Name;
            existingTour.Description = model.Description;
            existingTour.Continent = model.Continent;
            existingTour.City = model.City;
            existingTour.Start = model.Start;
            existingTour.End = model.End;
            existingTour.FullPrice = model.FullPrice;
            existingTour.StatusId = model.StatusId;
            existingTour.BookingPrice = model.BookingPrice;
            existingTour.ManagerId = userId;


            List<Category> categories = new List<Category>();
            existingTour.Categories.Clear();
            foreach (int categoryId in selectedCategories)
            {
                categories.Add(categoryrepository.Get(categoryId));
            }
            existingTour.Categories = categories;

            
            if (model.CoverFile != null)
            {
                string wwwRootPath = webHostEnvironment.WebRootPath;

                string fileName = Path.GetFileNameWithoutExtension(model.CoverFile.FileName);

                string extension = Path.GetExtension(model.CoverFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                existingTour.CoverPath = "/img/profile/" + fileName;
                string path = Path.Combine(wwwRootPath + "/img/profile/", fileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    model.CoverFile.CopyTo(fileStream);
                }
            }

            repository.Update(existingTour);

            return RedirectToAction("Index");
        }
    }
}
