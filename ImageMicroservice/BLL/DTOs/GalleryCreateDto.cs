
using System.ComponentModel.DataAnnotations;

namespace ImageMicroservice.BLL.DTOs
{
    public class GalleryCreateDto
    {
        [Required]
        public string Name { get; set; }
    }
}