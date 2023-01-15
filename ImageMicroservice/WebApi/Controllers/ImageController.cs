using ImageMicroservice.BLL.DTOs;
using ImageMicroservice.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace ImageMicroservice.WebApi.Controllers
{
    [ApiController]
    [Route("api/i/[controller]")]
    public class ImageController : ControllerBase
    {
        private readonly ImageService imageService;
        private readonly ILogger<ImageController> logger;

        public ImageController(ImageService imageService, ILogger<ImageController> logger)
        {
            this.imageService = imageService;
            this.logger = logger;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(IEnumerable<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
            public async Task<IActionResult> GetImageById([FromRoute] int id)
        {
            logger.Log(LogLevel.Information, $"Retrieving image with id = " + id);
            var retrievedImage = await imageService.GetAsync(id);
            logger.Log(LogLevel.Information, $"Requested image retrieved with id = {retrievedImage.Id}");

            return Ok(retrievedImage);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreaeteImage([FromForm] ImageRequest dto)
        {
            logger.Log(LogLevel.Information, $"Creating :\"{dto.Image.FileName}\" image.");
            var creataedImage = await imageService.CreateAsync(dto);
            logger.Log(LogLevel.Information, $"Image {creataedImage.Id} created.");

            return Ok("Created successfully with id " + creataedImage.Id);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateImage([FromForm] ImageRequest dto)
        {
            try
            {
                logger.Log(LogLevel.Information, $"Updating {dto.Id} image.");
                await imageService.UpdateAsync(dto);
                logger.Log(LogLevel.Information, $"Image with id {dto.Id} updated.");

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
                logger.Log(LogLevel.Information, $"Removing {id} image.");
                await imageService.DeleteAsync(id);
                logger.Log(LogLevel.Information, $"Image {id} removed.");

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