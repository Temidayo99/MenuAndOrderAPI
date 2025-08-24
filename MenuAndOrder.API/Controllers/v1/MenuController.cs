using Asp.Versioning;
using MenuAndOrder.Data.DTOs.MenuDTO.Request;
using MenuAndOrder.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MenuAndOrder.API.Controllers.v1
{
    [ApiVersion("1")]
    public class MenuController : BaseController
    {
        private readonly IMenuService _service;
        private readonly ILogger<MenuController> _logger;
        public MenuController(IMenuService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetMenus()
        {
            return Ok(await _service.GetMenus());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMenuById(long id)
        {
            return Ok(await _service.GetMenuById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddMenu([FromBody] AddMenuRequest request)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogInformation("Invalid request body");
                return BadRequest(GenerateValidationErrorResponse(ModelState));
            }
            var result = await _service.AddMenu(request);
            return result != null ? Ok(result) : BadRequest(result);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMenu(long id, [FromBody] UpdateMenuRequest request)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogInformation("Invalid request body");
                return BadRequest(GenerateValidationErrorResponse(ModelState));
            }
            var result = await _service.UpdateMenu(id, request);
            return result != null ? Ok(result) : BadRequest(result);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenu(long id)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogInformation("Invalid request body");
                return BadRequest(GenerateValidationErrorResponse(ModelState));
            }
            var result = await _service.DeleteMenu(id);
            return result != null ? Ok(result) : BadRequest(result);

        }
    }
}
