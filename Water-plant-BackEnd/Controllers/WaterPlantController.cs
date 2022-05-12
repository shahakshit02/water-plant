using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Water_plant_BackEnd.Models;
using Water_plant_BackEnd.Services;

namespace Water_plant_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WaterPlantController : ControllerBase
    {
        IWaterPlantService _waterPlantService;
        public WaterPlantController(IWaterPlantService service)
        {
            _waterPlantService = service;
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GeAlltWaterPlant()
        {
            try
            {
                var waterPlant = _waterPlantService.GetWaterPlantList();
                if (waterPlant == null) return NotFound();
                return Ok(waterPlant);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("[action]/id")]
        public IActionResult GetWaterPlantById(int id)
        {
            try
            {
                var waterPlant = _waterPlantService.GetWaterPlantById(id);
                if (waterPlant == null) return NotFound();
                return Ok(waterPlant);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult SaveWaterPlant(int id)
        {
            try
            {
                var model = _waterPlantService.SaveWaterPlant(id);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
