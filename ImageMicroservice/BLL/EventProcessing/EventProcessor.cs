using System.Text.Json;
using AutoMapper;
using ImageMicroservice.BLL.DTOs;
using ImageMicroservice.BLL.Services;
using ImageMicroservice.DAL.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace ImageMicroservice.BLL.EventProcessing
{
    public class EventProcessor : IEventProcessor
    {
        private readonly IServiceScopeFactory scopeFactory;

        public EventProcessor(IServiceScopeFactory scopeFactory)
        {
            this.scopeFactory = scopeFactory;
        }

        public void ProcessEvent(string message)
        {
            var eventType = DetermineEvent(message);

            switch (eventType)
            {
                case EventType.EventPublished:
                    AddEvent(message);
                    break;
                default:
                    break;
            }
        }

        private EventType DetermineEvent(string notifcationMessage)
        {
            Console.WriteLine("--> Determining Event");

            var eventType = JsonSerializer.Deserialize<GenericEventDto>(notifcationMessage);

            switch (eventType.Event)
            {
                case "Event_Published":
                    Console.WriteLine("--> Event_Published, Event Detected");
                    return EventType.EventPublished;
                default:
                    Console.WriteLine("--> Could not determine the event type");
                    return EventType.Undetermined;
            }
        }

        private void AddEvent(string eventPublishedMessage)
        {
            using (var scope = scopeFactory.CreateScope())
            {
                var galleryService = scope.ServiceProvider.GetRequiredService<GalleryService>();

                var eventPublishedDto = JsonSerializer.Deserialize<EventPublishedDto>(eventPublishedMessage);

                try
                {

                    if (!galleryService.ExternalEventExists(eventPublishedDto.Id))
                    {
                        galleryService.CreateEvent(eventPublishedDto);
                        Console.WriteLine("--> Event Added...");
                    }
                    else
                    {
                        Console.WriteLine("--> Event already exisits...");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"--> Could not add Event to DB {ex.Message}");
                }
            }
        }

        enum EventType
        {
            EventPublished,
            Undetermined
        }
    }
}