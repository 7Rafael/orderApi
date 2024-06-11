using System.ComponentModel.DataAnnotations;

namespace orderApi.Validations
{
    public class UserVallidationsAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }
            var primeiraLetra = value.ToString()[0].ToString();
            if (primeiraLetra != primeiraLetra.ToUpper())
            {
                return new ValidationResult("A primeira letra dever ser maiuscula");
            }
            return ValidationResult.Success;
        }
    }
}
