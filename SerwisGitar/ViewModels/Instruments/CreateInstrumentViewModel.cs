using System.Collections.Generic;
using SerwisGitar.Models.DbModels;

namespace SerwisGitar.ViewModels.Instruments
{
    public class CreateInstrumentViewModel
    {
        public Instrument Instrument { get; set; }
        public List<Service> Services { get; set; }
    }
}