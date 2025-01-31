using CorePackage.Entities;

namespace YetenekStore.Models.Entities;

public sealed class Order : Entity<Guid>
{
    public string UserId { get; set; }
    public User User { get; set; }

    public decimal TotalPrice { get; set; }

    public List<OrderItem> OrderItems { get; set; }
}
