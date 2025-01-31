using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YetenekStore.Models.Entities;

namespace YetenekStore.Repository.Configurations;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {


        builder.Navigation(x => x.Product).AutoInclude();
        builder.Navigation(x => x.Order).AutoInclude();
    }
}