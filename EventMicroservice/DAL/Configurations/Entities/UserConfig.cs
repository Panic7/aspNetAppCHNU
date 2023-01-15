using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EventMicroservice.DAL.Entities;

namespace EventMicroservice.DAL.Configurations.Entities
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                 .Property(c => c.FirstName)
                 .HasMaxLength(50)
                 .IsRequired();

            builder
                .Property(c => c.SecondName)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(c => c.Email)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(c => c.Password)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(c => c.Phone)
                .HasMaxLength(50);

            builder
                .HasIndex(c => c.Email)
                .IsUnique();

            builder
                .HasOne<Role>(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId);

            builder
                .HasOne<Country>(u => u.Country)
                .WithMany(c => c.Users)
                .HasForeignKey(u => u.CountryId);

            builder
                .HasOne<City>(u => u.City)
                .WithMany(c => c.Users)
                .HasForeignKey(u => u.CityId);

            builder.HasData(
            new User
            {
                Id = 1,
                FirstName = "Esmaralda",
                SecondName = "Voigt",
                Email = "qwer@gmail.com",
                Phone = "+380991231212",
                Password = "qwert",
                CountryId = 1,
                CityId = 24,
                RoleId = 1
            },
                new User
                {
                    Id = 2,
                    FirstName = "Ostap",
                    SecondName = "Bleier",
                    Email = "qwerr@gmail.com",
                    Phone = "+380991231212",
                    Password = "qwert",
                    CountryId = 1,
                    CityId = 24,
                    RoleId = 2
                },
                new User
                {
                    Id = 3,
                    FirstName = "Sophia",
                    SecondName = "Beringer",
                    Email = "qwerrr@gmail.com",
                    Phone = "+380991231212",
                    Password = "qwert",
                    CountryId = 1,
                    CityId = 24,
                    RoleId = 2
                },
                new User
                {
                    Id = 4,
                    FirstName = "Marlyn",
                    SecondName = "Hendry",
                    Email = "qwerrrr@gmail.com",
                    Phone = "+380991231212",
                    Password = "qwert",
                    CountryId = 1,
                    CityId = 23,
                    RoleId = 3
                },
                new User
                {
                    Id = 5,
                    FirstName = "Vlasi",
                    SecondName = "Arterberry",
                    Email = "qwerq@gmail.com",
                    Phone = "+380991231212",
                    Password = "qwert",
                    CountryId = 2,
                    CityId = 16,
                    RoleId = 3
                },
                new User
                {
                    Id = 6,
                    FirstName = "Chasity",
                    SecondName = "Ilbert",
                    Email = "qwerqq@gmail.com",
                    Phone = "+380991231212",
                    Password = "qwert",
                    CountryId = 3,
                    CityId = 15,
                    RoleId = 3
                },
                new User
                {
                    Id = 7,
                    FirstName = "Seraphina",
                    SecondName = "Salmon",
                    Email = "qwerqqq@gmail.com",
                    Phone = "+380991231212",
                    Password = "qwert",
                    CountryId = 3,
                    CityId = 15,
                    RoleId = 3
                },
                new User
                {
                    Id = 8,
                    FirstName = "Chas",
                    SecondName = "Hope",
                    Email = "qwerw@gmail.com",
                    Phone = "+380991231212",
                    Password = "qwert",
                    CountryId = 4,
                    CityId = 2,
                    RoleId = 3
                },
                new User
                {
                    Id = 9,
                    FirstName = "Nadezhda",
                    SecondName = "Haynes",
                    Email = "qwerww@gmail.com",
                    Phone = "+380991231212",
                    Password = "qwert",
                    CountryId = 5,
                    CityId = 6,
                    RoleId = 3
                },
                new User
                {
                    Id = 10,
                    FirstName = "Sonny",
                    SecondName = "Gibb",
                    Email = "qwerwww@gmail.com",
                    Phone = "+380991231212",
                    Password = "qwert",
                    CountryId = 5,
                    CityId = 10,
                    RoleId = 3
                },
                new User
                {
                    Id = 11,
                    FirstName = "Eric",
                    SecondName = "Lincoln",
                    Email = "qwere@gmail.com",
                    Phone = "+380991231212",
                    Password = "qwert",
                    CountryId = 5,
                    CityId = 8,
                    RoleId = 3
                });
        }
    }
}
