using C42_G01_MVC01_Demo.PL.Validation;
using System.ComponentModel.DataAnnotations;

namespace C42_G01_MVC01_Demo.PL.ViewModels
{
	public class ForgetPasswordViewModel
	{
		[Required(ErrorMessage = "Field Is Required")]
		[MustBeEmailOrPhoneCustomValidation(ErrorMessage = "The Value You Enter Not Either Email Or Phone Number.")]
		public string EmailOrPhone { get; set; }
	}
}
