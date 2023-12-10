using MediatR;
using Microsoft.AspNetCore.Mvc;
using TakeTripAsp.Application.Features.CountryFeatures.Commands.DeleteCountry;
using TakeTripAsp.Application.Features.CountryFeatures.Commands.UpdateCountry;
using TakeTripAsp.Application.Features.CountryFeatures.CountryDtos;
using TakeTripAsp.Application.Features.CountryFeatures.Queries.GetAllCountry;
using TakeTripAsp.Application.Features.CountryFeatures.Commands.CreateCountry;

namespace TakeTripAsp.WebApp.Controllers
{
    public class CountryController : Controller
    {
        private readonly IMediator _mediator;

        public CountryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        public async Task<IActionResult> Index()
        {
            return View(await _mediator.Send(new GetAllCountryQueries()));
        }

        public async Task<IActionResult> Create()
        {
            return View("Create");
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCountryDto dto)
        {
            await _mediator.Send(new CreateCountryDto
            {
                Name = dto.Name
            });

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id, string name)
        {
            var country = new ReadCountryDto
            {
                Id = id,
                Name = name
            };

            return View(country);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ReadCountryDto dto)
        {
            await _mediator.Send(new DeleteCountryCommand
            {
                Id = dto.Id
            });

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id, string name)
        {
            var country = new ReadCountryDto
            {
                Id = id,
                Name = name
            };

            return View(country);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ReadCountryDto dto)
        {
            await _mediator.Send(new UpdateCountryCommand
            {
                Id = dto.Id,
                Name = dto.Name
            });

            return RedirectToAction("Index");
        }
    }
}     
