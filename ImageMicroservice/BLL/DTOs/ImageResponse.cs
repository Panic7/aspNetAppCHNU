namespace ImageMicroservice.BLL.DTOs
{
    public class ImageResponse
    {
        public int? Id { get; set; }
        public string Uri { get; set; }
        public string Description { get; set; }
        public int GalleryId { get; set; }
    }
}