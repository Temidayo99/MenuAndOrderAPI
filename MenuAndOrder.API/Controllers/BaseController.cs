using MenuAndOrder.Data.AppResponses;
using MenuAndOrder.Data.DTOs.GenericDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MenuAndOrder.API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private List<string> ValidationError(ModelStateDictionary modelState)
        {
            return modelState
                .Values
                .SelectMany(error => error.Errors)
                .Select(message => message.ErrorMessage)
                .ToList();
        }

        internal BaseResponse<bool> GenerateValidationErrorResponse(ModelStateDictionary modelState)
        {
            var error = ValidationError(modelState).FirstOrDefault();

            return new BaseResponse<bool>(ResponseCodes.ValidationError, error ?? "Model validation error");
        }
    }
}
