using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SerwisGitar.Models.DbModels
{
    public class Instrument
    {
        public int InstrumentId { get; set; }
        
        [Required]
        public string Name { get; set; }

        public virtual ICollection<InstrumentServices> InstrumentServices { get; set; }
    }
}