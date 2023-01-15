using Microsoft.AspNetCore.Mvc;
using EventMicroservice.BLL.DTOs;
using EventMicroservice.BLL.Services;

namespace EventMicroservice.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService categoryService;
        private readonly ILogger<CategoryController> logger;

        public CategoryController(CategoryService categoryService, ILogger<CategoryController> logger)
        {
            this.categoryService = categoryService;
            this.logger = logger;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCategoryById([FromRoute] int id)
        {
            logger.Log(LogLevel.Information, $"Retrieving category with id = " + id);
            var retrievedCategory = await categoryService.GetAsync(id);

            if (retrievedCategory == null)
            {
                return BadRequest($"Category with id {id} not found");
            }

            logger.Log(LogLevel.Information, $"Category {retrievedCategory.Name} retrieved with id = " + retrievedCategory.Id);
            return Ok(retrievedCategory);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetCategoryByName([FromRoute] string name)
        {
            logger.Log(LogLevel.Information, $"Retrieving category with name = " + name);
            try
            {
                var retrievedCategory = await categoryService.GetAsync(name);
                logger.Log(LogLevel.Information, $"Retrieved category with name {retrievedCategory.Name} with id = " + retrievedCategory.Id);

                return Ok(retrievedCategory);
            }
            catch (Exception e)
            {
                logger.LogError(e.Message, e);
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreaeteCategory([FromBody] CategoryDTO dto)
        {
            logger.Log(LogLevel.Information, $"Creating  {dto.Name} category.");
            var createdCategory = await categoryService.CreateAsync(dto);
            if (createdCategory is null)
            {
                return BadRequest();
            }
            logger.Log(LogLevel.Information, $"Category {createdCategory.Id} created.");

            return Ok("Created successfully with id " + createdCategory.Id);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody] CategoryDTO dto)
        {
            try
            {
                logger.Log(LogLevel.Information, $"Updating {dto.Id} category.");
                await categoryService.UpdateAsync(dto);
                logger.Log(LogLevel.Information, $"Category with id {dto.Id} updated.");

                return Ok("Updated Successfully");
            }
            catch (Exception e)
            {
                logger.LogError(e.Message, e);

                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync([FromRoute] int id)
        {
            logger.Log(LogLevel.Information, $"Removing {id} category.");
            await categoryService.DeleteAsync(id);
            logger.Log(LogLevel.Information, $"Category {id} removed.");

            return Ok("Removed Successfully");
        }
    }
}
