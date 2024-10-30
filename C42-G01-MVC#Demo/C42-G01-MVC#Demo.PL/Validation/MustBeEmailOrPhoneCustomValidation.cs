using System.ComponentModel.DataAnnotations;

namespace C42_G01_MVC01_Demo.PL.Validation
{
	public class MustBeEmailOrPhoneCustomValidation : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			if (ValidationMethods.IsValidEmail(value as string) || ValidationMethods.IsValidPhoneNumber(value as string))
			{
				return ValidationResult.Success;
			}
			return new ValidationResult(ErrorMessage ?? "The Value You Enter Not Either Email Or Phone Number.");
		}
	}
}
