namespace OrderAPI.Core.DTOs
{
    public record UpdateOrderDto(
    List<UpdateOrderItemDto> Items
);

    public record UpdateOrderItemDto(
    string Name,
    int Quantity,
    decimal Price
);



}
