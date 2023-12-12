using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TakeTripAsp.Application.Features.CityFeatures.CityDtos;
using TakeTripAsp.Application.Features.CityFeatures.Commands.CreateCity;
using TakeTripAsp.Application.Features.CityFeatures.Commands.DeleteCity;
using TakeTripAsp.Application.Features.CityFeatures.Commands.UpdateCity;
using TakeTripAsp.Application.Features.CityFeatures.Queries.GetAllCity;
using TakeTripAsp.Application.Features.CountryFeatures.Queries.GetAllCountry;

namespace TakeTripAsp.WebApp.Controllers
{
    public class CityController : Controller
    {
        private readonly IMediator _mediator;

        public CityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _mediator.Send(new GetAllCityQueries()));
        }

        public async Task<IActionResult> Create()
        {
            var countries = await _mediator.Send(new GetAllCountryQueries());

            
            ViewBag.Countries = countries.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(), 
                Text = c.Name
            }).ToList();

            return View("Create");
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCityDto dto)
        {
            await _mediator.Send(new CreateCityCommand
            {
                CityName = dto.CityName,
                CountryId = dto.CountryId
            });

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id, string cityName, int countryId)
        {
            var city = new ReadCityDto
            {
                Id = id,
                CityName = cityName,
                CountryId = countryId
            };

            return View(city);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ReadCityDto dto)
        {
            await _mediator.Send(new DeleteCityCommand
            {
                Id = dto.Id
            });

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id, string cityName, int countryId)
        {
            var countries = await _mediator.Send(new GetAllCountryQueries());

            ViewBag.Countries = countries?.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList() ?? new List<SelectListItem>();

            var city = new ReadCityDto
            {
                Id = id,
                CityName = cityName,
                CountryId = countryId
            };

            return View(city);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ReadCityDto dto)
        {
            await _mediator.Send(new UpdateCityCommand
            {
                Id = dto.Id,
                CityName = dto.CityName,
                CountryId = dto.CountryId
            });

            return RedirectToAction("Index");
        }
    }
}
