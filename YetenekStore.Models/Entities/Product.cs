using CorePackage.Entities;

namespace YetenekStore.Models.Entities;

public sealed class Product : Entity<Guid>
{
    public string Name { get; set; }
    public decimal  Price { get; set; }
    public int Stock { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }
    
}