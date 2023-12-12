using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TakeTripAsp.Application.Features.CategoryFeatures.Queries.GetAllCategory;
using TakeTripAsp.Application.Features.CityFeatures.Queries.GetAllCity;
using TakeTripAsp.Application.Features.StatusFeatures.Queries.GetAllStatus;
using TakeTripAsp.Application.Features.Tourfeatures.Commands.CreateTour;
using TakeTripAsp.Application.Features.Tourfeatures.Commands.DeleteTour;
using TakeTripAsp.Application.Features.Tourfeatures.Commands.UpdateTour;
using TakeTripAsp.Application.Features.Tourfeatures.Queries.GetAllTour;
using TakeTripAsp.Application.Features.Tourfeatures.TourDtos;
using TakeTripAsp.Application.Features.TourFeatures.Queries.GetTour;
using TakeTripAsp.Application.Features.TourFeatures.TourDtos;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.WebApp.Controllers
{
    public class TourController : Controller
    {
        private readonly IMediator _mediator;
        private readonly UserManager<AppUser> _userManager;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public TourController(
            IMediator mediator,
            IWebHostEnvironment webHostEnvironment,
            UserManager<AppUser> userManager)
        {
            _mediator = mediator;
            _webHostEnvironment = webHostEnvironment;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _mediator.Send(new GetAllTourQueries()));
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _mediator.Send(new GetAllCatagoryQueries());
            ViewBag.Cities = await _mediator.Send(new GetAllCityQueries());
            ViewBag.Statuses = await _mediator.Send(new GetAllStatusQueries());

            return View("Create");
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTourDto model)
        {
            var userId = _userManager.GetUserId(User);

            string wwwRootPath = _webHostEnvironment.WebRootPath;

            await _mediator.Send(new CreateTourCommand
            {
                Name = model.Name,
                Description = model.Description,
                Continent = model.Continent,
                Start = model.Start,
                End = model.End,
                FullPrice = model.FullPrice,
                BookingPrice = model.BookingPrice,
                StatusId = model.StatusId,
                ManagerId = userId,
                CategoryIds = model.CategoryIds,
                wwwRootPath = wwwRootPath,
                CoverFile = model.CoverFile,
                CityId = model.CityId
            });

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _mediator.Send(new GetTourQueries { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ReadTourDto model)
        {
            await _mediator.Send(new DeleteTourCommand { Id = model.Id });
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Categories = await _mediator.Send(new GetAllCatagoryQueries());
            ViewBag.Cities = await _mediator.Send(new GetAllCityQueries());
            ViewBag.Statuses = await _mediator.Send(new GetAllStatusQueries());

            return View(await _mediator.Send(new GetTourQueries { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateTourDto model, List<int> selectedCategories)
        {
            var userId = _userManager.GetUserId(User);

            string wwwRootPath = _webHostEnvironment.WebRootPath;

            await _mediator.Send(new UpdateTourCommand
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Continent = model.Continent,
                Start = model.Start,
                End = model.End,
                FullPrice = model.FullPrice,
                BookingPrice = model.BookingPrice,
                StatusId = model.StatusId,
                CategoryIds = model.CategoryIds,
                wwwRootPath = wwwRootPath,
                CoverFile = model.CoverFile,
                CityId = model.CityId
            });

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> AddToSelectedTours(int id)
        {
            var userId = _userManager.GetUserId(User);

            var user = await _userManager.FindByIdAsync(userId);

            if (user.SelectedTours == null)
            {
                user.SelectedTours = new List<SelectedTour>();
            }

            if (user.SelectedTours.All(st => st.TourId != id))
            {
                var selectedTour = new SelectedTour
                {
                    TourId = id
                };

                user.SelectedTours.Add(selectedTour);
            }

            return RedirectToAction("Index", "Tour");
        }
    }
}