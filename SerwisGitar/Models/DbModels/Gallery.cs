using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SerwisGitar.Models.DbModels
{
    public class Gallery
    {
        public int GalleryId { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<ImageGallery> ImageGalleries { get; set; }
    }
}