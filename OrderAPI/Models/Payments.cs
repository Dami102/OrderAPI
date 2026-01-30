using System.ComponentModel.DataAnnotations;

namespace OrderAPI.Models
{
    public class Payments
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid OrderId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaidAt { get; set; } = DateTime.UtcNow;
    }
}
