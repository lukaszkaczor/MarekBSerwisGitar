using System.Collections.Generic;
using SerwisGitar.Models.AppModels;
using SerwisGitar.Models.DbModels;

namespace SerwisGitar.ViewModels.CustomInstruments
{
    public class CustomInstrumentViewModel
    {
        public List<Instrument> Instruments { get; set; }
        public List<PartType> PartTypes { get; set; }

        public List<GuitarPart> SelectedParts { get; set; }
        public Instrument Instrument { get; set; }

        public string PrimaryColor { get; set; }

        public string SecondaryColor { get; set; }
        //public string S { get; set; }
        //public List<TypeWithItsParts> PartsList { get; set; }
    }
}