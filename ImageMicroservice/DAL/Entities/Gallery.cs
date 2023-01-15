
namespace ImageMicroservice.DAL.Entities
{
    public class Gallery
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Image> Images { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}