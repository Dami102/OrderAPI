using OrderAPI.Core.Interfaces.IRepositories;
using OrderAPI.Models;

namespace OrderAPI.Repositories
{
    public interface IPaymentRepository : IGenericRepository<Payments>
    {
        Task<Payments?> GetPaymentByIdAsync(Guid id);
        Task<Payments?> GetPaymentsByOrderIdAsync(Guid orderId);
    }
}