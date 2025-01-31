using System.ComponentModel.DataAnnotations;
using YetenekStore.WebMvc.Attributes.Validation;

namespace YetenekStore.WebMvc.Models.ViewModels;

public class ProductAddModelView
{
    
    [Required(ErrorMessage = "İsim Alanı Zorunludur.")]
    [MinLength(3,ErrorMessage = "İsim Alanı Minimum 3 haneli olmalıdır.")]
    public string Name { get; set; }
    
    [GreaterThan]
    public decimal  Price { get; set; }
    [GreaterThan]
    public int Stock { get; set; }
    
    public string? Description { get; set; }
    public int CategoryId { get; set; }
    public IFormFile? File { get; set; }
}