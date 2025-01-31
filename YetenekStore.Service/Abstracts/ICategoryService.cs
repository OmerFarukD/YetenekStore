using YetenekStore.Models.Dtos.Categories;

namespace YetenekStore.Service.Abstracts;

public interface ICategoryService
{
    Task<CategoryResponseDto> GetByIdAsync(int id);
    Task<List<CategoryResponseDto>> GetAllAsync();
    Task AddAsync(CategoryAddRequestDto categoryAddRequestDto);
    Task UpdateAsync(CategoryUpdateRequestDto categoryUpdateRequestDto);
    Task DeleteAsync(int id);
}