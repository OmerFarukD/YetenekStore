using YetenekStore.Models.Dtos.Orders;

namespace YetenekStore.Service.Abstracts;

public interface IOrderService
{
    Task<List<OrderResponseDto>> GetAllAsync();
    Task<OrderResponseDto> GetByIdAsync(Guid id);
    Task AddAsync(OrderAddRequestDto orderAddRequestDto);
    Task UpdateAsync(OrderUpdateRequestDto orderUpdateRequestDto);
    Task DeleteAsync(Guid id);
    Task<List<OrderResponseDto>> GetAllByUserId(string userId);
}