using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YetenekStore.Models.Entities;

namespace YetenekStore.Repository.Configurations;

public class CartConfiguration : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {

        builder.Navigation(x => x.User).AutoInclude();
    }
}