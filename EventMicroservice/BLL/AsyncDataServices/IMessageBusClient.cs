
using EventMicroservice.BLL.DTOs;

namespace EventMicroservice.BLL.AsyncDataServices
{
    public interface IMessageBusClient
    {
        void PublishNewEvent(EventPublishedDto eventPublishedDto);
    }
}