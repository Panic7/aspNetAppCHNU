using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EventMicroservice.DAL.Entities;

namespace EventMicroservice.DAL.Configurations.Entities
{
    public class RoleConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder
                .Property(r => r.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .HasIndex(r => r.Name)
                .IsUnique();

            builder.HasData(
            new Role
            {
                Id = 1,
                Name = "ADMIN"
            },
            new Role
            {
                Id = 2,
                Name = "MODERATOR"
            },
            new Role
            {
                Id = 3,
                Name = "USER"
            });
        }
    }
}
