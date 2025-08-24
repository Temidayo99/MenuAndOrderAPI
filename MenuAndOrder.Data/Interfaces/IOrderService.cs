using MenuAndOrder.Data.DTOs.GenericDto;
using MenuAndOrder.Data.DTOs.OrderDTO.Request;
using MenuAndOrder.Data.DTOs.OrderDTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuAndOrder.Data.Interfaces
{
    public interface IOrderService
    {
        Task<BaseResponse<CreateOrderResponse>> CreateOrder(CreateOrderRequest request);

        Task<BaseResponse<OrderResponse>> GetOrderById(long id);

        Task<BaseResponse<List<OrderResponse>>> GetAllOrders();

        Task<BaseResponse<bool>> UpdateOrderStatus(long id, UpdateOrderStatusRequest request);
    }
}
