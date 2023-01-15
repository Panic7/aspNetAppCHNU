
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ImageMicroservice.BLL.Services
{
    public class CloudinaryService : IImageCloudService
    {
        private readonly Cloudinary cloudinary;
        private readonly ILogger<CloudinaryService> logger;

        public CloudinaryService(ILogger<CloudinaryService> logger, IConfiguration configuration)
        {
            string CLOUD_NAME, API_KEY, API_SECRET;

            CLOUD_NAME = configuration["CloudinarySettings:CloudName"];
            API_KEY = configuration["CloudinarySettings:ApiKey"];
            API_SECRET = configuration["CloudinarySettings:ApiSecret"];
            var account = new Account(CLOUD_NAME, API_KEY, API_SECRET);
            cloudinary = new Cloudinary(account);

            this.logger = logger;
        }

        public string UploadImage(IFormFile file)
        {
            ImageUploadResult uploadResult;

            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(file.Name, stream)
                };

                uploadResult = cloudinary.Upload(uploadParams);
                logger.LogInformation($"Absolute image path = {uploadResult.Url.AbsoluteUri}");

                return uploadResult.Url.AbsoluteUri;
            }
            else
            {
                logger.LogError("CloudinaryService -> UploadImage -> file was empty. Returned empty string.");
                return "";
            }
        }
    }
}