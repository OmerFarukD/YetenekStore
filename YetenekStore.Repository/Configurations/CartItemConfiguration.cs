using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YetenekStore.Models.Entities;

namespace YetenekStore.Repository.Configurations;

public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        builder.Navigation(x => x.Product).AutoInclude();
        builder.Navigation(x => x.Cart).AutoInclude();
    }
}