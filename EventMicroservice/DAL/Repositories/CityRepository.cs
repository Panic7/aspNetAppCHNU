using Microsoft.EntityFrameworkCore;
using EventMicroservice.DAL;
using EventMicroservice.DAL.Entities;
using EventMicroservice.Repositories;

namespace EventMicroservice.Repository
{
    public class CityRepository : GenericRepository<City>
    {
        public CityRepository(EventContext dbContext) : base(dbContext)
        {
        }

        public virtual async Task<City> GetAsync(string name)
        {
            return await table.FirstOrDefaultAsync(a => a.Name.ToLower().Equals(name.ToLower()));
        }

        public override async Task<City> GetCompleteEntityAsync(int id)
        {
            var city = await table
                .Include(c => c.Country)
                .Include(c => c.Events)
                .Include(c => c.Users)
                .SingleOrDefaultAsync(c => c.Id == id);

            return city;

        }
    }
}
