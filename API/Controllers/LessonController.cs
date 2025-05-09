using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LessonController : ControllerBase
    {
        private readonly ILessonService _lessonService;

        public LessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var lesson = await _lessonService.GetById(id);
            if (lesson == null)
            {
                return NotFound();
            }
            return Ok(lesson);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var lessons = await _lessonService.GetAll();
            return Ok(lessons);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] LessonDto lesson)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var lessonId = await _lessonService.Add(lesson);
            var res = new { Id = lessonId };
            return CreatedAtAction(nameof(GetById), new { id = lessonId }, res);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] LessonDto lesson)
        {
            var result = await _lessonService.Update(lesson);
            if (!result)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            var result = await _lessonService.Delete(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
