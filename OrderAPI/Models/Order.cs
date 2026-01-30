using System.ComponentModel.DataAnnotations;

namespace OrderAPI.Models
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public List<Item> Items { get; set; } = [];
        public bool IsCompleted { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdateAt { get; set; }

        public decimal GetTotalAmount()
        {
            return Items.Sum(i => i.Quantity * i.Price);
        }

    }
}
