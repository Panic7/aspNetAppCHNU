
using EventMicroservice.BLL.DTOs;

namespace EventMicroservice.BLL.SyncDataServices.Http
{
    public interface IGalleryDataClient
    {
        Task SendEventToGallery(EventResponse ev);
    }
}