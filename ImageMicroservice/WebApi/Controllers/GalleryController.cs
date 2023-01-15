using ImageMicroservice.BLL.Services;
using ImageMicroservice.BLL.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ImageMicroservice.WebApi.Controllers
{
    [Route("api/i/event/{eventId}/[controller]")]
    [ApiController]
    public class GalleryController : ControllerBase
    {
        private readonly GalleryService galleryService;
        private readonly ILogger<GalleryController> logger;

        public GalleryController(GalleryService galleryService, ILogger<GalleryController> logger)
        {
            this.galleryService = galleryService;
            this.logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<GalleryReadDto>> GetGalleriesForEvent(int eventId)
        {
            logger.LogInformation($"--> Hit GetGalleriesForEvent: {eventId}");

            if (!galleryService.EventExists(eventId))
            {
                return NotFound();
            }

            var galleries = galleryService.GetGalleriesForEvent(eventId);

            return Ok(galleries);
        }

        [HttpGet("{galleryId}", Name = "GetGalleryForEvent")]
        public ActionResult<GalleryReadDto> GetGalleryForEvent(int eventId, int galleryId)
        {
            logger.LogInformation($"--> Hit GetGalleryForEvent: {eventId} / {galleryId}");

            if (!galleryService.EventExists(eventId))
            {
                return NotFound();
            }

            var gallery = galleryService.GetGallery(eventId, galleryId);

            if (gallery == null)
            {
                return NotFound();
            }

            return Ok(gallery);
        }

        [HttpPost]
        public ActionResult<GalleryReadDto> CreateGalleryForEvent(int eventId, GalleryCreateDto galleryDto)
        {
            logger.LogInformation($"--> Hit CreateGalleryForEvent: {eventId}");

            if (!galleryService.EventExists(eventId))
            {
                return NotFound();
            }

            var galleryReadDto = galleryService.CreateGalleryForEvent(eventId, galleryDto);

            return CreatedAtRoute(nameof(GetGalleryForEvent),
                new { eventId = eventId, galleryId = galleryReadDto.Id }, galleryReadDto);
        }

    }
}