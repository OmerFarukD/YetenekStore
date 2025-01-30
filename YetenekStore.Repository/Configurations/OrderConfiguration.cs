using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YetenekStore.Models.Entities;

namespace YetenekStore.Repository.Configurations;

public sealed class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders").HasKey(x=> x.Id);
        builder.Property(x => x.CreatedDate).HasColumnName("Created").IsRequired();
        builder.Property(x => x.UpdatedDate).HasColumnName("Updated");

        builder.Navigation(x => x.Product).AutoInclude();
        builder.Navigation(x => x.User).AutoInclude();
    }
}