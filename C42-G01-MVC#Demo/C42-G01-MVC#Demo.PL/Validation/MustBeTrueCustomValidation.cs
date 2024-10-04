using System.ComponentModel.DataAnnotations;

namespace C42_G01_MVC01_Demo.PL.Validation
{
	public class MustBeTrueCustomValidation : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			if (value is bool boolValue && boolValue)
			{
				return ValidationResult.Success;
			}
			return new ValidationResult(ErrorMessage ?? "You must agree with the terms.");
		}
	}
}
