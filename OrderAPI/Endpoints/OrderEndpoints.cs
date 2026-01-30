using Microsoft.AspNetCore.Mvc;
using OrderAPI.Core.DTOs;
using OrderAPI.Core.Interfaces.IServices;

namespace OrderAPI.Endpoints
{
    public static class OrderEndpoints
    {
        public static void MapOrderEndpoints(this WebApplication app)
        {
            var orders = app.MapGroup("/orders");

            orders.MapPost("/", CreateOrder);
            orders.MapGet("/", GetAllOrders);
            orders.MapGet("/{id}", GetOrderById);
            orders.MapPut("/", CreateOrder);
            orders.MapDelete("/{id}", DeleteOrder);
            orders.MapGet("/items/{id}", ListItemsOrder);
        }

        private static async Task<IResult> CreateOrder([FromBody] CreateOrderDTO dto, IOrderService orderService)
        {
            var response = await orderService.CreateOrder(dto);

            return Results.Created($"orders/{response?.Data?.Id}", response);

        }

        private static async  Task<IResult> GetAllOrders(IOrderService orderService)
        {
            var response = await orderService.GetAllOrders();

            return Results.Ok(response);
        }

        private static async Task<IResult> GetOrderById(Guid id, IOrderService orderService)
        {
            var response = await orderService.GetOrderById(id);

            return Results.Ok(response);
        }

        private static async Task<IResult> UpdateOrder(Guid id,[FromBody] UpdateOrderDto model,   IOrderService orderService)
        {
            var response = await orderService.UpdateOrder(id, model);

            return Results.Ok(response);
        }

        private static async Task<IResult> DeleteOrder(Guid id, IOrderService orderService)
        {
            var response = await orderService.DeleteOrder(id);

            return Results.Ok(response);
        }

        private static async Task<IResult> ListItemsOrder(Guid id , IOrderService orderService)
        {
            var response = await orderService.ListOrderItems(id);

            return Results.Ok(response);
        }

    }
}
