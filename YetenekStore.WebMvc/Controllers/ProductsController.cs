using Microsoft.AspNetCore.Mvc;
using YetenekStore.Service.Abstracts;

namespace YetenekStore.WebMvc.Controllers;

public class ProductsController(IProductService productService) : Controller
{
    // GET
    public async Task<IActionResult> Index()
    {
        var products = await productService.GetAllAsync();
        return View(products);
    }
    
    
}