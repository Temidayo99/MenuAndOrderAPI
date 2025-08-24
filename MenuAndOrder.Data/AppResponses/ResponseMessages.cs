using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuAndOrder.Data.AppResponses
{
    public class ResponseMessages
    {
        public const string Success = "Successful";
        public const string MenuExist = "Menu already exist.";
        public const string MenuCreationSuccessful = "Menu created successfully.";
        public const string MenuCreationFailed = "Menu creation failed.";
        public const string MenuNotFound = "No Menu Found.";
        public const string MenuIdNotFound = "Menu Id Supplied Not Found.";
        public const string MenuUpdateSuccessful = "Menu updated successfully.";
        public const string MenuDeletedSuccessful = "Menu deleted successfully.";
        public const string OrderAndQuantity = "Order must have at least 1 item with quantity greater than or equal to 1";
        public const string OrderCreationSuccessful = "Order created successfully.";
        public const string MenuItemNotAvailable = "Menu Item Not Available";
        public const string OrderCreationFailed = "Order creation failed.";
        public const string OrderNotFound = "No Order Found.";
        public const string OrderIdNotFound = "Order Id Supplied Not Found.";
        public const string OrderStatusUpdateSuccessful = "Order status updated successfully.";
        public const string Exception = "Something went wrong, please try again later.";
    }
}
