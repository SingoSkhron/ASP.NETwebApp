using Application.DTOs;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScheduleItemsController : ControllerBase
    {
        private readonly IScheduleItemsService _scheduleItemsService;
        public ScheduleItemsController(IScheduleItemsService scheduleItemsService)
        {
            _scheduleItemsService = scheduleItemsService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var scheduleItem = await _scheduleItemsService.GetById(id);
            if (scheduleItem == null)
            {
                return NotFound();
            }
            return Ok(scheduleItem);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var scheduleItems = await _scheduleItemsService.GetAll();
            return Ok(scheduleItems);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ScheduleItemsDto scheduleItems)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var scheduleItemId = await _scheduleItemsService.Add(scheduleItems);
            var res = new { Id = scheduleItemId };
            return CreatedAtAction(nameof(GetById), new { id = scheduleItemId }, res);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ScheduleItemsDto scheduleItems)
        {
            var result = await _scheduleItemsService.Update(scheduleItems);
            if (!result)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            var result = await _scheduleItemsService.Delete(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
