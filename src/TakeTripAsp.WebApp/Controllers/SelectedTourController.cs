using MediatR;
using Microsoft.AspNetCore.Mvc;
using TakeTripAsp.Application.Features.SelectedTourFeatures.Commands.CreateSelectedTour;
using TakeTripAsp.Application.Features.SelectedTourFeatures.Commands.DeleteSelectedTour;
using TakeTripAsp.Application.Features.SelectedTourFeatures.Commands.UpdateSelectedTour;
using TakeTripAsp.Application.Features.SelectedTourFeatures.Queries.GetAllSelectedTour;
using TakeTripAsp.Application.Features.SelectedTourFeatures.SelectedTourDtos;

namespace TakeTripAsp.WebApp.Controllers
{
    public class SelectedTourController : Controller
    {
        private readonly IMediator _mediator;

        public SelectedTourController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _mediator.Send(new GetAllSelectedTourQueries()));
        }

        public async Task<IActionResult> Create()
        {
            //// Assuming you want to pass the list of tours to the view
            //var tours = await _mediator.Send(new GetAllTourQueries());
            //ViewBag.Tours = tours;

            return View("Create");
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSelectedTourDto dto)
        {
            await _mediator.Send(new CreateSelectedTourCommand
            {
                TourId = dto.TourId,
                UserId = dto.UserId
            });

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            //var selectedTour = await _mediator.Send(new GetSelectedTourQuery { Id = id });
            return View("selectedTour");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ReadSelectedTourDto dto)
        {
            await _mediator.Send(new DeleteSelectedTourCommand
            {
                Id = dto.Id
            });

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            //var selectedTour = await _mediator.Send(new GetSelectedTourQuery { Id = id });
            return View("selectedTour");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ReadSelectedTourDto dto)
        {
            await _mediator.Send(new UpdateSelectedTourCommand
            {
                Id = dto.Id,
                TourId = dto.TourId,
                UserId = dto.UserId
            });

            return RedirectToAction("Index");
        }
    }
}
//    public class SelectedTourController : Controller
//    {
//        private readonly IRepository<SelectedTour, int> repository;
//        private readonly IRepository<Tour, int> tourrepository;
//        private readonly UserManager<AppUser> _userManager;


//        public SelectedTourController(IRepository<SelectedTour, int> repository,
//            IRepository<Tour, int> tourrepository,
//            UserManager<AppUser> userManager)
//        {
//            this.repository = repository;
//            this.tourrepository = tourrepository;
//            this._userManager = userManager;
//        }
//        public IActionResult Index()
//        {
//            return View(repository.GetAll());
//        }

//        public IActionResult Create()
//        {
//            ViewBag.Tours = tourrepository.GetAll();
//            return View("Create");
//        }

//        [HttpPost]
//        public IActionResult Create(SelectedTour model, int tourId)
//        {
//            if (ModelState.IsValid)
//            {
//                var userId = _userManager.GetUserId(User);
//                var selectedtour = new SelectedTour
//                {
//                    UserId = userId,
//                    TourId = tourId
//                };
//                repository.Create(selectedtour);
//                return RedirectToAction("Index");
//            }
//            return View();
//        }

//        public IActionResult Delete(int id)
//        {
//            return View(repository.Get(id));
//        }

//        [HttpPost]
//        public IActionResult Delete(SelectedTour selectedtour)
//        {
//            repository.Delete(selectedtour);

//            return RedirectToAction("Index");
//        }
//    }
//}
