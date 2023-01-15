using AutoMapper;
using EventMicroservice.Bll.Protos;
using Grpc.Net.Client;
using ImageMicroservice.DAL.Entities;
using Microsoft.Extensions.Configuration;

namespace ImageMicroservice.BLL.SyncDataServices.Grpc
{
    public class EventDataClient : IEventDataClient
    {
        private readonly IConfiguration configuration;
        private readonly IMapper mapper;

        public EventDataClient(IConfiguration configuration, IMapper mapper)
        {
            this.configuration = configuration;
            this.mapper = mapper;
        }
        public IEnumerable<Event> ReturnAllEvents()
        {
            Console.WriteLine($"--> Calling GRPC Service {configuration["GrpcEvent"]}");
            var channel = GrpcChannel.ForAddress(configuration["GrpcEvent"]);
            var client = new GrpcEvent.GrpcEventClient(channel);
            var request = new GetAllRequest();

            try
            {
                var reply = client.GetAllEvents(request);
                return mapper.Map<IEnumerable<Event>>(reply.Event);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"--> Couldnot call GRPC Server {ex.Message}");
                return null;
            }
        }
    }
}