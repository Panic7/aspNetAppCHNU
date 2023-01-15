using Microsoft.AspNetCore.Mvc;
using EventMicroservice.BLL.DTOs;
using EventMicroservice.BLL.Services;

namespace EventMicroservice.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly CountryService countryService;
        private readonly ILogger<CountryController> logger;

        public CountryController(CountryService countryService, ILogger<CountryController> logger)
        {
            this.countryService = countryService;
            this.logger = logger;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(IEnumerable<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCountryById([FromRoute] int id)
        {
            logger.Log(LogLevel.Information, $"Retrieving country with id = " + id);
            var retrievedCountry = await countryService.GetAsync(id);

            if (retrievedCountry is null)
            {
                logger.Log(LogLevel.Error, $"Country with id = {id} not found");

                return NotFound($"Country with id = {id} not found");
            }

            logger.Log(LogLevel.Information, $"Country {retrievedCountry.Name} retrieved with id = " + retrievedCountry.Id);

            return Ok(retrievedCountry);

        }

        [HttpGet("{name}")]
        [ProducesResponseType(typeof(IEnumerable<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCountryByName([FromRoute] string name)
        {
            logger.Log(LogLevel.Information, $"Retrieving country with name = " + name);
            try
            {
                var retrievedCountry = await countryService.GetAsync(name);

                if (retrievedCountry is null)
                {
                    logger.Log(LogLevel.Error, $"Country with name = {name} not found");

                    return NotFound($"Country with name = {name} not found");
                }

                logger.Log(LogLevel.Information, $"Retrieved country with name {retrievedCountry.Name} with id = " + retrievedCountry.Id);

                return Ok(retrievedCountry);
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
        public async Task<IActionResult> CreaeteCountry([FromBody] CountryDTO dto)
        {
            logger.Log(LogLevel.Information, $"Creating  {dto.Name} country.");
            var creataedCountry = await countryService.CreateAsync(dto);
            logger.Log(LogLevel.Information, $"Country {creataedCountry.Id} created.");

            return Ok("Created successfully with id " + creataedCountry.Id);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateCountry([FromBody] CountryDTO dto)
        {
            try
            {
                logger.Log(LogLevel.Information, $"Updating {dto.Id} country.");
                await countryService.UpdateAsync(dto);
                logger.Log(LogLevel.Information, $"Country with id {dto.Id} updated.");

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
                logger.Log(LogLevel.Information, $"Removing {id} country.");
                await countryService.DeleteAsync(id);
                logger.Log(LogLevel.Information, $"Country {id} removed.");

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
