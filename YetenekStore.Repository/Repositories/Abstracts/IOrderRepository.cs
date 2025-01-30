using CorePackage.Repositories;
using YetenekStore.Models.Entities;

namespace YetenekStore.Repository.Repositories.Abstracts;

public interface IOrderRepository : IRepository<Order, Guid>
{
    
}