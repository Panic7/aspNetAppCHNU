using Microsoft.EntityFrameworkCore;
using EventMicroservice.DAL;
using EventMicroservice.DAL.Entities;
using EventMicroservice.Repositories;

namespace EventMicroservice.Repository
{
    public class CountryRepository : GenericRepository<Country>
    {
        public CountryRepository(EventContext dbContext) : base(dbContext)
        {
        }

        public virtual async Task<Country> GetAsync(string name)
        {
            return await table.FirstOrDefaultAsync(a => a.Name.ToLower().Equals(name.ToLower()));
        }

        public override async Task<Country> GetCompleteEntityAsync(int id)
        {
            var country = await table
                .Include(c => c.Cities)
                .Include(c => c.Events)
                .Include(c => c.Users)
                .SingleOrDefaultAsync(c => c.Id == id);

            return country;
        }
    }
}
