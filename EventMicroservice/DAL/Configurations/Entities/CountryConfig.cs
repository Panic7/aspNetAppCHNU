using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EventMicroservice.DAL.Entities;

namespace EventMicroservice.DAL.Configurations.Entities
{
    public class CountryConfig : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder
                .Property(c => c.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .HasIndex(c => c.Name)
                .IsUnique();

            builder.HasData(
            new Country
            {
                Id = 1,
                Name = "Ukraine"
            },
            new Country
            {
                Id = 2,
                Name = "Spain"
            },
            new Country
            {
                Id = 3,
                Name = "Italy"
            },
            new Country
            {
                Id = 4,
                Name = "Poland"
            },
            new Country
            {
                Id = 5,
                Name = "Germany"
            });
        }
    }
}
