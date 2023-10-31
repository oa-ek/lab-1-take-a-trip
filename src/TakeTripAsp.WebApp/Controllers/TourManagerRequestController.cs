using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TakeTripAsp.Core.Entity;
using TakeTripAsp.Repository;

namespace TakeTripAsp.WebApp.Controllers
{
    public class TourManagerRequestController : Controller
    {
        private readonly IRepository<TourManagerRequest, int> repository;
        private readonly UserManager<AppUser> _userManager;

        public TourManagerRequestController(IRepository<TourManagerRequest, int> repository,
          UserManager<AppUser> _userManager)
        {
            this.repository = repository;
            this._userManager = _userManager;
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
        public IActionResult Create(TourManagerRequest model)
        {
            var userId = _userManager.GetUserId(User);
            var tourManagerRequest = new TourManagerRequest
            {
                ClientId = userId,
                RequestDate = DateTime.Now,
                IsApproved = false,
                IsCompanyMember = model.IsCompanyMember,
                IsSeller = model.IsSeller,
            };
            repository.Create(tourManagerRequest);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            return View(repository.Get(id));
        }

        [HttpPost]
        public IActionResult Delete(TourManagerRequest request)
        {
            repository.Delete(request);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            return View(repository.Get(id));
        }

        [HttpPost]
        public IActionResult Edit(TourManagerRequest model)
        {
            var existingRequest = repository.Get(model.Id);
            var userId = _userManager.GetUserId(User);

            existingRequest.ClientId = userId;
            existingRequest.IsApproved = model.IsApproved;
            existingRequest.IsCompanyMember = model.IsCompanyMember;
            existingRequest.IsSeller = model.IsSeller;

            repository.Update(existingRequest);

            return RedirectToAction("Index");
        }
    }
}