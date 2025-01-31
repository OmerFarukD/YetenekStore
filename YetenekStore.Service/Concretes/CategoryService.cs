using AutoMapper;
using YetenekStore.Models.Dtos.Categories;
using YetenekStore.Models.Entities;
using YetenekStore.Repository.Repositories.Abstracts;
using YetenekStore.Service.Abstracts;

namespace YetenekStore.Service.Concretes;

public sealed class CategoryService(IMapper mapper, ICategoryRepository categoryRepository) : ICategoryService
{
    public async Task<CategoryResponseDto> GetByIdAsync(int id)
    {
        var category = await categoryRepository.GetAsync(x=>x.Id==id, enableTracking:false, include:false);
        var response = mapper.Map<CategoryResponseDto>(category);
        return response;
    }

    public async Task<List<CategoryResponseDto>> GetAllAsync()
    {
        var categories = await categoryRepository.GetAllAsync(enableTracking:false, include:false);
        var responses = mapper.Map<List<CategoryResponseDto>>(categories);
        return responses;
    }

    public async Task AddAsync(CategoryAddRequestDto categoryAddRequestDto)
    {
        Category category = mapper.Map<Category>(categoryAddRequestDto);
        await categoryRepository.AddAsync(category);
    }

    public async Task UpdateAsync(CategoryUpdateRequestDto categoryUpdateRequestDto)
    {
        Category category = mapper.Map<Category>(categoryUpdateRequestDto);
        await categoryRepository.UpdateAsync(category);
    }

    public async Task DeleteAsync(int id)
    {
        var category = await categoryRepository.GetAsync(x=>x.Id==id,
            
            include:false
            );

        if (category is null)
        {
            //todo : Exception Fırlat
        }

        await categoryRepository.DeleteAsync(category!);
    }
}