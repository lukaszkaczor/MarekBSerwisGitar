using System.Collections.Generic;

namespace SerwisGitar.Models.DbModels
{
    public class CustomInstrument
    {
        public int CustomInstrumentId { get; set; }
        public string Name { get; set; }
        public string PrimaryColor { get; set; }
        public string SecondaryColor { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserId { get; set; }

        public Instrument Instrument { get; set; }
        public int? InstrumentId { get; set; }

        public virtual ICollection<CustomInstrumentParts> CustomInstrumentParts { get; set; }
    }
}