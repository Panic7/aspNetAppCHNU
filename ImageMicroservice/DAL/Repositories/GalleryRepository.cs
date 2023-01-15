using System.Net.NetworkInformation;
using Microsoft.EntityFrameworkCore;
using ImageMicroservice.DAL.Entities;

namespace ImageMicroservice.DAL.Repositories
{
    public class GalleryRepository : IGalleryRepository
    {
        private readonly ImageContext context;

        public GalleryRepository(ImageContext context)
        {
            this.context = context;
        }

        public void CreateGallery(Gallery gallery)
        {
            if (gallery == null)
            {
                throw new ArgumentNullException(nameof(gallery));
            }

            context.Galleries.Add(gallery);
            context.SaveChangesAsync();
        }
        public void CreateEvent(Event ev)
        {
            if (ev == null)
            {
                throw new ArgumentNullException(nameof(ev));
            }
            ev.Id = null;
            context.Events.Add(ev);
            context.SaveChangesAsync();
        }
        public bool EventExists(int eventId)
        {
            return context.Events.Any(e => e.Id == eventId);
        }

        public bool ExternalEventExists(int externalEventId)
        {
            return context.Events.Any(e => e.ExternalId == externalEventId);
        }

        public IEnumerable<Event> GetAllEvents()
        {
            return context.Events.ToList();
        }

        public IEnumerable<Gallery> GetGalleriesForEvent(int eventId)
        {
            return context.Galleries
                .Where(g => g.EventId == eventId)
                .OrderBy(g => g.Event.Name)
                .Include(g => g.Images);
        }

        public Gallery GetGallery(int eventId, int galleryId)
        {
            return context.Galleries
                .Where(g => g.EventId == eventId && g.Id == galleryId).FirstOrDefault();
        }
    }
}
