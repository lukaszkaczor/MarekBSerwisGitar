using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SerwisGitar.Models.DbModels
{
    public class CustomInstrumentParts
    {
        [Key]
        public int CustomInstrumentId { get; set; }
        public virtual CustomInstrument CustomInstrument { get; set; }

        [Key]
        public int GuitarPartId { get; set; }
        public virtual GuitarPart GuitarPart { get; set; }
    }
}