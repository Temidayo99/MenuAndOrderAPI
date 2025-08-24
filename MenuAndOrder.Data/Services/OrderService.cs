using MenuAndOrder.Data.AppResponses;
using MenuAndOrder.Data.DatabaseEntities;
using MenuAndOrder.Data.DataContext;
using MenuAndOrder.Data.DTOs.GenericDto;
using MenuAndOrder.Data.DTOs.MenuDTO.Request;
using MenuAndOrder.Data.DTOs.MenuDTO.Response;
using MenuAndOrder.Data.DTOs.OrderDTO.Request;
using MenuAndOrder.Data.DTOs.OrderDTO.Response;
using MenuAndOrder.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuAndOrder.Data.Services
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _context;
        private readonly ILogger<MenuService> _logger;
        public OrderService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<BaseResponse<CreateOrderResponse>> CreateOrder(CreateOrderRequest request)
        {
            var response = new CreateOrderResponse();
            if (request.Item == null || !request.Item.Any(i => i.Quantity >= 1))
            {
                return new BaseResponse<CreateOrderResponse>(response, ResponseCodes.OrderAndQuantity, ResponseMessages.OrderAndQuantity);
            }
            try
            {
                var order = new Order
                {
                    CustomerName = request.CustomerName,
                    CustomerPhone = request.CustomerPhone,
                    CreatedAt = DateTime.UtcNow,
                    Status = "Pending",
                    Notes = request.Notes,
                    Items = new List<OrderItem>()
                };

                foreach (var reqItem in request.Item)
                {
                    var menuItem = await _context.MenuItems
                        .FirstOrDefaultAsync(x => x.Id == reqItem.MenuItemId);

                    if (menuItem == null)
                    {
                        return new BaseResponse<CreateOrderResponse>(response, ResponseCodes.MenuNotFound, ResponseMessages.MenuNotFound);
                    }

                    if (menuItem.IsAvailable != true) 
                    {
                        return new BaseResponse<CreateOrderResponse>(response, ResponseCodes.MenuItemNotAvailable, ResponseMessages.MenuItemNotAvailable);
                    }
                        
                    order.Items.Add(new OrderItem
                    {
                        Order = order,
                        MenuItemId = reqItem.MenuItemId,
                        NameSnapshot = menuItem.Name,
                        UnitPriceSnapshot = menuItem.Price,
                        Quantity = reqItem.Quantity,
                        LineTotal = menuItem.Price * reqItem.Quantity
                    });

                }
                order.Subtotal = order.Items.Sum(i => i.UnitPriceSnapshot * i.Quantity);

                _context.Orders.Add(order);
                await _context.SaveChangesAsync();

                response.OrderId = order.Id;

                return new BaseResponse<CreateOrderResponse>(response, ResponseCodes.Success, ResponseMessages.OrderCreationSuccessful);

            }
            catch (Exception ex)
            {
                // log the exception
                _logger.LogError(ex, "An error occurred while creating the menu");
                return new BaseResponse<CreateOrderResponse>(response, ResponseCodes.Exception, ResponseMessages.Exception);
            }
        }

        public async Task<BaseResponse<OrderResponse>> GetOrderById(long id)
        {
            try
            {
                var order = await _context.Orders
                        .Where(x => x.Id == id)
                        .Select(x => new OrderResponse()
                        {
                            Id = x.Id,
                            CustomerName = x.CustomerName,
                            CreatedAt = x.CreatedAt,
                            Status = x.Status,

                            Items = x.Items.Select(i => new OrderItemResponse
                            {
                                MenuItemId = i.MenuItemId,
                                NameSnapshot = i.NameSnapshot,
                                UnitPriceSnapshot = i.UnitPriceSnapshot,
                                Quantity = i.Quantity,
                                LineTotal = i.LineTotal
                            }).ToList(),

                            Subtotal = x.Subtotal,
                            Notes = x.Notes

                        }).FirstOrDefaultAsync();

                if (order != null)
                {
                    return new BaseResponse<OrderResponse>(order, ResponseCodes.Success, ResponseMessages.Success);
                }
                return new BaseResponse<OrderResponse>(order, ResponseCodes.OrderNotFound, ResponseMessages.OrderIdNotFound);

            }
            catch (Exception ex)
            {
                // log the exception
                _logger.LogError(ex, "An error occurred while creating the menu");
                return new BaseResponse<OrderResponse>(null, ResponseCodes.Exception, ResponseMessages.Exception);
            }
        }

        public async Task<BaseResponse<List<OrderResponse>>> GetAllOrders()
        {
            try
            {
                var order = await _context.Orders
                        .Select(x => new OrderResponse()
                        {
                            Id = x.Id,
                            CustomerName = x.CustomerName,
                            CreatedAt = x.CreatedAt,
                            Status = x.Status,

                            Items = x.Items.Select(i => new OrderItemResponse
                            {
                                MenuItemId = i.MenuItemId,
                                NameSnapshot = i.NameSnapshot,
                                UnitPriceSnapshot = i.UnitPriceSnapshot,
                                Quantity = i.Quantity,
                                LineTotal = i.LineTotal
                            }).ToList(),

                            Subtotal = x.Subtotal,
                            Notes = x.Notes

                        }).ToListAsync();

                if (order != null)
                {
                    return new BaseResponse<List<OrderResponse>>(order, ResponseCodes.Success, ResponseMessages.Success);
                }
                return new BaseResponse<List<OrderResponse>>(order, ResponseCodes.OrderNotFound, ResponseMessages.OrderNotFound);

            }
            catch (Exception ex)
            {
                // log the exception
                _logger.LogError(ex, "An error occurred while creating the menu");
                return new BaseResponse<List<OrderResponse>>(null, ResponseCodes.Exception, ResponseMessages.Exception);
            }
        }

        public async Task<BaseResponse<bool>> UpdateOrderStatus(long id, UpdateOrderStatusRequest request)
        {
            try
            {
                var order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);
                if (order == null)
                {
                    return new BaseResponse<bool>(false, ResponseCodes.OrderNotFound, ResponseMessages.OrderIdNotFound);
                }

                order.Status = request.Status;

                await _context.SaveChangesAsync();

                return new BaseResponse<bool>(true, ResponseCodes.Success, ResponseMessages.OrderStatusUpdateSuccessful);
            }
            catch (Exception ex)
            {
                // log the exception
                _logger.LogError(ex, "An error occurred while updating the menu");
                return new BaseResponse<bool>(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
        }
    }
}
