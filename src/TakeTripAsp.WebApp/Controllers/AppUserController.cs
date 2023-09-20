using Microsoft.AspNetCore.Mvc;
using TakeTripAsp.Core.Entity;
using TakeTripAsp.Repository;

namespace TakeTripAsp.WebApp.Controllers
{
    public class AppUserController : Controller
    {
        public readonly IRepository<AppUser, int> repository;

        public AppUserController(IRepository<AppUser, int> repository)
        {
            this.repository = repository;
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
        public IActionResult Create(AppUser model)
        {
            if (ModelState.IsValid)
            {
                var appUser = new AppUser { Name = model.Name };
                repository.Create(appUser);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            return View(repository.Get(id));
        }

        [HttpPost]
        public IActionResult Delete(AppUser appUser)
        {
            repository.Delete(appUser);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            return View(repository.Get(id));
        }

        [HttpPost]
        public IActionResult Edit(AppUser appUser)
        {
            repository.Update(appUser);

            return RedirectToAction("Index");
        }
    }
}
