using System.ComponentModel.DataAnnotations.Schema;

namespace SerwisGitar.Models.DbModels
{
    public class MainGallery
    {
        public int Id { get; set; }

        [ForeignKey("ServiceGallery")]
        public int? ServiceGalleryId { get; set; }
        public Gallery ServiceGallery { get; set; }

        [ForeignKey("OurInstruments")]
        public int? OurInstrumentsId { get; set; }
        public Gallery OurInstruments { get; set; }
    }
}