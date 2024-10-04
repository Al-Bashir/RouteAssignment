using C42_G01_MVC01_Demo.PL.Validation;
using System.ComponentModel.DataAnnotations;

namespace C42_G01_MVC01_Demo.PL.ViewModels
{
	public class RegisterViewModel
	{
		[Required(ErrorMessage = "First Name Is Required.")]
		[MaxLength(50, ErrorMessage = "First Name Must Be Less Than 50 Characters")]
		public string FName { get; set; }
		[Required(ErrorMessage = "Last Name Is Required.")]
		[MaxLength(50, ErrorMessage = "Last Name Must Be Less Than 50 Characters")]
		public string LName { get; set; }
		[Required(ErrorMessage = "Email Is Required")]
		[EmailAddress(ErrorMessage = "Invalid Email Address.")]
		public string Email { get; set; }
		[Required(ErrorMessage = "Password Is Required")]
		[DataType(DataType.Password)]
		public string Password { get; set; }
		[Required(ErrorMessage = "Confirm Password Is Required")]
		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "Confirm Password Doesn't Match With Password")]
		public string ConfirmPassword { get; set; }
		[MustBeTrueCustomValidation(ErrorMessage = "You must agree with the terms.")]
		public bool IsAgreed { get; set; }		
    }
}
