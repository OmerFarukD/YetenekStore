using AutoMapper;
using Microsoft.AspNetCore.Http;
using YetenekStore.Models.Dtos.Products;
using YetenekStore.Models.Entities;
using YetenekStore.Repository.Repositories.Abstracts;
using YetenekStore.Service.Abstracts;
using YetenekStore.Service.Helpers.Cloudinary;

namespace YetenekStore.Service.Concretes;

public sealed class ProductService(IMapper mapper, IProductRepository productRepository,IFileService fileService) : IProductService
{
    public async Task<List<ProductResponseDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        List<Product> products = await productRepository.GetAllAsync(cancellationToken:cancellationToken);
        List<ProductResponseDto> responses = mapper.Map<List<ProductResponseDto>>(products);

        return responses;

    }

    public async Task<ProductResponseDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        Product? product = await productRepository.GetAsync(
            filter: x=> x.Id==id,
            cancellationToken:cancellationToken,
            enableTracking:false
            );
        ProductResponseDto productResponseDto = mapper.Map<ProductResponseDto>(product);
        return productResponseDto;
    }

    public async Task<List<ProductResponseDto>> GetAllByPriceRangeAsync(decimal min, decimal max, CancellationToken cancellationToken = default)
    {
        var products =await productRepository
            .GetAllAsync(filter: x=>x.Price<=max && x.Price>=min,
                enableTracking:false,
                cancellationToken:cancellationToken);

        var responses = mapper.Map<List<ProductResponseDto>>(products);
        return responses;
    }

    public async Task AddAsync(ProductAddRequestDto addRequestDto, CancellationToken cancellationToken = default)
    {
        Product product = mapper.Map<Product>(addRequestDto);
        string url = await fileService.UploadImageAsync(addRequestDto.File,"products-image");
        product.ImageUrl = url;
        await productRepository.AddAsync(product, cancellationToken);
    }

    public async Task UpdateAsync(ProductUpdateRequestDto productUpdateRequestDto, CancellationToken cancellationToken = default)
    {
        var product = await productRepository.GetAsync(x=>x.Id==productUpdateRequestDto.Id
            ,include:false,
            cancellationToken: cancellationToken
            );

        if (product is null)
        {
            //todo: Exception Fırlatılacak
        }
        Product updated = mapper.Map(productUpdateRequestDto,product!);
        await productRepository.UpdateAsync(updated, cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken )
    {
        var product = await productRepository.GetAsync(x=>x.Id==id
            ,include:false,
            cancellationToken: cancellationToken
        );

        if (product is null)
        {
            //todo: Exception Fırlatılacak
        }

        await productRepository.DeleteAsync(product!,cancellationToken);
    }

    public async Task<List<ProductResponseDto>> GetAllByCategoryId(int categoryId,CancellationToken cancellationToken)
    {
        var products = await productRepository.GetAllAsync(
            x=>x.CategoryId ==categoryId,
            enableTracking: false,
            cancellationToken: cancellationToken
            );

        var responses = mapper.Map<List<ProductResponseDto>>(products);

        return responses;
    }
}