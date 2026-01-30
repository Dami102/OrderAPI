using Microsoft.AspNetCore.Mvc;
using OrderAPI.Core.DTOs;
using OrderAPI.Core.Interfaces.IServices;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace OrderAPI.Endpoints
{
    public static  class PaymentEndpoints
    {
        public static void MapPaymentEndpoints(this WebApplication app)
        {
            var paymentEndpoints = app.MapGroup("/payment");

            paymentEndpoints.MapPost("/", CreatePayment);
            paymentEndpoints.MapGet("/", GetAllPayments);
            paymentEndpoints.MapGet("/items/{id}", GetOrderPayment);
        }

        private static async Task<IResult> CreatePayment(CreatePaymentDTO dto, IPaymentService paymentService)
        {
            
            var response = await paymentService.CreatePayment(dto.OrderId, dto);

            return Results.Created($"/payment/{response?.Data?.Id}", response);
        }

        private static IResult GetAllPayments(IPaymentService paymentService)
        {
            var response = paymentService.GetAllPayments();

            return Results.Ok(response);
        }

        private static async Task<IResult> GetOrderPayment(Guid id, IPaymentService paymentService)
        {
            var response = await paymentService.GetPaymemtForOrder(id);

            return Results.Ok(response);
        }
    }
}
