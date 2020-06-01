using System.ComponentModel.DataAnnotations;

namespace SerwisGitar.Models.DbModels
{
    public class ShoppingCart
    {
        public int ShoppingCartId { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        
        //[Required]
        public int? InstrumentId { get; set; }
        public Instrument Instrument { get; set; }


        public int? CustomInstrumentId { get; set; }
        public CustomInstrument CustomInstrument { get; set; }

        //[Required]
        public int? ServiceId { get; set; }

        public Service Service { get; set; }

        public string ServiceDescription { get; set; }
    }
}