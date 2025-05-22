using Application.Requests;
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
            return Ok(auditorium);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var auditoriums = await _auditoriumService.GetAll();
            return Ok(auditoriums);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateAuditoriumRequest request)
        {
            var auditoriumId = await _auditoriumService.Add(request);
            var res = new { Id = auditoriumId };
            return CreatedAtAction(nameof(GetById), new { id = auditoriumId }, res);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateAuditoriumRequest request)
        {
            await _auditoriumService.Update(request);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _auditoriumService.Delete(id);
            return NoContent();
        }
    }
}
