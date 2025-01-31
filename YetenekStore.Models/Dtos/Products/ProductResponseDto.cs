namespace YetenekStore.Models.Dtos.Products;

public sealed class ProductResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal  Price { get; set; }
    public int Stock { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public string CategoryName { get; set; }
}