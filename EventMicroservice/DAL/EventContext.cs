using Microsoft.EntityFrameworkCore;
using EventMicroservice.DAL.Configurations.Entities;
using EventMicroservice.DAL.Entities;

namespace EventMicroservice.DAL
{
    public class EventContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        public EventContext(DbContextOptions<EventContext> options)
            : base(options)
        {
            /****************** USED TO FIX ERROR DURING 'Update-Database' WITH 'DateTime UTC' ****************/
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
            /****************** USED TO FIX ERROR DURING Update-Database with DateTime UTC ****************/

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfiguration(new CountryConfig());
            modelBuilder.ApplyConfiguration(new CityConfig());
            modelBuilder.ApplyConfiguration(new EventConfig());
            modelBuilder.ApplyConfiguration(new RoleConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());
            EventConfig.EventCategorySeed(modelBuilder);
            EventConfig.EventUserSeed(modelBuilder);

        }

    }
}
