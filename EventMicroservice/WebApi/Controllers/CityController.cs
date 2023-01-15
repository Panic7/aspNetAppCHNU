using Microsoft.AspNetCore.Mvc;
using EventMicroservice.BLL.DTOs;
using EventMicroservice.BLL.Services;

namespace EventMicroservice.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CityController : ControllerBase
    {
        private readonly CityService cityService;
        private readonly ILogger<CityController> logger;

        public CityController(CityService cityService, ILogger<CityController> logger)
        {
            this.cityService = cityService;
            this.logger = logger;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(IEnumerable<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCityById([FromRoute] int id)
        {
            logger.Log(LogLevel.Information, $"Retrieving city with id = " + id);
            var retrievedCity = await cityService.GetAsync(id);
            logger.Log(LogLevel.Information, $"City {retrievedCity.Name} retrieved with id = " + retrievedCity.Id);

            return Ok(retrievedCity);

        }

        [HttpGet("{name}")]
        [ProducesResponseType(typeof(IEnumerable<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCityByName([FromRoute] string name)
        {
            logger.Log(LogLevel.Information, $"Retrieving city with name = " + name);
            try
            {
                var retrievedCity = await cityService.GetAsync(name);
                logger.Log(LogLevel.Information, $"Retrieved city with name {retrievedCity.Name} with id = " + retrievedCity.Id);

                return Ok(retrievedCity);
            }
            catch (Exception e)
            {
                logger.LogError(e.Message, e);
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreaeteCity([FromBody] CityDTO dto)
        {
            logger.Log(LogLevel.Information, $"Creating  {dto.Name} city.");
            var creataedCity = await cityService.CreateAsync(dto);
            logger.Log(LogLevel.Information, $"City {creataedCity.Id} created.");

            return Ok("Created successfully with id " + creataedCity.Id);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateCity([FromBody] CityDTO dto)
        {
            try
            {
                logger.Log(LogLevel.Information, $"Updating {dto.Id} city.");
                await cityService.UpdateAsync(dto);
                logger.Log(LogLevel.Information, $"City with id {dto.Id} updated.");

                return Ok("Updated Successfully");
            }
            catch (Exception e)
            {
                logger.LogError(e.Message, e);

                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteAsync([FromRoute] int id)
        {
            try
            {
                logger.Log(LogLevel.Information, $"Removing {id} city.");
                await cityService.DeleteAsync(id);
                logger.Log(LogLevel.Information, $"City {id} removed.");

                return Ok("Removed Successfully");
            }
            catch (Exception e)
            {
                logger.LogError(e.Message, e);

                return BadRequest(e.Message);
            }
        }
    }
}
