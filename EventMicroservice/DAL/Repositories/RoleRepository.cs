using Microsoft.EntityFrameworkCore;
using EventMicroservice.DAL;
using EventMicroservice.DAL.Entities;
using EventMicroservice.Repositories;

namespace EventMicroservice.Repository
{
    public class RoleRepository : GenericRepository<Role>
    {
        public RoleRepository(EventContext dbContext) : base(dbContext)
        {
        }

        public override async Task<Role> GetCompleteEntityAsync(int id)
        {
            var role = await table
                .Include(r => r.Users)
                .SingleOrDefaultAsync(r => r.Id == id);

            return role;
        }
    }
}
