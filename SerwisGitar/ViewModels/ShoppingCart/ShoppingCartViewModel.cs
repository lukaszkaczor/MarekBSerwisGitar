using System.Collections.Generic;
using SerwisGitar.Models.DbModels;

namespace SerwisGitar.ViewModels.ShoppingCart
{
    public class ShoppingCartViewModel
    {
        public Instrument Instrument { get; set; }
        public List<Service> Services { get; set; }
    }
}