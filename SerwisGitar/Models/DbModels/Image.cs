using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SerwisGitar.Models.DbModels
{
    public class Image
    {
        public int ImageId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Url { get; set; }

        public virtual ICollection<ImageGallery> ImageGalleries { get; set; }

    }
}