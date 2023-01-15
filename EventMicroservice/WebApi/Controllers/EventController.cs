using Microsoft.AspNetCore.Mvc;
using EventMicroservice.BLL.DTOs;
using EventMicroservice.BLL.Services;
using EventMicroservice.DAL.Pagination.Parameters;
using EventMicroservice.BLL.AsyncDataServices;
using EventMicroservice.BLL.SyncDataServices.Http;

namespace EventMicroservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        private readonly EventService eventService;
        private readonly ILogger<EventController> logger;
        private readonly IGalleryDataClient galleryDataClient;
        private readonly IMessageBusClient messageBusClient;


        public EventController(
        EventService eventService,
        ILogger<EventController> logger,
        IGalleryDataClient galleryDataClient,
        IMessageBusClient messageBusClient)
        {
            this.eventService = eventService;
            this.logger = logger;
            this.galleryDataClient = galleryDataClient;
            this.messageBusClient = messageBusClient;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(IEnumerable<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetEventById([FromRoute] int id)
        {
            logger.Log(LogLevel.Information, $"Retrieving event with id = " + id);
            var retrievedEvent = await eventService.GetAsync(id);

            if (retrievedEvent == null)
            {
                return BadRequest($"Event with id {id} not found");
            }

            logger.Log(LogLevel.Information, $"Event {retrievedEvent.Name} retrieved with id = " + retrievedEvent.Id);
            return Ok(retrievedEvent);
        }

        [HttpGet("{name}")]
        [ProducesResponseType(typeof(IEnumerable<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetEventByName([FromRoute] string name)
        {
            logger.Log(LogLevel.Information, $"Retrieving event with name = " + name);
            try
            {
                var retrievedEvent = await eventService.GetAsync(name);
                logger.Log(LogLevel.Information, $"Retrieved event with name {retrievedEvent.Name} with id = " + retrievedEvent.Id);

                return Ok(retrievedEvent);
            }
            catch (Exception e)
            {
                logger.LogError(e.Message, e);
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PagedEvents([FromQuery] EventsParameters parameters)
        {

            logger.Log(LogLevel.Information, "Fetching all Events from the storage");
            var events = await eventService.GetAsync(parameters);

            if (events == null)
            {
                return NotFound();
            }
            logger.Log(LogLevel.Information, $"Returning {events.Count} events.");
            return Ok(events);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateEvent([FromBody] EventRequest ev)
        {
            logger.Log(LogLevel.Information, $"Creating {ev.Id} {ev.Name} event.");
            var createdEvent = await eventService.CreateAsync(ev);
            logger.Log(LogLevel.Information, $"Event {ev.Id} created.");

            //-->Send Sync Message
            try
            {
                await galleryDataClient.SendEventToGallery(createdEvent);
            }
            catch (Exception ex)
            {
                logger.LogInformation($"--> Could not send synchronosly: {ex.Message}");
            }

            //-->Send Async Message
            try
            {
                var eventPublishedDto = eventService.ToEventPublishedDto(createdEvent);
                eventPublishedDto.Event = "Event_Published";
                messageBusClient.PublishNewEvent(eventPublishedDto);

            }
            catch (Exception ex)
            {
                logger.LogInformation($"--> Could not send asynchronosly: {ex.Message}");
            }

            return Ok("Created Successfully");
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateEvent([FromBody] EventRequest ev)
        {
            logger.Log(LogLevel.Information, $"Updating {ev.Id} event.");
            await eventService.UpdateAsync(ev);

            if (ev is null)
            {
                return NotFound();
            }
            logger.Log(LogLevel.Information, $"Event {ev.Id} updated.");

            return Ok("Updated Successfully");
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteAsync([FromRoute] int id)
        {
            logger.Log(LogLevel.Information, $"Deleting event with id {id}");
            await eventService.DeleteAsync(id);
            logger.Log(LogLevel.Information, $"Event {id} deleted.");

            return Ok("Deleted Successfully");
        }


    }
}
