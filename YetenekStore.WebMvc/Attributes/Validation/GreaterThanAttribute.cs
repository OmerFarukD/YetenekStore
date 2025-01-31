using System.ComponentModel.DataAnnotations;

namespace YetenekStore.WebMvc.Attributes.Validation;

public class GreaterThanAttribute : ValidationAttribute
{

    public double Min { get; set; } = 0;
    
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is double || value is int || value is decimal)
        {
            double deger = Convert.ToDouble(value);

            if (deger <=0)
            {
                return new ValidationResult("Girmiş olduğunuz değer 0 ve negatif değer alamaz.");
            }
            if (Min>deger)
            {
                return new ValidationResult($"Girmiş olduğunuz değer {Min} sayısından küçük olamaz");
            }
            
        }
        return ValidationResult.Success;
    }
}