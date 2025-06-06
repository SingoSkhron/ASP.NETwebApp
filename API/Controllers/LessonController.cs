﻿using Application.Requests;
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
            return Ok(lesson);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var lessons = await _lessonService.GetAll();
            return Ok(lessons);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateLessonRequest request)
        {
            var lessonId = await _lessonService.Add(request);
            var res = new { Id = lessonId };
            return CreatedAtAction(nameof(GetById), new { id = lessonId }, res);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateLessonRequest request)
        {
            await _lessonService.Update(request);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _lessonService.Delete(id);
            return NoContent();
        }
    }
}
