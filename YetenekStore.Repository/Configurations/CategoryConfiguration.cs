using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YetenekStore.Models.Entities;

namespace YetenekStore.Repository.Configurations;

public sealed class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories").HasKey(x=> x.Id);
        builder.Property(x => x.CreatedDate).HasColumnName("Created").IsRequired();
        builder.Property(x => x.UpdatedDate).HasColumnName("Updated");
        builder.Property(x => x.Name).HasColumnName("Category_name");


        
        // İlişki ayarlanması
        builder.HasMany(x => x.Products)
            .WithOne(x => x.Category)
            .HasForeignKey(x => x.CategoryId);
        
        
        // Tablo oluşturulurken içine data gönder.
        builder.HasData(new Category
        {
            Id = 1,
            Name = "Bilgisayar",
            CreatedDate = DateTime.UtcNow
        }, 
            
        new Category
        {
            Id = 2,
            Name = "Telefon",
            CreatedDate = DateTime.UtcNow
        }
        );


        builder.Navigation(x => x.Products).AutoInclude();

    }
}