using AutoMapper;
using EventMicroservice.BLL.DTOs;
using EventMicroservice.DAL.Entities;
using System.Runtime.CompilerServices;

namespace EventMicroservice.BLL.Configurations
{
    public class AutoMapperConfig : Profile
    {

        public AutoMapperConfig()
        {
            CreateUserMaps();
            CreateEventMaps();
            CreateCategoryMaps();
            CreateCityMaps();
            CreateCountryMaps();
        }
        private void CreateUserMaps()
        {
            CreateMap<User, UserDTO>().ReverseMap();
        }

        private void CreateEventMaps()
        {
            CreateMap<Event, EventResponse>()
                .ForMember(
                    dto => dto.SubscribedUsersAmount,
                    options => options.MapFrom(ev => ev.SubscribedUsers.Count))
                .ForMember(
                    dto => dto.Country,
                    options => options.MapFrom(
                        ev => ev.Country.Name ?? null))
                .ForMember(
                    dto => dto.City,
                    options => options.MapFrom(
                        ev => ev.City.Name ?? null));

            CreateMap<int?, int>().ConvertUsing((src, dest) => src ?? dest);

            CreateMap<EventRequest, Event>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<EventResponse, Event>();
            CreateMap<EventResponse, EventPublishedDto>().ReverseMap();
            CreateMap<Event, Bll.Protos.GrpcEventModel>()
                .ForMember(dest => dest.EventId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }

        private void CreateCategoryMaps()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
        }
        private void CreateCityMaps()
        {
            CreateMap<City, CityDTO>().ReverseMap();
        }
        private void CreateCountryMaps()
        {
            CreateMap<Country, CountryDTO>().ReverseMap();
        }
    }
}
