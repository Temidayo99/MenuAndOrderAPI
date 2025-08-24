using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuAndOrder.Data.DatabaseEntities
{
    public class OrderItem
    {
        public int Id { get; set; }

       //Link back to the Order
        public int OrderId { get; set; }
        public Order Order { get; set; } = default!;

        // Link back to MenuItem
        public int MenuItemId { get; set; }  
        public MenuItem MenuItem { get; set; } = default!;

        public string NameSnapshot { get; set; } //copy of the item name at time of order
        public decimal UnitPriceSnapshot { get; set; } //copy of price at time of order
        public int Quantity { get; set; }
        public decimal LineTotal { get; set; }
    }
}
