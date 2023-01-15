
using Microsoft.AspNetCore.Http;

namespace ImageMicroservice.BLL.Services
{
    public interface IImageCloudService
    {
        public string UploadImage(IFormFile file);
    }
}