using Microsoft.EntityFrameworkCore;
using OrderAPI.Core.Interfaces.IRepositories;
using OrderAPI.Data;
using OrderAPI.Models;

namespace OrderAPI.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(OrderDbContext context) : base(context) { }

        public async Task<Order?> GetOrderById(Guid id)
        {
            return await _db.Include(o => o.Items).FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<List<Order>> GetOrderWithItems()
        {
            return await _db.AsNoTracking()
                .Include(o => o.Items).ToListAsync();
        }
    }
}
