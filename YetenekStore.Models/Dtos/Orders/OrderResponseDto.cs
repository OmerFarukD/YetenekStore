using YetenekStore.Models.Dtos.OrderItems;

namespace YetenekStore.Models.Dtos.Orders;

public sealed class OrderResponseDto
{
    public string  Username { get; set; }
    public decimal TotalPrice { get; set; }
    public List<OrderItemResponseDto> OrderItemResponseDtos { get; set; }
}