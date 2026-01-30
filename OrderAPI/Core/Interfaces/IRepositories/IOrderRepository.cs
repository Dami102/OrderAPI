using OrderAPI.Models;

namespace OrderAPI.Core.Interfaces.IRepositories
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<Order?> GetOrderById(Guid id);
        Task<List<Order>> GetOrderWithItems();
    }
}
