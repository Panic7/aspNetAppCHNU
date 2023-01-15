using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EventMicroservice.DAL.Entities;

namespace EventMicroservice.DAL.Configurations.Entities
{
    public class EventConfig : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder
                .HasIndex(c => c.Name)
                .IsUnique();

            builder
                .Property(c => c.Name)
                .HasMaxLength(250)
                .IsRequired();
            builder
                .HasOne<Country>(e => e.Country)
                .WithMany(c => c.Events)
                .HasForeignKey(e => e.CountryId);
            builder
                .HasOne<City>(e => e.City)
                .WithMany(c => c.Events)
                .HasForeignKey(e => e.CityId);
            builder
                .HasOne<User>(e => e.Author)
                .WithMany(u => u.CreatedEvents)
                .HasForeignKey(e => e.AuthorId);
            builder
                .HasMany(left => left.Categories)
                .WithMany(right => right.Events)
                .UsingEntity
                (
                    "EventCategory", typeof(Dictionary<string, object>),
                    right => right.HasOne(typeof(Category)).WithMany().HasForeignKey("CategoryId"),
                    left => left.HasOne(typeof(Event)).WithMany().HasForeignKey("EventId"),
                    join => join.ToTable("EventCategory")
                );
            builder
                .HasMany(left => left.SubscribedUsers)
                .WithMany(right => right.SubscribedEvents)
                .UsingEntity
                (
                    "EventUser", typeof(Dictionary<string, object>),
                    right => right.HasOne(typeof(User)).WithMany().HasForeignKey("UserId"),
                    left => left.HasOne(typeof(Event)).WithMany().HasForeignKey("EventId"),
                    join => join.ToTable("EventUser")
                );

