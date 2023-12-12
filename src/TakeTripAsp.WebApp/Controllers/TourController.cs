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
//    public class TourController : Controller
//    {
//        private readonly IRepository<Tour, int> repository;
//        private readonly IRepository<Category, int> categoryrepository;
//        private readonly IRepository<Status, int> statusrepository;
//        private readonly IRepository<SelectedTour, int> selectrepository;
//        private readonly UserManager<AppUser> _userManager;
//        private readonly IWebHostEnvironment webHostEnvironment;

//        public TourController(IRepository<Tour, int> repository,
//            IRepository<Category, int> categoryrepository,
//            IWebHostEnvironment webHostEnvironment,
//            IRepository<Status, int> statusrepository,
//            UserManager<AppUser> _userManager,
//            IRepository<SelectedTour, int> selectrepository)
//        {
//            this.repository = repository;
//            this.categoryrepository = categoryrepository;
//            this.webHostEnvironment = webHostEnvironment;
//            this.statusrepository = statusrepository;
//            this._userManager = _userManager;
//            this.selectrepository = selectrepository;
//        }
//        public IActionResult Index()
//        {
//            return View(repository.GetAll());
//        }

//        public IActionResult Create()
//        {
//            ViewBag.Categories = categoryrepository.GetAll();
//            return View("Create");
//        }

//        [HttpPost]
//        public IActionResult Create(Tour model, List<int> selectedCategories)
//        {
//            var userId = _userManager.GetUserId(User);
//            var tour = new Tour
//            {
//                Name = model.Name,
//                Description = model.Description,
//                Continent = model.Continent,
//                City = model.City,
//                Start = model.Start,
//                End = model.End,
//                FullPrice = model.FullPrice,
//                BookingPrice = model.BookingPrice,
//                StatusId = 1,
//                ManagerId = userId
//            };

//            List<Category> categories = new List<Category>();

//            foreach (int id in selectedCategories)
//            {
//                categories.Add(categoryrepository.Get(id));
//            }

//            tour.Categories = categories;

//            string wwwRootPath = webHostEnvironment.WebRootPath;

//            string fileName = Path.GetFileNameWithoutExtension(model.CoverFile.FileName);

//            string extension = Path.GetExtension(model.CoverFile.FileName);
//            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
//            tour.CoverPath = "/img/tour/" + fileName;
//            string path = Path.Combine(wwwRootPath + "/img/tour/", fileName);

//            using (var fileStream = new FileStream(path, FileMode.Create))
//            {
//                model.CoverFile.CopyTo(fileStream);
//            }

//            repository.Create(tour);
//            return RedirectToAction("Index");
//        }


//        public IActionResult Delete(int id)
//        {
//            return View(repository.Get(id));
//        }

//        [HttpPost]
//        public IActionResult Delete(Tour tour)
//        {
//            repository.Delete(tour);

//            return RedirectToAction("Index");
//        }

//        public IActionResult Edit(int id)
//        {
//            var tour = repository.Get(id);
//            ViewBag.Statuses = statusrepository.GetAll();
//            ViewBag.Categories = categoryrepository.GetAll();
//            return View(repository.Get(id));
//        }

//        [HttpPost]
//        public IActionResult Edit(Tour model, List<int> selectedCategories)
//        {
//            var existingTour = repository.Get(model.Id);
//            var userId = _userManager.GetUserId(User);

//            existingTour.Name = model.Name;
//            existingTour.Description = model.Description;
//            existingTour.Continent = model.Continent;
//            existingTour.City = model.City;
//            existingTour.Start = model.Start;
//            existingTour.End = model.End;
//            existingTour.FullPrice = model.FullPrice;
//            existingTour.StatusId = model.StatusId;
//            existingTour.BookingPrice = model.BookingPrice;
//            existingTour.ManagerId = userId;

//            if (model.Categories != null)
//            {
//                List<Category> categories = new List<Category>();
//                existingTour.Categories.Clear();
//                foreach (int categoryId in selectedCategories)
//                {
//                    categories.Add(categoryrepository.Get(categoryId));
//                }
//                existingTour.Categories = categories;

//            }
//            if (model.CoverFile != null)
//            {
//                string wwwRootPath = webHostEnvironment.WebRootPath;

//                string fileName = Path.GetFileNameWithoutExtension(model.CoverFile.FileName);

//                string extension = Path.GetExtension(model.CoverFile.FileName);
//                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
//                existingTour.CoverPath = "/img/profile/" + fileName;
//                string path = Path.Combine(wwwRootPath + "/img/profile/", fileName);

//                using (var fileStream = new FileStream(path, FileMode.Create))
//                {
//                    model.CoverFile.CopyTo(fileStream);
//                }
//            }

//            repository.Update(existingTour);

//            return RedirectToAction("Index");
//        }

//        [HttpPost]
//        public IActionResult AddToSelectedTours(int id)
//        {
//            var userId = _userManager.GetUserId(User);
//            var user = _userManager.FindByIdAsync(userId).Result;

//            if (user.SelectedTours == null)
//            {
//                user.SelectedTours = new List<SelectedTour>();
//            }

//            if (user.SelectedTours.All(st => st.TourId != id))
//            {
//                var selectedTour = new SelectedTour
//                {
//                    TourId = id
//                };
//                user.SelectedTours.Add(selectedTour);
//            }

//            //_userManager.UpdateAsync(user).Wait();

//            return RedirectToAction("Index", "Tour");

//        }

//    }
//}
