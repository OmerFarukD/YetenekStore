using YetenekStore.Models.Entities;

namespace YetenekStore.Models.Dtos.Orders;

public sealed class OrderAddRequestDto
{
    public string UserId { get; set; }
    public decimal TotalPrice { get; set; }
}