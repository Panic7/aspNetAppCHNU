
namespace ImageMicroservice.BLL.DTOs
{
    public class GalleryReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ImageResponse> Images { get; set; }
        public int EventId { get; set; }
    }
}