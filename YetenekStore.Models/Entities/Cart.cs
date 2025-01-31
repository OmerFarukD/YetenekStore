using CorePackage.Entities;

namespace YetenekStore.Models.Entities;

public sealed class Cart : Entity<Guid>
{
    public string UserId { get; set; }
    public User User { get; set; }

    public List<CartItem> CartItems { get; set; }
}