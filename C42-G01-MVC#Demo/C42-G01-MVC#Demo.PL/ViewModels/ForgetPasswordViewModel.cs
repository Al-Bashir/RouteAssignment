using System.ComponentModel.DataAnnotations;

namespace C42_G01_MVC01_Demo.PL.ViewModels
{
	public class ForgetPasswordViewModel
	{
		[Required(ErrorMessage = "Email Is Required")]
		[EmailAddress(ErrorMessage = "Invalid Email Address.")]
		public string Email { get; set; }
	}
}
