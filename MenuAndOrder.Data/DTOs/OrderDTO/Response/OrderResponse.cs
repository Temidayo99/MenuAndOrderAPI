using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuAndOrder.Data.DTOs.OrderDTO.Response
{
    public class OrderResponse
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; }
        public List<OrderItemResponse> Items { get; set; }
        public decimal Subtotal { get; set; }
        public string Notes { get; set; }
    }

    public class OrderItemResponse
    {
        public int MenuItemId { get; set; }
        public string NameSnapshot { get; set; }
        public decimal UnitPriceSnapshot { get; set; }
        public int Quantity { get; set; }
        public decimal LineTotal { get; set; }
    }
}
