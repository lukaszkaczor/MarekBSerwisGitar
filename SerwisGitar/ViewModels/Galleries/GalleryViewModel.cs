using System.Collections.Generic;
using SerwisGitar.Models.DbModels;

namespace SerwisGitar.ViewModels.Galleries
{
    public class GalleryViewModel
    {
        public List<Image> Images { get; set; }
        public Gallery Gallery { get; set; }
        public List<ImageGallery> ImageGalleries { get; set; } 
    }
}