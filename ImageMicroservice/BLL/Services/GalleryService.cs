
using System.Reflection.Metadata;
using System.Data;
using AutoMapper;
using ImageMicroservice.BLL.DTOs;
using ImageMicroservice.DAL.Entities;
using ImageMicroservice.DAL.Repositories;
using Microsoft.Extensions.Logging;

namespace ImageMicroservice.BLL.Services
{
    public class GalleryService
    {
        private readonly IGalleryRepository galleryRepository;
        private readonly IMapper mapper;
        private readonly ILogger<GalleryService> logger;
        public GalleryService(IGalleryRepository galleryRepository, IMapper mapper, ILogger<GalleryService> logger)
        {
            this.galleryRepository = galleryRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public IEnumerable<GalleryReadDto> GetGalleriesForEvent(int eventId)
        {
            var galleries = galleryRepository.GetGalleriesForEvent(eventId);

            return mapper.Map<IEnumerable<GalleryReadDto>>(galleries);
        }

        public GalleryReadDto GetGallery(int eventId, int galleryId)
        {
            var gallery = galleryRepository.GetGallery(eventId, galleryId);

            return mapper.Map<GalleryReadDto>(gallery);
        }

        public GalleryReadDto CreateGalleryForEvent(int eventId, GalleryCreateDto galleryDto)
        {
            logger.LogInformation($"--> Hit CreateGalleryForEvent: {eventId}");
            logger.LogInformation($"-->  GalleryCreateDto: {galleryDto.Name}");
            var gallery = mapper.Map<Gallery>(galleryDto);
            gallery.EventId = eventId;

            galleryRepository.CreateGallery(gallery);

            var galleryReadDto = mapper.Map<GalleryReadDto>(gallery);

            return galleryReadDto;
        }
        //Events
        public void CreateEvent(EventPublishedDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }
            var ev = mapper.Map<Event>(dto);
            logger.LogInformation($"Creating event {ev.Id} + {ev.ExternalId} + {ev.Name}");
            galleryRepository.CreateEvent(ev);
            logger.LogInformation("Event added with id " + dto.Id);

        }
        public IEnumerable<EventReadDto> GetAllEvents()
        {
            var Events = galleryRepository.GetAllEvents();

            return mapper.Map<IEnumerable<EventReadDto>>(Events);
        }
        public bool ExternalEventExists(int externalEventId)
        {
            return galleryRepository.ExternalEventExists(externalEventId);
        }
        public bool EventExists(int eventId)
        {
            return galleryRepository.EventExists(eventId);
        }
    }
}