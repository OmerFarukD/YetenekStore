using CorePackage.Entities;

namespace YetenekStore.Models.Entities;

public sealed class CartItem : Entity<Guid>
{
    public Guid CartId { get; set; }
    public Cart Cart { get; set; }

    public Guid ProductId { get; set; }
    public Product Product { get; set; }
    public int Quantity { get; set; }
}