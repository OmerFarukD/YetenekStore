namespace YetenekStore.Models.Dtos.Orders;

public sealed class OrderUpdateRequestDto
{
    public string UserId { get; set; }

    public decimal TotalPrice { get; set; }
}