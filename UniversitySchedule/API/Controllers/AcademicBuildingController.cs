using Application.DTOs;
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
            if (academicBuilding == null)
            {
                return NotFound();
            }
            return Ok(academicBuilding);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var academicBuildings = await _academicBuildingService.GetAll();
            return Ok(academicBuildings);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AcademicBuildingDto academicBuilding)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var academicBuildingId = await _academicBuildingService.Add(academicBuilding);
            var res = new { Id = academicBuildingId };
            return CreatedAtAction(nameof(GetById), new { id = academicBuildingId }, res);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] AcademicBuildingDto academicBuilding)
        {
            var result = await _academicBuildingService.Update(academicBuilding);
            if (!result)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            var result = await _academicBuildingService.Delete(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
