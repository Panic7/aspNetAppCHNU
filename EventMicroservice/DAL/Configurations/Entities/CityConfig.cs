using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EventMicroservice.DAL.Entities;

namespace EventMicroservice.DAL.Configurations.Entities
{
    public class CityConfig : IEntityTypeConfiguration<City>
    {

        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder
               .Property(c => c.Name)
               .HasMaxLength(100)
               .IsRequired();

            builder
                .HasIndex(c => c.Name)
                .IsUnique();

            builder
                .HasOne<Country>(city => city.Country)
                .WithMany(c => c.Cities)
                .HasForeignKey(city => city.CountryId);

            builder.HasData(
            new City
            {
                Id = 1,
                Name = "Lodz",
                CountryId = 4
            },
            new City
            {
                Id = 2,
                Name = "Poznan",
                CountryId = 4
            },
            new City
            {
                Id = 3,
                Name = "Warszawa",
                CountryId = 4
            },
            new City
            {
                Id = 4,
                Name = "Lublin",
                CountryId = 4
            },
            new City
            {
                Id = 5,
                Name = "Krakow",
                CountryId = 4
            },
            new City
            {
                Id = 6,
                Name = "Berlin",
                CountryId = 5
            },
            new City
            {
                Id = 7,
                Name = "Hannover",
                CountryId = 5
            },
            new City
            {
                Id = 8,
                Name = "Amsterdam",
                CountryId = 5
            },
            new City
            {
                Id = 9,
                Name = "Hamburg",
                CountryId = 5
            },
            new City
            {
                Id = 10,
                Name = "Shuttgart",
                CountryId = 5
            },
            new City
            {
                Id = 11,
                Name = "Roma",
                CountryId = 3
            },
            new City
            {
                Id = 12,
                Name = "Firenze",
                CountryId = 3
            },
            new City
            {
                Id = 13,
                Name = "Bologna",
                CountryId = 3
            },
            new City
            {
                Id = 14,
                Name = "Genova",
                CountryId = 3
            },
            new City
            {
                Id = 15,
                Name = "Milano",
                CountryId = 3
            },
            new City
            {
                Id = 16,
                Name = "Madrid",
                CountryId = 2
            },
            new City
            {
                Id = 17,
                Name = "Sevilla",
                CountryId = 2
            },
            new City
            {
                Id = 18,
                Name = "Valencia",
                CountryId = 2
            },
            new City
            {
                Id = 19,
                Name = "Zaragoza",
                CountryId = 2
            },
            new City
            {
                Id = 20,
                Name = "Barcelona",
                CountryId = 2
            },
            new City
            {
                Id = 21,
                Name = "Krimea",
                CountryId = 1
            },
            new City
            {
                Id = 22,
                Name = "Chernihiv",
                CountryId = 1
            },
            new City
            {
                Id = 23,
                Name = "Chornobaivka",
                CountryId = 1
            },
            new City
            {
                Id = 24,
                Name = "Chernivtsi",
                CountryId = 1
            },
            new City
            {
                Id = 25,
                Name = "Vinnytsia",
                CountryId = 1
            });
        }
    }
}
