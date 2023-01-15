using Microsoft.EntityFrameworkCore;
using EventMicroservice.DAL;

namespace EventMicroservice.Repositories
{
    public abstract class GenericRepository<TEntity> where TEntity : class
    {
        protected readonly EventContext dbContext;

        protected readonly DbSet<TEntity> table;

        public GenericRepository(EventContext dbContext)
        {
            this.dbContext = dbContext;
            table = this.dbContext.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync() => await table.ToListAsync();

        public virtual async Task<TEntity> GetAsync(int id)
        {
            return await table.FindAsync(id);
        }

        public abstract Task<TEntity> GetCompleteEntityAsync(int id);

        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            var obj = (await table.AddAsync(entity)).Entity;
            await dbContext.SaveChangesAsync();

            return obj;
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            await Task.Run(() => table.Update(entity));

            await dbContext.SaveChangesAsync();
        }

        public virtual void Attach(TEntity entity)
        {
            table.Attach(entity);
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await GetAsync(id);
            await Task.Run(() => table.Remove(entity));
            await dbContext.SaveChangesAsync();
        }
        public virtual async Task DeleteRangeAsync(TEntity[] entity)
        {
            await Task.Run(() => table.RemoveRange(entity));
            await dbContext.SaveChangesAsync();
        }
    }
}
