using C42_G01_MVC_Demo.DAL.Models;
using C42_G01_MVC01_Demo.PL.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace C42_G01_MVC01_Demo.PL.Controllers
{
	public class AuthController : Controller
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;

		public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}
		public IActionResult Register()
		{
			ViewData["ViewName"] = "Register";
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
		{
			ViewData["ViewName"] = "Register";
			if (registerViewModel == null)
			{
				return BadRequest();
			}
			if (ModelState.IsValid)
			{
				var User = new ApplicationUser()
				{
					UserName = registerViewModel.Email.Split('@')[0],
					Email = registerViewModel.Email,
					FName = registerViewModel.FName,
					LName = registerViewModel.LName,
					IsAgreed = registerViewModel.IsAgreed,
				};
				var Result = await _userManager.CreateAsync(User, registerViewModel.Password);
				if (Result.Succeeded)
				{
					return RedirectToAction(nameof(Login));
				}
				else
				{
					foreach (var error in Result.Errors)
					{
						ModelState.AddModelError(string.Empty, error.Description);
					}
				}
			}
			return View(registerViewModel);
		}
		public IActionResult Login()
		{
			ViewData["ViewName"] = "Login";
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(LoginViewModel loginViewModel)
		{
			ViewData["ViewName"] = "Login";
			if (loginViewModel is null)
			{
				return BadRequest();
			}
			if (ModelState.IsValid) 
			{
				var User = await _userManager.FindByEmailAsync(loginViewModel.Email);
				if (User is not null)
				{
					var Result = await _userManager.CheckPasswordAsync(User, loginViewModel.Password);
					if (Result == true)
					{
						var LogInResult = await _signInManager.PasswordSignInAsync(User, loginViewModel.Password, loginViewModel.RememberMe, false);
						if (LogInResult.Succeeded)
						{
							return RedirectToAction("Index", "Home");
						}
						else 
						{
							ModelState.AddModelError(string.Empty, "Login Failed Please Contact Administration.");
						}
					}
					else 
					{
						ModelState.AddModelError(string.Empty, "Password You Entered Is Not Valid.");
					}
				}
				else 
				{
					ModelState.AddModelError(string.Empty, "The Credential You Entered Is Not Valid.");
				}
			}
			return View(loginViewModel);
		}
	}
}
