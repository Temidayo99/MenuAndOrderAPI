using MenuAndOrder.Data.DTOs.MenuDTO.Request;
using MenuAndOrder.Data.DTOs.OrderDTO.Request;
using MenuAndOrder.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MenuAndOrder.API.Controllers.v1
{
    public class OrdersController : BaseController
    {
        private readonly IOrderService _service;
        private readonly ILogger<MenuController> _logger;
        public OrdersController(IOrderService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest request)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogInformation("Invalid request body");
                return BadRequest(GenerateValidationErrorResponse(ModelState));
            }
            var result = await _service.CreateOrder(request);
            return result != null ? Ok(result) : BadRequest(result);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(long id)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogInformation("Invalid request body");
                return BadRequest(GenerateValidationErrorResponse(ModelState));
            }
            var result = await _service.GetOrderById(id);
            return result != null ? Ok(result) : BadRequest(result);

        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            if (!ModelState.IsValid)
            {
                _logger.LogInformation("Invalid request body");
                return BadRequest(GenerateValidationErrorResponse(ModelState));
            }
            var result = await _service.GetAllOrders();
            return result != null ? Ok(result) : BadRequest(result);

        }

        [HttpPatch("{id}/status")]
        public async Task<IActionResult> UpdateOrderStatus(long id, UpdateOrderStatusRequest request)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogInformation("Invalid request body");
                return BadRequest(GenerateValidationErrorResponse(ModelState));
            }
            var result = await _service.UpdateOrderStatus(id, request);
            return result != null ? Ok(result) : BadRequest(result);

        }
    }
}
