using CorePackage.Repositories;
using YetenekStore.Models.Entities;
using YetenekStore.Repository.Contexts;
using YetenekStore.Repository.Repositories.Abstracts;

namespace YetenekStore.Repository.Repositories.Concretes;

public sealed class CategoryRepository : EfRepositoryBase<Category, int, BaseDbContext>, ICategoryRepository
{
    public CategoryRepository(BaseDbContext context) : base(context)
    {
    }
}