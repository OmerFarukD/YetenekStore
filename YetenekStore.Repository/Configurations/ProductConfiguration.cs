using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YetenekStore.Models.Entities;

namespace YetenekStore.Repository.Configurations;

public sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products").HasKey(x=> x.Id);
        builder.Property(x => x.CreatedDate).HasColumnName("Created").IsRequired();
        builder.Property(x => x.UpdatedDate).HasColumnName("Updated");
        builder.Property(x => x.Name).HasColumnName("Product_name");
        builder.Navigation(x => x.Category).AutoInclude();


        builder.HasData(new Product
        {
            Id = Guid.NewGuid(),
            CategoryId = 1,
            Name = "Msi Bravo 15",
            Description = "İş görür",
            Stock = 250,
            Price = 25000,
            CreatedDate = DateTime.UtcNow
        });

    }
}