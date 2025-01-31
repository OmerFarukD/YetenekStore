using Microsoft.AspNetCore.Http;
using YetenekStore.Models.Dtos.Products;

namespace YetenekStore.Service.Abstracts;

public interface IProductService
{
    Task<List<ProductResponseDto>> GetAllAsync(CancellationToken cancellationToken=default);
    Task<ProductResponseDto> GetByIdAsync(Guid id, CancellationToken cancellationToken=default);
    Task<List<ProductResponseDto>> GetAllByPriceRangeAsync(decimal min, decimal max, CancellationToken cancellationToken=default);
    Task AddAsync(ProductAddRequestDto addRequestDto, CancellationToken cancellationToken=default);
    Task UpdateAsync(ProductUpdateRequestDto productUpdateRequestDto,CancellationToken cancellationToken=default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    Task<List<ProductResponseDto>> GetAllByCategoryId(int categoryId,CancellationToken cancellationToken);

}