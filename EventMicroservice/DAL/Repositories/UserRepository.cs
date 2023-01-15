using Microsoft.EntityFrameworkCore;
using EventMicroservice.DAL;
using EventMicroservice.DAL.Entities;
using EventMicroservice.Repositories;

namespace EventMicroservice.Repository
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository(EventContext dbContext) : base(dbContext)
        {
        }

        public override async Task<User> GetCompleteEntityAsync(int id)
        {
            var user = await table
                .Include(u => u.Role)
                .Include(u => u.Country)
                .Include(u => u.City)
                .Include(u => u.Role)
                .Include(u => u.CreatedEvents)
                .Include(u => u.SubscribedEvents)
                .SingleOrDefaultAsync(u => u.Id == id);

            return user;
        }
    }
}
