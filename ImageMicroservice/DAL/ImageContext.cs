using Microsoft.EntityFrameworkCore;
using ImageMicroservice.DAL.Configurations.Entities;
using ImageMicroservice.DAL.Entities;

namespace ImageMicroservice.DAL
{
    public class ImageContext : DbContext
    {
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Event> Events { get; set; }
        public ImageContext(DbContextOptions<ImageContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GalleryConfig());
            modelBuilder.ApplyConfiguration(new ImageConfig());
            modelBuilder.ApplyConfiguration(new EventConfig());
        }
    }
}
