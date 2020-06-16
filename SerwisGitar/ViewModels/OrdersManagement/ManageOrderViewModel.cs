using System.Collections.Generic;
using SerwisGitar.Models.DbModels;

namespace SerwisGitar.ViewModels.OrdersManagement
{
    public class ManageOrderViewModel
    {
        public Order Order { get; set; }    
        public List<OrderDetails> OrderDetails { get; set; }
    }
}