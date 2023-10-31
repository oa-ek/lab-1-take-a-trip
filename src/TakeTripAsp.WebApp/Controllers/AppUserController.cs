using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TakeTripAsp.Repository;
using TakeTripAsp.Repository.DTOsUser;
using TakeTripAsp.Repository.Interfaces;

namespace TakeTripAsp.WebApp.Controllers
{
    [Authorize(Roles = "admin")]
    public class AppUserController : Controller
    {
        private readonly IUserRepository userRepository;
       

        public AppUserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
         
        }


        public async Task<IActionResult> Index()
        {
            return View(await userRepository.GetAllAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var role = await userRepository.GetRolesAsync();
            ViewBag.RoleList = role.ToList();
            return View(new UserCreateDto());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserCreateDto model)
        {
            if (ModelState.IsValid)
            {
                var userId = await userRepository.CreateAsync(model);
                return RedirectToAction("Edit", new { id = userId });
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var role = await userRepository.GetRolesAsync();
            ViewBag.RoleList = role.ToList();
            var userUpdate = await userRepository.GetAsync(id);
            return View(userUpdate);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(UserDto model, string[] roles)
        {

            await userRepository.UpdateAsync(model, roles);
            return RedirectToAction("Index");

            
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            return View(await userRepository.GetAsync(id));
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Delete(UserDto user)
        {
            await userRepository.DeleteAsync(user.Id);
            return RedirectToAction("Index");
        }
    }
}