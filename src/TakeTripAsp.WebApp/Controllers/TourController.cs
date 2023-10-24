using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TakeTripAsp.Core.Entity;
using TakeTripAsp.Repository;

namespace TakeTripAsp.WebApp.Controllers
{
    public class TourController : Controller
    {
        public readonly IRepository<Tour, int> repository;
        public readonly IRepository<Category, int> categoryrepository;
        public readonly IRepository<Status, int> statusrepository;
        public readonly IWebHostEnvironment webHostEnvironment;

        public TourController(IRepository<Tour, int> repository,
            IRepository<Category, int> categoryrepository,
            IWebHostEnvironment webHostEnvironment,
            IRepository<Status, int> statusrepository)
        {
            this.repository = repository;
            this.categoryrepository = categoryrepository;
            this.webHostEnvironment = webHostEnvironment;
            this.statusrepository = statusrepository;
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
            return View(repository.Get(id));
        }

        [HttpPost]
        public IActionResult Edit(Tour tour)
        {
            repository.Update(tour);

            return RedirectToAction("Index");
        }
    }
}
