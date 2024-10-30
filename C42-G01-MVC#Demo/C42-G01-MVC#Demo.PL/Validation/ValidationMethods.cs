using System.Text.RegularExpressions;

namespace C42_G01_MVC01_Demo.PL.Validation
{
	public static class ValidationMethods
	{
		public static bool IsValidEmail(string input)
		{
			// Regular expression for email validation
			var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
			return Regex.IsMatch(input, emailPattern);
		}

		public static bool IsValidPhoneNumber(string input)
		{
			// Regular expression for phone number validation (adjust pattern as needed)
			var phonePattern = @"^\+?[1-9]\d{1,14}$"; // Basic pattern for international numbers
			return Regex.IsMatch(input, phonePattern);
		}
	}
}
