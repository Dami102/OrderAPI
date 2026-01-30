using OrderAPI.Core.DTOs;
using OrderAPI.Models;

namespace OrderAPI.Core.Interfaces.IServices
{
    public interface IOrderService
    {
        Task<APIResponse<Order>> CreateOrder(CreateOrderDTO orderDTO);
        Task<APIResponse<Order>> DeleteOrder(Guid id);
        Task<APIResponse<List<Order>>> GetAllOrders();
        Task<APIResponse<Order>> GetOrderById(Guid id);
        Task<APIResponse<List<Item>>> ListOrderItems(Guid Id);
        Task<APIResponse<Order>> UpdateOrder(Guid id, UpdateOrderDto model);
    }
}