using SerwisGitar.Models.DbModels;

namespace SerwisGitar.ViewModels.Galleries
{
    public class AddImageViewModel
    {
        public Image Image { get; set; }
        public ImageGallery ImageGallery { get; set; }
        public Gallery Gallery { get; set; }
    }
}