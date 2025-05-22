using Application.Requests;
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
            return Ok(group);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var groups = await _groupService.GetAll();
            return Ok(groups);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateGroupRequest request)
        {
            var groupId = await _groupService.Add(request);
            var res = new { Id = groupId };
            return CreatedAtAction(nameof(GetById), new { id = groupId }, res);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateGroupRequest request)
        {
            await _groupService.Update(request);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _groupService.Delete(id);
            return NoContent();
        }
    }
}
