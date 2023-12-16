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
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AppUserController(IMediator mediator, IWebHostEnvironment webHostEnvironment)
        {
            _mediator = mediator;
            _webHostEnvironment = webHostEnvironment;
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
            string wwwRootPath = _webHostEnvironment.WebRootPath;

            await _mediator.Send(new CreateAppUserCommand
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Password = dto.Password,
                wwwRootPath = wwwRootPath,
                CoverFile = dto.CoverFile,
                //Role = dto.Role
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