using ImageMicroservice.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ImageMicroservice.DAL.Configurations.Entities
{
    public class EventConfig : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder
                .Property(g => g.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(g => g.ExternalId)
                .IsRequired();

            builder
                .HasIndex(g => g.Name)
                .IsUnique();

            builder
                .HasMany(e => e.Galleries)
                .WithOne(g => g.Event!)
                .HasForeignKey(g => g.EventId);
        }
    }
}