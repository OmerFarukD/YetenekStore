using CorePackage.Repositories;
using YetenekStore.Models.Entities;
using YetenekStore.Repository.Contexts;
using YetenekStore.Repository.Repositories.Abstracts;

namespace YetenekStore.Repository.Repositories.Concretes;

public sealed class OrderRepository : EfRepositoryBase<Order,Guid,BaseDbContext>,IOrderRepository
{
    public OrderRepository(BaseDbContext context) : base(context)
    {
    }
}