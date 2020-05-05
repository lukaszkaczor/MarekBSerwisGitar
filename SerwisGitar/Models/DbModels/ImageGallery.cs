using System.ComponentModel.DataAnnotations;

namespace SerwisGitar.Models.DbModels
{
    public class ImageGallery
    {
        [Key]
        public int GalleryId { get; set; }
        public virtual Gallery Gallery { get; set; }

        [Key]
        public int ImageId { get; set; }
        public virtual Image Image { get; set; }

        public int? Order { get; set; }
    }
}