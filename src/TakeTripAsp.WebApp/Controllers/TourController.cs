using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TakeTripAsp.Application.Features.CategoryFeatures.Queries.GetAllCategory;
using TakeTripAsp.Application.Features.CityFeatures.Queries.GetAllCity;
using TakeTripAsp.Application.Features.StatusFeatures.Queries.GetAllStatus;
using TakeTripAsp.Application.Features.TourFeatures.Commands.CreateTour;
using TakeTripAsp.Application.Features.TourFeatures.Commands.DeleteTour;
using TakeTripAsp.Application.Features.TourFeatures.Commands.UpdateTour;
using TakeTripAsp.Application.Features.TourFeatures.Queries.GetAllTour;
using TakeTripAsp.Application.Features.TourFeatures.TourDtos;
using TakeTripAsp.Application.Features.TourFeatures.Queries.GetTour;
using TakeTripAsp.Domain.Entity;
using TakeTripAsp.Application.Features.SelectedTourFeatures.Commands.CreateSelectedTour;
using TakeTripAsp.Application.Features.SelectedTourFeatures.Commands.DeleteSelectedTour;
using TakeTripAsp.Application.Features.TourFeatures.Queries.GetTourCities;

namespace TakeTripAsp.WebApp.Controllers
{
    public class TourController : Controller
    {
        private readonly IMediator _mediator;
        private readonly UserManager<AppUser> _userManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly HttpClient _httpClient;

        public TourController(
            IMediator mediator,
            IWebHostEnvironment webHostEnvironment,
            HttpClient httpClient,
            UserManager<AppUser> userManager)
        {
            _mediator = mediator;
            _webHostEnvironment = webHostEnvironment;
            _httpClient = httpClient;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Categories = await _mediator.Send(new GetAllCatagoryQueries());
            ViewBag.Cities = await _mediator.Send(new GetAllCityQueries());
            ViewBag.Statuses = await _mediator.Send(new GetAllStatusQueries());

            var tours = await _mediator.Send(new GetAllTourQueries());

            return View(tours);
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
                Start = model.Start,
                End = model.End,
                FullPrice = model.FullPrice,
                BookingPrice = model.BookingPrice,
                StatusId = model.StatusId,
                ManagerId = userId,
                CategoryIds = model.CategoryIds,
                wwwRootPath = wwwRootPath,
                CoverFile = model.CoverFile,
                CityIds = model.CityIds,
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
        public async Task<IActionResult> Edit(UpdateTourDto model)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;

            await _mediator.Send(new UpdateTourCommand
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Start = model.Start,
                End = model.End,
                FullPrice = model.FullPrice,
                BookingPrice = model.BookingPrice,
                StatusId = model.StatusId,
                CategoryIds = model.CategoryIds,
                wwwRootPath = wwwRootPath,
                CoverFile = model.CoverFile,
                CityIds = model.CityIds
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

            var existingSelectedTour = user.SelectedTours.FirstOrDefault(st => st.TourId == id);

            if (existingSelectedTour != null)
            {
                await _mediator.Send(new DeleteSelectedTourCommand { Id = existingSelectedTour.Id });
            }
            else
            {
                await _mediator.Send(new CreateSelectedTourCommand { TourId = id, UserId = userId });
            }

            return RedirectToAction("Index", "Tour");
        }

        public async Task<IActionResult> Maps(int id)
        {
            return View(await _mediator.Send(new GetTourCitiesQueries { Id = id, httpClient = _httpClient }));
        }

    }
}