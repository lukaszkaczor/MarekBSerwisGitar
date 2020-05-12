using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SerwisGitar.Models.DbModels
{
    public class ServiceType
    {
        public int ServiceTypeId { get; set; }
       
        [Required]
        public string Name { get; set; }

        public List<Service> Services { get; set; }
    }
}