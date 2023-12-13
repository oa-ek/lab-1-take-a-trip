using Microsoft.AspNetCore.Mvc;
using TakeATripBlazorApp.IServices;
using TakeATripBlazorApp.Model;

namespace TakeATripBlazorApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var countries = _countryService.GetAll();
            return Ok(countries);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var country = _countryService.FindById(id);

            if (country == null)
                return NotFound();

            return Ok(country);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Country country)
        {
            if (country == null)
                return BadRequest();

            try
            {
                _countryService.AddUpdate(country);
                return CreatedAtAction(nameof(GetById), new { id = country.Id }, country);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Country country)
        {
            if (country == null || id != country.Id)
                return BadRequest();

            var existingCountry = _countryService.FindById(id);
            if (existingCountry == null)
                return NotFound();

            try
            {
                _countryService.AddUpdate(country);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var country = _countryService.FindById(id);
            if (country == null)
                return NotFound();

            try
            {
                _countryService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}