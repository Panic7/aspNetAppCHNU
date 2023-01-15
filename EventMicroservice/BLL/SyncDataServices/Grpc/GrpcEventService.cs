using AutoMapper;
using EventMicroservice.Bll.Protos;
using EventMicroservice.BLL.Services;
using EventMicroservice.Repository;
using Grpc.Core;

namespace EventMicroservice.BLL.SyncDataServices.Grpc
{
    public class GrpcEventService : GrpcEvent.GrpcEventBase
    {
        private readonly EventRepository repository;
        private readonly IMapper mapper;

        public GrpcEventService(EventRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public override Task<EventResponse> GetAllEvents(GetAllRequest request, ServerCallContext context)
        {
            var response = new EventResponse();
            var events = repository.GetAllEvents();

            foreach(var ev in events)
            {
                response.Event.Add(mapper.Map<GrpcEventModel>(ev));
            }

            return Task.FromResult(response);
        }

    }
}