            builder.HasData
                (
                new Event
                {
                    Id = 1,
                    Name = "Domestic Violence",
                    CountryId = 1,
                    CityId = 24,
                    AuthorId = 1
                },
            new Event
            {
                Id = 2,
                Name = "Love is the basis of life",
                CountryId = 1,
                CityId = 24,
                AuthorId = 1
            },
            new Event
            {
                Id = 3,
                Name = "Global Gaming Expo 2022",
                CountryId = 1,
                CityId = 23,
                AuthorId = 1
            },
            new Event
            {
                Id = 4,
                Name = "Sweden Game Conference 2022",
                CountryId = 1,
                CityId = 23,
                AuthorId = 1
            },
            new Event
            {
                Id = 5,
                Name = "SBC Summit CIS 2022",
                CountryId = 1,
                CityId = 22,
                AuthorId = 2
            },
            new Event
            {
                Id = 6,
                Name = "International Stand Up Comedy",
                CountryId = 2,
                CityId = 16,
                AuthorId = 2
            },
            new Event
            {
                Id = 7,
                Name = "Cancel Culture Comedy",
                CountryId = 2,
                CityId = 16,
                AuthorId = 2
            },
            new Event
            {
                Id = 8,
                Name = "Failing in Love",
                CountryId = 2,
                CityId = 16,
                AuthorId = 3
            },
            new Event
            {
                Id = 9,
                Name = "Earth Day 2022",
                CountryId = 3,
                CityId = 15,
                AuthorId = 3
            },
            new Event
            {
                Id = 10,
                Name = "Sounds at Sunset Concert Series",
                CountryId = 3,
                CityId = 15,
                AuthorId = 3
            },
            new Event
            {
                Id = 11,
                Name = "Playscape Mondays",
                CountryId = 3,
                CityId = 15,
                AuthorId = 3
            },
            new Event
            {
                Id = 12,
                Name = "Folk & Roots",
                CountryId = 3,
                CityId = 15,
                AuthorId = 3
            },
            new Event
            {
                Id = 13,
                Name = "Annual Migration Festival",
                CountryId = 3,
                CityId = 15,
                AuthorId = 3
            },
            new Event
            {
                Id = 14,
                Name = "Chronic Disease and Self-Help Program Lay Leader Training",
                CountryId = 4,
                CityId = 2,
                AuthorId = 3
            },
            new Event
            {
                Id = 15,
                Name = "AI & Medical Imaging",
                CountryId = 5,
                CityId = 10,
                AuthorId = 3
            },
            new Event
            {
                Id = 16,
                Name = "Duitslanddag",
                CountryId = 5,
                CityId = 10,
                AuthorId = 3
            },
            new Event
            {
                Id = 17,
                Name = "Emerging Technologies in Health",
                CountryId = 5,
                CityId = 6,
                AuthorId = 4
            });
        }

        public static void EventCategorySeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity("EventCategory")
                .HasData(
                new
                {
                    EventId = 1,
                    CategoryId = 1
                },
                new
                {
                    EventId = 2,
                    CategoryId = 1
                },
                new
                {
                    EventId = 2,
                    CategoryId = 4
                },
                new
                {
                    EventId = 2,
                    CategoryId = 5
                },
                new
                {
                    EventId = 3,
                    CategoryId = 2
                },
                new
                {
                    EventId = 4,
                    CategoryId = 2
                },
                new
                {
                    EventId = 5,
                    CategoryId = 2
                },
                new
                {
                    EventId = 6,
                    CategoryId = 3
                },
                new
                {
                    EventId = 7,
                    CategoryId = 3
                },
                new
                {
                    EventId = 8,
                    CategoryId = 4
                },
                new
                {
                    EventId = 9,
                    CategoryId = 4
                },
                new
                {
                    EventId = 10,
                    CategoryId = 4
                },
                new
                {
                    EventId = 11,
                    CategoryId = 4
                },
                new
                {
                    EventId = 12,
                    CategoryId = 4
                },
                new
                {
                    EventId = 13,
                    CategoryId = 4
                },
                new
                {
                    EventId = 14,
                    CategoryId = 5
                },
                new
                {
                    EventId = 15,
                    CategoryId = 5
                },
                new
                {
                    EventId = 16,
                    CategoryId = 5
                },
                new
                {
                    EventId = 17,
                    CategoryId = 5
                }
                );
        }

        public static void EventUserSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity("EventUser")
                .HasData(
                new
                {
                    EventId = 1,
                    UserId = 1
                }, new
                {
                    EventId = 1,
                    UserId = 2
                }, new
                {
                    EventId = 1,
                    UserId = 3
                }, new
                {
                    EventId = 1,
                    UserId = 4
                }, new
                {
                    EventId = 1,
                    UserId = 5
                },
                new
                {
                    EventId = 2,
                    UserId = 1
                },
                new
                {
                    EventId = 2,
                    UserId = 2
                },
                new
                {
                    EventId = 2,
                    UserId = 3
                },
                new
                {
                    EventId = 3,
                    UserId = 1
                },
                new
                {
                    EventId = 4,
                    UserId = 1
                },
                new
                {
                    EventId = 5,
                    UserId = 2
                },
                new
                {
                    EventId = 6,
                    UserId = 3
                },
                new
                {
                    EventId = 7,
                    UserId = 4
                },
                new
                {
                    EventId = 8,
                    UserId = 5
                },
                new
                {
                    EventId = 9,
                    UserId = 2
                },
                new
                {
                    EventId = 10,
                    UserId = 3
                },
                new
                {
                    EventId = 11,
                    UserId = 4
                },
                new
                {
                    EventId = 12,
                    UserId = 5
                },
                new
                {
                    EventId = 13,
                    UserId = 4
                },
                new
                {
                    EventId = 13,
                    UserId = 5
                },
                new
                {
                    EventId = 13,
                    UserId = 3
                },
                new
                {
                    EventId = 14,
                    UserId = 5
                },
                new
                {
                    EventId = 15,
                    UserId = 5
                },
                new
                {
                    EventId = 16,
                    UserId = 5
                },
                new
                {
                    EventId = 17,
                    UserId = 5
                }
                );
        }
    }
}
