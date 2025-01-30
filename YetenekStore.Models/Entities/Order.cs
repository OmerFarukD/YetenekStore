using CorePackage.Entities;

namespace YetenekStore.Models.Entities;

public sealed class Order : Entity<Guid>
{
    public string UserId { get; set; }
    public User User { get; set; }
    
    
    public Guid ProductId { get; set; }
    public Product Product { get; set; }
}