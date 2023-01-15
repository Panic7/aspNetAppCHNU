
using AutoMapper;
using ImageMicroservice.BLL.DTOs;
using ImageMicroservice.DAL.Entities;
using ImageMicroservice.DAL.Repositories;
using Microsoft.Extensions.Logging;

namespace ImageMicroservice.BLL.Services
{
    public class ImageService
    {
        private readonly IImageCloudService imageCloudService;
        private readonly ImageRepository imageRepository;
        private readonly IMapper mapper;
        private readonly ILogger<ImageService> logger;

        public ImageService(ImageRepository imageRepository, IMapper mapper,
        IImageCloudService imageCloudService, ILogger<ImageService> logger)
        {
            this.imageRepository = imageRepository;
            this.mapper = mapper;
            this.imageCloudService = imageCloudService;
            this.logger = logger;
        }

        public async Task<ImageResponse> GetAsync(int id)
        {
            var image = await imageRepository.GetAsync(id);

            return mapper.Map<ImageResponse>(image);
        }

        public async Task<ImageResponse> CreateAsync(ImageRequest dto)
        {
            dto.Id = null;
            var image = mapper.Map<Image>(dto);
            image.Uri = imageCloudService.UploadImage(dto.Image);

            image = await imageRepository.CreateAsync(image);

            return mapper.Map<ImageResponse>(image);
        }

        public async Task UpdateAsync(ImageRequest dto)
        {
            var image = mapper.Map<Image>(dto);
            image.Uri = imageCloudService.UploadImage(dto.Image);

            await imageRepository.UpdateAsync(image);
        }

        public async Task DeleteAsync(int id)
        {
            await imageRepository.DeleteAsync(id);
        }
    }
}