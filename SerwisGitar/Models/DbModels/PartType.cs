using System.Collections.Generic;

namespace SerwisGitar.Models.DbModels
{
    public class PartType
    {
        public int PartTypeId { get; set; }
        public string Name { get; set; }
        public List<GuitarPart> GuitarParts { get; set; }
    }
}