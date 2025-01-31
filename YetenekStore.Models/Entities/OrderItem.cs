using CorePackage.Entities;

namespace YetenekStore.Models.Entities;

public class OrderItem : Entity<Guid>
{
    public Guid OrderId { get; set; }
    public Order Order { get; set; }


    public Guid ProductId { get; set; }
    public Product Product { get; set; }

    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
}