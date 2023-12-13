using Microsoft.AspNetCore.Mvc;
using TakeATripBlazorApp.IServices;
using TakeATripBlazorApp.Model;

namespace TakeATripBlazorApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusController : ControllerBase
    {
        private readonly IStatusService _statusService;

        public StatusController(IStatusService statusService)
        {
            _statusService = statusService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var statuses = _statusService.GetAll();
            return Ok(statuses);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var status = _statusService.FindById(id);

            if (status == null)
                return NotFound();

            return Ok(status);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Status status)
        {
            if (status == null)
                return BadRequest();

            try
            {
                _statusService.AddUpdate(status);
                return CreatedAtAction(nameof(GetById), new { id = status.Id }, status);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Status status)
        {
            if (status == null || id != status.Id)
                return BadRequest();

            var existingStatus = _statusService.FindById(id);
            if (existingStatus == null)
                return NotFound();

            try
            {
                _statusService.AddUpdate(status);
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
            var status = _statusService.FindById(id);
            if (status == null)
                return NotFound();

            try
            {
                _statusService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
