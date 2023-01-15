using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ImageMicroservice.DAL.Entities;

namespace ImageMicroservice.DAL.Configurations.Entities
{
    public class GalleryConfig : IEntityTypeConfiguration<Gallery>
    {
        public void Configure(EntityTypeBuilder<Gallery> builder)
        {
            builder
                .Property(g => g.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .HasIndex(g => g.Name)
                .IsUnique();

            builder
                .HasOne<Event>(g => g.Event)
                .WithMany(e => e.Galleries)
                .HasForeignKey(g => g.EventId)
                .IsRequired();

            
        }
    }
}
