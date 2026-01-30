using OrderAPI.Core.DTOs;
using OrderAPI.Models;

namespace OrderAPI.Core.Interfaces.IServices
{
    public interface IPaymentService
    {
        Task<APIResponse<Payments>> CreatePayment(Guid orderId, CreatePaymentDTO model);
        APIResponse<List<Payments>> GetAllPayments();
        Task<APIResponse<Payments>> GetPaymemtForOrder(Guid orderId);
    }
}