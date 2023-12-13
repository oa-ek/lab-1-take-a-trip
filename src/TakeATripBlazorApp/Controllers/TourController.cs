using Microsoft.AspNetCore.Mvc;
using TakeATripBlazorApp.IServices;
using TakeATripBlazorApp.Model;

namespace TakeATripBlazorApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TourController : ControllerBase
    {
        private readonly ITourService _tourService;

        public TourController(ITourService tourService)
        {
            _tourService = tourService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var tours = _tourService.GetAll();
            return Ok(tours);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var tour = _tourService.FindById(id);

            if (tour == null)
                return NotFound();

            return Ok(tour);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Tour tour)
        {
            if (tour == null)
                return BadRequest();

            try
            {
                _tourService.AddUpdate(tour);
                return CreatedAtAction(nameof(GetById), new { id = tour.Id }, tour);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Tour tour)
        {
            if (tour == null || id != tour.Id)
                return BadRequest();

            var existingTour = _tourService.FindById(id);
            if (existingTour == null)
                return NotFound();

            try
            {
                _tourService.AddUpdate(tour);
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
            var tour = _tourService.FindById(id);
            if (tour == null)
                return NotFound();

            try
            {
                _tourService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
