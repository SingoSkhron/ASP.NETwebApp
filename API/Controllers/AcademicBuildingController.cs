using Application.Requests;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AcademicBuildingController : ControllerBase
    {
        private readonly IAcademicBuildingService _academicBuildingService;

        public AcademicBuildingController(IAcademicBuildingService academicBuildingService)
        {
            _academicBuildingService = academicBuildingService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var academicBuilding = await _academicBuildingService.GetById(id);
            return Ok(academicBuilding);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var academicBuildings = await _academicBuildingService.GetAll();
            return Ok(academicBuildings);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateAcademicBuildingRequest request)
        {
            var academicBuildingId = await _academicBuildingService.Add(request);
            var res = new { Id = academicBuildingId };
            return CreatedAtAction(nameof(GetById), new { id = academicBuildingId }, res);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateAcademicBuildingRequest request)
        {
            await _academicBuildingService.Update(request);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _academicBuildingService.Delete(id);
            return NoContent();
        }
    }
}
