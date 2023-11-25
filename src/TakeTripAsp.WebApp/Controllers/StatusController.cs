//using Microsoft.AspNetCore.Mvc;
//using TakeTripAsp.Domain.Entity;
//using TakeTripAsp.Repository;

//namespace TakeTripAsp.WebApp.Controllers
//{
//    public class StatusController : Controller
//    {
//        private readonly IRepository<Status, int> repository;

//        public StatusController(IRepository<Status, int> repository)
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
//        public IActionResult Create(Status model)
//        {
//            if (ModelState.IsValid)
//            {
//                var status = new Status { StatusName = model.StatusName };
//                repository.Create(status);
//                return RedirectToAction("Index");
//            }
//            return View();
//        }

//        public IActionResult Delete(int id)
//        {
//            return View(repository.Get(id));
//        }

//        [HttpPost]
//        public IActionResult Delete(Status status)
//        {
//            repository.Delete(status);

//            return RedirectToAction("Index");
//        }

//        public IActionResult Edit(int id)
//        {
//            return View(repository.Get(id));
//        }

//        [HttpPost]
//        public IActionResult Edit(Status status)
//        {
//            repository.Update(status);

//            return RedirectToAction("Index");
//        }
//    }
//}
