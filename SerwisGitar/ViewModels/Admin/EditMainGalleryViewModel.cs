using System.Collections.Generic;
using SerwisGitar.Models.DbModels;

namespace SerwisGitar.ViewModels.Admin
{
    public class EditMainGalleryViewModel
    {
        public MainGallery Gallery { get; set; }
        public List<Gallery> Galleries { get; set; }
    }
}