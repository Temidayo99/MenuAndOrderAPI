using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuAndOrder.Data.DTOs.OrderDTO.Request
{
    public class UpdateOrderStatusRequest
    {
        [Required(ErrorMessage = "Order Status is required")]
        public string Status { get; set; }
    }
}
