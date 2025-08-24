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
        [Route("create-order")]
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

        [HttpGet]
        [Route("get-order-by-id")]
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
        [Route("get-all-orders")]
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

        [HttpPatch]
        [Route("update-status")]
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
