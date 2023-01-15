using Microsoft.EntityFrameworkCore;
using EventMicroservice.DAL;
using EventMicroservice.DAL.Entities;
using EventMicroservice.DAL.Pagination;
using EventMicroservice.DAL.Pagination.Parameters;
using EventMicroservice.Repositories;

namespace EventMicroservice.Repository
{
    public class EventRepository : GenericRepository<Event>
    {
        public EventRepository(EventContext dbContext) : base(dbContext)
        {
        }

        public virtual async Task<Event> GetAsync(string name)
        {
            return await table.FirstOrDefaultAsync(a => a.Name.ToLower().Equals(name.ToLower()));
        }


        public async Task<PagedList<Event>> GetAsync(EventsParameters parameters)
        {
            IQueryable<Event> source = table
                .Include(e => e.Author)
                .Include(e => e.City)
                .Include(e => e.Country)
                .Include(e => e.Categories);

            SearchByCategories(ref source, parameters.CategoryId);
            SearchByCity(ref source, parameters.CityId);
            SearchByCountry(ref source, parameters.CountryId);

            return await PagedList<Event>.ToPagedListAsync(
                source,
                parameters.PageNumber,
                parameters.PageSize);

        }
        public override async Task<Event> GetCompleteEntityAsync(int id)
        {
            var ev = await table
                .Include(e => e.Categories)
                .Include(e => e.Country)
                .Include(e => e.City)
                .Include(e => e.SubscribedUsers)
                .Include(e => e.Author)
                .SingleOrDefaultAsync(e => e.Id == id);

            return ev;
        }
        public IEnumerable<Event> GetAllEvents()
        {
            return table.ToList();
        }

        private static void SearchByCategories(ref IQueryable<Event> source, int? categoryId)
        {
            if (!categoryId.HasValue)
            {
                return;
            }

            source = source.Where(ev => ev.Categories.Any(cat => cat.Id == categoryId));
        }

        private static void SearchByCountry(ref IQueryable<Event> source, int? id)
        {
            if (!id.HasValue)
            {
                return;
            }

            source = source.Where(ev => ev.Country.Id == id);
        }
        private static void SearchByCity(ref IQueryable<Event> source, int? id)
        {
            if (!id.HasValue)
            {
                return;
            }

            source = source.Where(ev => ev.City.Id == id);
        }
        public override async Task<Event> CreateAsync(Event ev)
        {
            var createdEvent = (await table.AddAsync(ev)).Entity;
            await SaveChangesAsync();

            return createdEvent;
        }

        public async Task SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
