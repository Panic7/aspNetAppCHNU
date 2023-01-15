using ImageMicroservice.DAL.Entities;

namespace ImageMicroservice.DAL.Repositories
{
    public interface IGalleryRepository
    {
        //Event
        IEnumerable<Event> GetAllEvents();
        void CreateEvent(Event dto);
        bool EventExists(int eventId);
        bool ExternalEventExists(int externalPlatformId);

        //Gallery
        IEnumerable<Gallery> GetGalleriesForEvent(int eventId);
        Gallery GetGallery(int eventId, int galleryId);
        void CreateGallery(Gallery gallery);
    }
}