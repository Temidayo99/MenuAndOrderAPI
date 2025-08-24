using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuAndOrder.Data.DTOs.GenericDto
{
    public class BaseResponse<T>
    {
        public T? Data { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        //public bool IsSuccessful { get; set; }

        public BaseResponse(string code, string message)
        {
            ResponseCode = code;
            ResponseMessage = message;
        }

        public BaseResponse(T? data, string code, string message)
        {
            Data = data;
            ResponseCode = code;
            ResponseMessage = message;
        }
    }
}
