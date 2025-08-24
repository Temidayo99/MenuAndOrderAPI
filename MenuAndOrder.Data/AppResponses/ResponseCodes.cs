using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuAndOrder.Data.AppResponses
{
    public static class ResponseCodes
    {
        public const string Success = "00";
        public const string MenuAlreadyExist = "01";
        public const string MenuCreationFailed = "02";
        public const string MenuNotFound = "03";
        public const string OrderAndQuantity = "04";
        public const string OrderCreationFailed = "05";
        public const string MenuItemNotAvailable = "06";
        public const string OrderNotFound = "07";
        public const string ValidationError = "57";
        public const string Exception = "99";
    }
}
