using Microsoft.EntityFrameworkCore;
using OrderAPI.Models;
namespace OrderAPI.Data
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options) { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Payments> Payments { get; set; }
    }
}
