namespace backend.Common;
using System.ComponentModel.DataAnnotations;

public class ProductImageLengthAttribute : ValidationAttribute
{
    private readonly int _minLength;
    private readonly int _maxLength;

    public ProductImageLengthAttribute(int minLength, int maxLength)
    {
        _minLength = minLength;
        _maxLength = maxLength;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null) return new ValidationResult("The Image Field should not be null.");

        if (value is not string[] array || array.Length < _minLength || array.Length > _maxLength)
        {
            return new ValidationResult($"The field {validationContext.DisplayName} must contain between {_minLength} and {_maxLength} items.");
        }

        return ValidationResult.Success;
    }
}
