using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace SerwisGitar.Models.DbModels
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Message { get; set; }
        public string PhoneNumber { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public string ContactEmail { get; set; }

        [DataType(DataType.Currency)]
        public decimal? Price { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        
        public string EmployeeId { get; set; }
        public ApplicationUser Employee { get; set; }

        
        public virtual ICollection<OrderDetailsOrder> OrderDetailsOrder { get; set; }
    }
}