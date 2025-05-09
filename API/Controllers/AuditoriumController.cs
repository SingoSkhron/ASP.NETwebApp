using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuditoriumController : ControllerBase
    {
        private readonly IAuditoriumService _auditoriumService;

        public AuditoriumController(IAuditoriumService auditoriumService)
        {
            _auditoriumService = auditoriumService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var auditorium = await _auditoriumService.GetById(id);
            if (auditorium == null)
            {
                return NotFound();
            }
            return Ok(auditorium);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var auditoriums = await _auditoriumService.GetAll();
            return Ok(auditoriums);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AuditoriumDto auditorium)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var auditoriumId = await _auditoriumService.Add(auditorium);
            var res = new { Id = auditoriumId };
            return CreatedAtAction(nameof(GetById), new { id = auditoriumId }, res);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] AuditoriumDto auditorium)
        {
            var result = await _auditoriumService.Update(auditorium);
            if (!result)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            var result = await _auditoriumService.Delete(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
