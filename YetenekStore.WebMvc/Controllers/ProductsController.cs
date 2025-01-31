using Microsoft.AspNetCore.Mvc;
using YetenekStore.Models.Dtos.Products;
using YetenekStore.Service.Abstracts;
using YetenekStore.WebMvc.Models.ViewModels;

namespace YetenekStore.WebMvc.Controllers;

public class ProductsController(IProductService productService) : Controller
{
    // GET
    public async Task<IActionResult> Index()
    {
        var products = await productService.GetAllAsync();
        return View(products);
    }


    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Add(ProductAddModelView vm)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        ProductAddRequestDto productAddRequestDto = new()
        {
            Name = vm.Name,
            Description = vm.Description,
            CategoryId = vm.CategoryId,
            Price = vm.Price,
            File = vm.File,
            Stock = vm.Stock
        };

        await productService.AddAsync(productAddRequestDto);
        
        return RedirectToAction("Index","Products");
    }
}