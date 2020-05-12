using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SerwisGitar.Models.DbModels
{
    public class InstrumentServices
    {
        [Key]
        [Column(Order = 1)]
        public int InstrumentId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int ServiceId { get; set; }

        public virtual Instrument Instrument { get; set; }
        public virtual Service Service { get; set; }
    }
}