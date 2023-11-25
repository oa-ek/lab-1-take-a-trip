using MediatR;
using Microsoft.AspNetCore.Mvc;
using TakeTripAsp.Application.Features.CategoryFeatures.CategoryDtos;
using TakeTripAsp.Application.Features.CategoryFeatures.Commands.CreateCategory;
using TakeTripAsp.Application.Features.CategoryFeatures.Commands.DeleteCategory;
using TakeTripAsp.Application.Features.CategoryFeatures.Commands.UpdateCategory;
using TakeTripAsp.Application.Features.CategoryFeatures.Queries.GetAllCategory;

namespace TakeTripAsp.WebApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _mediator.Send(new GetAllCatagoryQueries()));
        }

        public async Task<IActionResult> Create()
        {
            return View("Create");
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto dto)
        {
            await _mediator.Send(new CreateCategoryCommand
            {
                Name = dto.Name
            });

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id, string name)
        {
            var category = new ReadCategoryDto
            {
                Id = id,
                Name = name
            };

            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ReadCategoryDto dto)
        {
            await _mediator.Send(new DeleteCategoryCommand
            {
                Id = dto.Id
            });

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id, string name)
        {
            var category = new ReadCategoryDto
            {
                Id = id,
                Name = name
            };

            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ReadCategoryDto dto)
        {
            await _mediator.Send(new UpdateCategoryCommand
            {
                Id = dto.Id,
                Name = dto.Name
            });

            return RedirectToAction("Index");
        }
    }
}
