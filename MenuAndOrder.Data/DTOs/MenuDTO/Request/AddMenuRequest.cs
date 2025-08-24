using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuAndOrder.Data.DTOs.MenuDTO.Request
{
    public class AddMenuRequest
    {
        [Required(ErrorMessage = "Menu name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Menu description is required")]
        public string Description { get; set; }
        [Range(1, double.MaxValue, ErrorMessage = "Price cannot be negative or less than 1")]
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
    }
}
