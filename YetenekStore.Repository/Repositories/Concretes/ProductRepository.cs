using CorePackage.Repositories;
using YetenekStore.Models.Entities;
using YetenekStore.Repository.Contexts;
using YetenekStore.Repository.Repositories.Abstracts;

namespace YetenekStore.Repository.Repositories.Concretes;

public sealed class ProductRepository : EfRepositoryBase<Product, Guid, BaseDbContext>, IProductRepository
{
    public ProductRepository(BaseDbContext context) : base(context)
    {
    }
}