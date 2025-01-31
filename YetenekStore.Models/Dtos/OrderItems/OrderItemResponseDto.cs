namespace YetenekStore.Models.Dtos.OrderItems;

public sealed class OrderItemResponseDto
{
    public Guid OrderId { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
}