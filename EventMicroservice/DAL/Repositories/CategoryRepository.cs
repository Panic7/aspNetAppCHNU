using Microsoft.EntityFrameworkCore;
using EventMicroservice.DAL;
using EventMicroservice.DAL.Entities;
using EventMicroservice.Repositories;
using System.Xml.Linq;

namespace EventMicroservice.Repository
{
    public class CategoryRepository : GenericRepository<Category>
    {
        public CategoryRepository(EventContext dbContext) : base(dbContext)
        {
        }

        public override async Task<Category> GetCompleteEntityAsync(int id)
        {
            var category = await table.Include(c => c.Events)
                        .SingleOrDefaultAsync(ticket => ticket.Id == id);

            return category;
        }

        public virtual async Task<Category> GetAsync(string name)
        {
            return await table.FirstOrDefaultAsync(a => a.Name.ToLower().Equals(name.ToLower()));
        }

        public async Task<List<Category>> GetAllAsync(int[] IDs)
        {
            return await dbContext.Categories.Where(c => IDs.Contains(c.Id)).ToListAsync();

        }
    }
}
