using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EventMicroservice.DAL.Entities;

namespace EventMicroservice.DAL.Configurations.Entities
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
                .HasIndex(c => c.Name)
                .IsUnique();

            builder
                .Property(c => c.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasData
            (
                new Category
                {
                    Id = 1,
                    Name = "Family"
                },
                new Category
                {
                    Id = 2,
                    Name = "Game industry"
                },
                new Category
                {
                    Id = 3,
                    Name = "Stand up"
                },
                new Category
                {
                    Id = 4,
                    Name = "Nature"
                },
                new Category
                {
                    Id = 5,
                    Name = "Health"
                }
            );
        }
    }
}
