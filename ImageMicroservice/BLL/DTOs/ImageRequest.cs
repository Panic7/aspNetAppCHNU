using Microsoft.AspNetCore.Http;

namespace ImageMicroservice.BLL.DTOs
{
    public class ImageRequest
    {
        public int? Id { get; set; }
        public IFormFile Image { get; set; }
        public string Description { get; set; }
        public int GalleryId { get; set; }
    }
}