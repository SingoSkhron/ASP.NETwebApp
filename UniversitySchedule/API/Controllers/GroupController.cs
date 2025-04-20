using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;
        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var group = await _groupService.GetById(id);
            if (group == null)
            {
                return NotFound();
            }
            return Ok(group);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var groups = await _groupService.GetAll();
            return Ok(groups);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] GroupDto group)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var groupId = await _groupService.Add(group);
            var res = new { Id = groupId };
            return CreatedAtAction(nameof(GetById), new { id = groupId }, res);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] GroupDto group)
        {
            var result = await _groupService.Update(group);
            if (!result)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            var result = await _groupService.Delete(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
