using System.ComponentModel.DataAnnotations;

namespace ModelBindSample.Shared;

public class SaudiRiyalAmountAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        //return base.IsValid(value, validationContext);
        return ValidationResult.Success;
    }
}