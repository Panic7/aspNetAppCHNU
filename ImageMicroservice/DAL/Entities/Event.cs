
using System.ComponentModel.DataAnnotations;

namespace ImageMicroservice.DAL.Entities
{
    public class Event
    {
        public int? Id { get; set; }
        public int ExternalId { get; set; }
        public string Name { get; set; }
        public ICollection<Gallery> Galleries { get; set; } = new List<Gallery>();
    }
}