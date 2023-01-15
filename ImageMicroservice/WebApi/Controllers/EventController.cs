using ImageMicroservice.BLL.DTOs;
using ImageMicroservice.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace ImageMicroservice.WebApi.Controllers
{
    [ApiController]
    [Route("api/i/[controller]")]
    public class EventController : ControllerBase
    {
        private readonly GalleryService galleryService;
        private readonly ILogger<EventController> logger;

        public EventController(GalleryService galleryService, ILogger<EventController> logger)
        {
            this.galleryService = galleryService;
            this.logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EventReadDto>> GetEvents()
        {
            logger.LogInformation("--> Getting Events from CommandsService");

            var eventItems = galleryService.GetAllEvents();

            return Ok(eventItems);
        }

        [HttpPost]
        public ActionResult TestInboundConnection()
        {
            logger.LogInformation("--> Inbound POST # Image Service");

            return Ok("Inbound test of from Events Controler");
        }
    }
}