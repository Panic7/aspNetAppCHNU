using ImageMicroservice.BLL.SyncDataServices.Grpc;
using ImageMicroservice.DAL.Entities;
using ImageMicroservice.DAL.Repositories;

namespace ImageMicroservice.WebApi
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var grpcClient = serviceScope.ServiceProvider.GetService<IEventDataClient>();

                var events = grpcClient.ReturnAllEvents();

                SeedData(serviceScope.ServiceProvider.GetService<IGalleryRepository>(), events);
            }
        }

        private static void SeedData(IGalleryRepository repository, IEnumerable<Event> events)
        {
            Console.WriteLine("Seeding new platforms...");

            foreach (var ev in events)
            {
                if (!repository.ExternalEventExists(ev.ExternalId))
                {
                    repository.CreateEvent(ev);
                }
            }
        }
    }
}