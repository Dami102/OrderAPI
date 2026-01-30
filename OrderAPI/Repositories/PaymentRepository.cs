using Microsoft.EntityFrameworkCore;
using OrderAPI.Core.Interfaces.IRepositories;
using OrderAPI.Core.Services;
using OrderAPI.Data;
using OrderAPI.Models;

namespace OrderAPI.Repositories
{
    public class PaymentRepository(OrderDbContext context) : GenericRepository<Payments>(context), IPaymentRepository
    {
        public async Task<Payments?> GetPaymentByIdAsync(Guid id)
        {
            return await _db.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Payments?> GetPaymentsByOrderIdAsync(Guid orderId)
        {
            return await _db.AsNoTracking().FirstOrDefaultAsync(y => y.OrderId == orderId);
        }
    }
}
