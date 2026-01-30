using OrderAPI.Core.DTOs;
using OrderAPI.Core.Interfaces.IRepositories;
using OrderAPI.Core.Interfaces.IServices;
using OrderAPI.Models;
using OrderAPI.Repositories;

namespace OrderAPI.Core.Services
{
    public class PaymentService : IPaymentService
    {

        private readonly IPaymentRepository _paymentRepository;
        private readonly IOrderRepository _orderRepository;

        public PaymentService(IPaymentRepository paymentRepository, IOrderRepository orderRepository)
        {
            _paymentRepository = paymentRepository;
            _orderRepository = orderRepository;
        }

        public async Task<APIResponse<Payments>> CreatePayment(Guid orderId, CreatePaymentDTO model)
        {
            var order = await _orderRepository.GetOrderById(orderId);

            if (order == null) return APIResponse<Payments>.Fail("Fail");

            if (order.IsCompleted) return APIResponse<Payments>.Fail("Fail");


            var payment = new Payments
            {
                OrderId = orderId,
                Amount = order.GetTotalAmount(),
                PaidAt = DateTime.UtcNow,
            };

            order.IsCompleted = true;
            await _paymentRepository.AddAsync(payment);

            return APIResponse<Payments>.Success("success", payment);

        }

        public async Task<APIResponse<Payments>> GetPaymemtForOrder(Guid orderId)
        {
            var payment = await _paymentRepository.GetPaymentsByOrderIdAsync(orderId);

            return APIResponse<Payments>.Success("Sucess", payment);
        }

        public APIResponse<List<Payments>> GetAllPayments()
        {
            var payments = _paymentRepository.GetAll();

            return APIResponse<List<Payments>>.Success("Success", payments);
        }
    }
}
