using Application.Requests;
using Application.Services;
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
            return Ok(scheduleItem);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var scheduleItems = await _scheduleItemsService.GetAll();
            return Ok(scheduleItems);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateScheduleItemRequest request)
        {
            var scheduleItemId = await _scheduleItemsService.Add(request);
            var res = new { Id = scheduleItemId };
            return CreatedAtAction(nameof(GetById), new { id = scheduleItemId }, res);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateScheduleItemRequest request)
        {
            await _scheduleItemsService.Update(request);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _scheduleItemsService.Delete(id);
            return NoContent();
        }
    }
}
