using System.Collections.Generic;

namespace SerwisGitar.Models.DbModels
{
    public class GuitarPart
    {
        public int GuitarPartId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        public int PartTypeId { get; set; }
        public PartType PartType { get; set; }

        public virtual ICollection<CustomInstrumentParts> CustomInstrumentParts { get; set; }
    }
}