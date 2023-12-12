using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TakeTripAsp.Application.Features.AppUserFeatures.AppUserDto;
using TakeTripAsp.Application.Features.AppUserFeatures.Commands.CreateAppUser;
using TakeTripAsp.Application.Features.AppUserFeatures.Commands.DeleteAppUser;
using TakeTripAsp.Application.Features.AppUserFeatures.Commands.UpdateAppUser;
using TakeTripAsp.Application.Features.AppUserFeatures.Queries.GetAllAppUser;


namespace TakeTripAsp.WebApp.Controllers
{
    [Authorize(Roles = "admin")]

    public class AppUserController : Controller
    {
        private readonly IMediator _mediator;

        public AppUserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _mediator.Send(new GetAllAppUserQueries()));
        }

        public async Task<IActionResult> Create()
        {
            return View("Create");
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAppUserDto dto)
        {
            await _mediator.Send(new CreateAppUserCommand
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Password = dto.Password,
                CoverPath = dto.CoverPath,
                Role = dto.Role
            });

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(string id)
        {
            var appUser = new ReadAppUserDto
            {
                Id = id
            };

            return View(appUser);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ReadAppUserDto dto)
        {
            await _mediator.Send(new DeleteAppUserCommand
            {
                Id = dto.Id
            });

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(string id)
        {
            var appUser = new ReadAppUserDto
            {
                Id = id
            };

            return View(appUser);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ReadAppUserDto dto)
        {
            await _mediator.Send(new UpdateAppUserCommand
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                CoverPath = dto.CoverPath,
            });

            return RedirectToAction("Index");
        }
    }
}
//    public class AppUserController : Controller
//    {
//        private readonly IUserRepository userRepository;
//        private readonly IWebHostEnvironment webHostEnvironment;
//        private readonly UserManager<AppUser> _userManager;

//        public AppUserController(IUserRepository userRepository, IWebHostEnvironment webHostEnvironment,
//            UserManager<AppUser> userManager)
//        {
//            this.userRepository = userRepository;
//            this.webHostEnvironment = webHostEnvironment;
//            this._userManager = userManager;
//        }


//        public async Task<IActionResult> Index()
//        {
//            return View(await userRepository.GetAllAsync());
//        }

//        [HttpGet]
//        public async Task<IActionResult> Create()
//        {
//            var role = await userRepository.GetRolesAsync();
//            ViewBag.RoleList = role.ToList();
//            return View(new UserCreateDto());
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create(UserCreateDto model)
//        {
//            if (ModelState.IsValid)
//            {
//                string wwwRootPath = webHostEnvironment.WebRootPath;

//                string fileName = Path.GetFileNameWithoutExtension(model.CoverFile.FileName);

//                string extension = Path.GetExtension(model.CoverFile.FileName);
//                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
//                model.CoverPath = "/img/user/" + fileName;
//                string path = Path.Combine(wwwRootPath + "/img/user/", fileName);

//                using (var fileStream = new FileStream(path, FileMode.Create))
//                {
//                    model.CoverFile.CopyTo(fileStream);
//                }
//                var userId = await userRepository.CreateAsync(model);
//                return RedirectToAction("Index");
//            }
//            return View(model);
//        }

//        [HttpGet]
//        public async Task<IActionResult> Edit(string id)
//        {
//            var role = await userRepository.GetRolesAsync();
//            ViewBag.RoleList = role.ToList();
//            var userUpdate = await userRepository.GetAsync(id);
//            return View(userUpdate);
//        }

//        [HttpPost]
//        [AutoValidateAntiforgeryToken]
//        public async Task<IActionResult> Edit(UserDto model, string[] roles)
//        {
//            if (model.CoverFile != null)
//            {
//                string wwwRootPath = webHostEnvironment.WebRootPath;

//                string fileName = Path.GetFileNameWithoutExtension(model.CoverFile.FileName);

//                string extension = Path.GetExtension(model.CoverFile.FileName);
//                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
//                model.CoverPath = "/img/profile/" + fileName;
//                string path = Path.Combine(wwwRootPath + "/img/profile/", fileName);

//                using (var fileStream = new FileStream(path, FileMode.Create))
//                {
//                    model.CoverFile.CopyTo(fileStream);
//                }
//            }
//            await userRepository.UpdateAsync(model, roles);
//            return RedirectToAction("Index");

//        }

//        [HttpGet]
//        public async Task<IActionResult> Delete(string id)
//        {
//            return View(await userRepository.GetAsync(id));
//        }

//        [HttpPost]
//        [AutoValidateAntiforgeryToken]
//        public async Task<IActionResult> Delete(UserDto user)
//        {
//            await userRepository.DeleteAsync(user.Id);
//            return RedirectToAction("Index");
//        }
//        [HttpGet]
//        public async Task<IActionResult> Details(string id)
//        {
//            return View(await userRepository.GetAsync(id));
//        }

//        [HttpPost]
//        public async Task<IActionResult> Details(UserDto model)
//        {
//            var user = await _userManager.FindByIdAsync(model.Id);

//            if (user == null)
//            {
//                return NotFound(); 
//            }

//            return View("Home", user);
//            //return View();
//        }
//    }
//}