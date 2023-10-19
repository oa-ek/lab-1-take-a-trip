using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using TakeTripAsp.Core.Entity;
using TakeTripAsp.Repository;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TakeTripAsp.WebApp.Controllers
{
    public class ProfileController : Controller
    {
        public readonly IRepository<Profile, int> repository;
        public readonly IWebHostEnvironment webHostEnvironment;

        public ProfileController(IRepository<Profile, int> repository, 
            IWebHostEnvironment webHostEnvironment)
        {
            this.repository = repository;
            this.webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View(repository.GetAll());
        }

        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(Profile model)
        {
            if (ModelState.IsValid)
            {
                var profile = new Profile { UserId = "", DateOfBirth = model.DateOfBirth};
                               
                string wwwRootPath = webHostEnvironment.WebRootPath;

                string fileName = Path.GetFileNameWithoutExtension(model.CoverFile.FileName);

                string extension = Path.GetExtension(model.CoverFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                profile.CoverPath = "/img/profile/" + fileName;
                string path = Path.Combine(wwwRootPath + "/img/profile/", fileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    model.CoverFile.CopyTo(fileStream);
                }

                repository.Create(profile);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            return View(repository.Get(id));
        }

        [HttpPost]
        public IActionResult Delete(Profile profile)
        {
            repository.Delete(profile);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            return View(repository.Get(id));
        }

        [HttpPost]
        public IActionResult Edit(Profile model)
        {
            var profile = repository.Get(model.Id);

            string wwwRootPath = webHostEnvironment.WebRootPath;

            string fileName = Path.GetFileNameWithoutExtension(model.CoverFile.FileName);

            string extension = Path.GetExtension(model.CoverFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            profile.CoverPath = "/img/profile/" + fileName;
            string path = Path.Combine(wwwRootPath + "/img/profile/", fileName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                model.CoverFile.CopyTo(fileStream);
            }

            repository.Update(profile);
            return RedirectToAction("Index");
        }
    }
}
