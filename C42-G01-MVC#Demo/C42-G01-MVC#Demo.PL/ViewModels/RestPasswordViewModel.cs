using System.ComponentModel.DataAnnotations;

namespace C42_G01_MVC01_Demo.PL.ViewModels
{
	public class RestPasswordViewModel
	{
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "New Password Is Required.")]
        public string NewPassword { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Confirm Password Is Required.")]
        [Compare("NewPassword", ErrorMessage = "Password Is Not Match.")]
        public string ConfirmPassword { get; set; }
    }
}
