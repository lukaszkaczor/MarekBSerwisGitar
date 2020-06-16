using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SerwisGitar.Models.DbModels
{
    public class OrderDetails
    {
        public int OrderDetailsId { get; set; }

        [Required]
        public int OrderId { get; set; }
        public Order Order { get; set; }

        [DataType(DataType.Currency)]
        public decimal? Price { get; set; }

        public int? ServiceId { get; set; }
        public Service Service { get; set; }

        public int? PartTypeId { get; set; }
        public PartType PartType { get; set; }

        public int? InstrumentId { get; set; }
        public Instrument Instrument { get; set; }

        public int? CustomInstrumentId { get; set; }
        public CustomInstrument CustomInstrument { get; set; }

        public string Description { get; set; }

        public bool IsCompleted { get; set; }

        public virtual ICollection<OrderDetailsOrder> OrderDetailsOrder { get; set; }
    }
}