using System.Collections.Generic;
using SerwisGitar.Models.DbModels;

namespace SerwisGitar.ViewModels.Home
{
    public class HomeGalleryViewModel
    {
        public List<Image> Services { get; set; }
        public List<Image> OurInstruments { get; set; }
    }
}