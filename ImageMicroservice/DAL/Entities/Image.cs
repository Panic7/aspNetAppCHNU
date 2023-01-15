
namespace ImageMicroservice.DAL.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public string Uri { get; set; }
        public string? Description { get; set; }
        public int? GalleryId { get; set; }
        public Gallery? Gallery { get; set; }
    }
}