using ImageMicroservice.DAL.Entities;

namespace ImageMicroservice.BLL.SyncDataServices.Grpc
{
    public interface IEventDataClient
    {
        IEnumerable<Event> ReturnAllEvents();
    }
}