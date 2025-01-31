using AutoMapper;
using YetenekStore.Models.Dtos.Orders;
using YetenekStore.Models.Entities;
using YetenekStore.Repository.Repositories.Abstracts;
using YetenekStore.Service.Abstracts;
namespace YetenekStore.Service.Concretes;

public sealed class OrderService(IOrderRepository orderRepository, IMapper mapper) : IOrderService
{
    public async Task<List<OrderResponseDto>> GetAllAsync()
    {
        var orders = await orderRepository.GetAllAsync(enableTracking: false);
        var response = mapper.Map<List<OrderResponseDto>>(orders);
        return response;
    }

    public async Task<OrderResponseDto> GetByIdAsync(Guid id)
    {
        var order = await orderRepository.GetAsync(x=>x.Id==id,enableTracking:false);
        var response = mapper.Map<OrderResponseDto>(order);
        return response;
    }

    public async Task AddAsync(OrderAddRequestDto orderAddRequestDto)
    {
        await orderRepository.AddAsync(mapper.Map<Order>(orderAddRequestDto));
    }

    public async Task UpdateAsync(OrderUpdateRequestDto orderUpdateRequestDto)
    {
        await orderRepository.UpdateAsync(mapper.Map<Order>(orderUpdateRequestDto));
    }

    public async Task DeleteAsync(Guid id)
    {
        var order = await orderRepository.GetAsync(x=>x.Id==id,enableTracking:false);
        if (order is null)
        { }

        await orderRepository.DeleteAsync(order!);
    }

    public async Task<List<OrderResponseDto>> GetAllByUserId(string userId)
    {
        var orders = await orderRepository.GetAllAsync(x=>x.UserId==userId,enableTracking:false);

        var response = mapper.Map<List<OrderResponseDto>>(orders);
        return response;
    }
}