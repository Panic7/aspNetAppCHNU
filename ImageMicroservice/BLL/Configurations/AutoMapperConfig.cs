using AutoMapper;
using EventMicroservice.Bll.Protos;
using ImageMicroservice.BLL.DTOs;
using ImageMicroservice.DAL.Entities;

namespace ImageMicroservice.BLL.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateImageMaps();
            CreateGalleryMaps();
            CreateEventMaps();
        }
        private void CreateImageMaps()
        {
            CreateMap<Image, ImageResponse>().ReverseMap();

            CreateMap<Image, ImageRequest>().ReverseMap();
        }
        private void CreateGalleryMaps()
        {
            CreateMap<Gallery, GalleryCreateDto>().ReverseMap();
            CreateMap<Gallery, GalleryReadDto>().ReverseMap();
            CreateMap<Event, EventReadDto>().ReverseMap();
        }
        private void CreateEventMaps()
        {
            CreateMap<EventPublishedDto, Event>()
                .ForMember(dest => dest.ExternalId, opt => opt.MapFrom(src => src.Id));
            CreateMap<GrpcEventModel, Event>()
                .ForMember(dest => dest.ExternalId, opt => opt.MapFrom(src => src.EventId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Galleries, opt => opt.Ignore());
        }
    }
}