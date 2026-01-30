using OrderAPI.Core.DTOs;
using OrderAPI.Core.Interfaces.IRepositories;
using OrderAPI.Core.Interfaces.IServices;
using OrderAPI.Models;

namespace OrderAPI.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<APIResponse<Order>> CreateOrder(CreateOrderDTO orderDTO)
        {
            var newOrder = new Order
            {
                CreateAt = DateTime.Now,
                IsCompleted = false,
                Items = orderDTO.Items.Select(i => new Item
                {
                    Name = i.Name,
                    Price = i.Price,
                    Quantity = i.Quantity
                }).ToList(),
            };

            await _orderRepository.AddAsync(newOrder);

            return APIResponse<Order>.Success("success", newOrder, 201);
        }

        public async Task<APIResponse<Order>> GetOrderById(Guid id)
        {
            var order = await _orderRepository.GetOrderById(id);

            if (order == null) return APIResponse<Order>.Fail("Order does not exist", 400);

            return APIResponse<Order>.Success("Success", order);
        }

        public async Task<APIResponse<List<Order>>> GetAllOrders()
        {
            var orders = await _orderRepository.GetOrderWithItems();

            return APIResponse<List<Order>>.Success("Success", orders);
        }

        public async Task<APIResponse<Order>> UpdateOrder(Guid id, UpdateOrderDto model)
        {
            var order = await _orderRepository.GetOrderById(id);

            if (order is null) return APIResponse<Order>.Fail("Order does not exist");

            if (order.IsCompleted == true) return APIResponse<Order>.Fail("ROder cannot be updated");

            var updatedModel = new Order
            {
                UpdateAt = DateTime.UtcNow,
                Items = model.Items.Select(i => new Item
                {
                    Name = i.Name,
                    Price = i.Price,
                    OrderId = order.Id,
                    Quantity = i.Quantity,  
                }).ToList(),
            };

            return APIResponse<Order>.Success("Updated Successfully", updatedModel);
        }

        public async Task<APIResponse<Order>> DeleteOrder(Guid id)
        {
            var order = await _orderRepository.GetOrderById(id);

            if (order is null) return APIResponse<Order>.Fail("Order does not exist");

            await _orderRepository.Delete(order);

            return APIResponse<Order>.Success("Successfully deleted", null!);

        }

        public async Task<APIResponse<List<Item>>> ListOrderItems(Guid Id)
        {
            var order = await _orderRepository.GetOrderById(Id);

            if (order is null) return APIResponse<List<Item>>.Fail("Order does not exist");

            var items = order.Items;

            return APIResponse<List<Item>>.Success("Success", items);
        }
    }
}
