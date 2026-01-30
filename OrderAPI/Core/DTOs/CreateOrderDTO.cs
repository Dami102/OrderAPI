using OrderAPI.Models;

namespace OrderAPI.Core.DTOs
{
    public class CreateOrderDTO
    {
        public List<ItemDTO> Items { get; set; } = [];
    }

    public class ItemDTO
    {
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
