using System.Collections.Generic;
using SerwisGitar.Models.DbModels;

namespace SerwisGitar.ViewModels.Home
{
    public class HomeServicesViewModel
    {
        public Instrument Instrument { get; set; }
        public List<Instrument> Instruments { get; set; }
        public List<Service> Services { get; set; }
    }
}