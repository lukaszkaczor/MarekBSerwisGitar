using System.Collections.Generic;
using SerwisGitar.Models.DbModels;

namespace SerwisGitar.Models.AppModels
{
    public class InstrumentWithService
    {
        public int InstrumentId { get; set; }
        public string InstrumentName { get; set; }

        //public List<Service> Services { get; set; }
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public decimal ServicePrice { get; set; }

        //public int ServiceTypeId { get; set; }
        public string ServiceTypeName { get; set; }

    }
}