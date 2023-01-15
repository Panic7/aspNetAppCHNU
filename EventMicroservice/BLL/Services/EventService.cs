using AutoMapper;
using EventMicroservice.BLL.DTOs;
using EventMicroservice.DAL.Entities;
using EventMicroservice.DAL.Pagination;
using EventMicroservice.DAL.Pagination.Parameters;
using EventMicroservice.Repository;

namespace EventMicroservice.BLL.Services
{
    public class EventService
    {
        private readonly EventRepository eventRepository;
        private readonly CategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public EventService(EventRepository eventRepository, CategoryRepository categoryRepository, IMapper mapper)
        {
            this.eventRepository = eventRepository;
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }
        public async Task<PagedList<EventResponse>> GetAsync(EventsParameters parameters)
        {
            var eventsPage = await eventRepository.GetAsync(parameters);

            return eventsPage?.Map(mapper.Map<Event, EventResponse>);
        }
        public async Task<EventResponse> GetAsync(int id)
        {
            var ev = await eventRepository.GetCompleteEntityAsync(id);

            return mapper.Map<EventResponse>(ev);
        }
        public async Task<EventResponse> GetAsync(string name)
        {
            var ev = await eventRepository.GetAsync(name);

            return mapper.Map<EventResponse>(ev);
        }
        public async Task<EventResponse> CreateAsync(EventRequest request)
        {
            request.Id = null;
            var ev = mapper.Map<EventRequest, Event>(request);
            ev.Categories = request.CategoryIDs.Select(c => new Category() { Id = c }).ToList();
            eventRepository.Attach(ev);
            await eventRepository.SaveChangesAsync();

            return mapper.Map<EventResponse>(ev);
        }

        public async Task UpdateAsync(EventRequest request)
        {
            var ev = await eventRepository.GetCompleteEntityAsync(mapper.Map<int?, int>(request.Id));
            mapper.Map(request, ev);
            ev.Categories = await categoryRepository.GetAllAsync(request.CategoryIDs);

            await eventRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await eventRepository.DeleteAsync(id);
        }

        public EventPublishedDto ToEventPublishedDto(EventResponse eventResponse)
        {
            return mapper.Map<EventPublishedDto>(eventResponse);
        }

    }
}
