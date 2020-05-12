using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SerwisGitar.Models.DbModels
{
    public class Service
    {
        public int ServiceId { get; set; }

        [Required]
        public string Name { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public virtual ICollection<InstrumentServices> InstrumentServices { get; set; }

        //public Instrument Instrument { get; set; }
        //public int InstrumentId { get; set; }

        public ServiceType ServiceType { get; set; }
        public int ServiceTypeId { get; set; }

        [NotMapped] 
        public bool IsChecked { get; set; }
    }
}