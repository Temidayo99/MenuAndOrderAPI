using MenuAndOrder.Data.DatabaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuAndOrder.Data.DTOs.OrderDTO.Request
{
    public class CreateOrderRequest
    {
        [Required(ErrorMessage = "Customer's name is required")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Customer's phone number is required")]
        public string CustomerPhone { get; set; }
        public List<Items> Item { get; set; }
        public string? Notes { get; set; }
    }

    public class Items
    {
        public int MenuItemId { get; set; }
        public int Quantity { get; set; }
    }

}
