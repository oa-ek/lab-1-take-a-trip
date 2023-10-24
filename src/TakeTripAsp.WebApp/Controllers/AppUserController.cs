﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TakeTripAsp.Core.Entity;
using TakeTripAsp.Repository;
using TakeTripAsp.Repository.DTOsUser;
using TakeTripAsp.Repository.Interfaces;

namespace TakeTripAsp.WebApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AppUserController : Controller
    {
        private readonly IUserRepository userRepository;

        public AppUserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            return View(await userRepository.GetAllAsync());
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
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
            ViewBag.Roles = await userRepository.GetRolesAsync();
            var userUpdate = await userRepository.GetAsync(id);
            return View(userUpdate);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(UserDto model, string[] roles)
        {
            if (ModelState.IsValid)
            {
                await userRepository.UpdateAsync(model, roles);
                return RedirectToAction("Index");
            }
            ViewBag.Roles = await userRepository.GetRolesAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            return View(await userRepository.GetAsync(id));
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> ConfirmDelete(string id)
        {
            await userRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}