// Ignore Spelling: Inbox

using C42_G01_MVC_Demo.DAL.Models;
using C42_G01_MVC01_Demo.PL.Helpers;
using C42_G01_MVC01_Demo.PL.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
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
		public new async Task<IActionResult> SignOut()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction(nameof(Login));
		}
		public IActionResult ForgetPassword() 
		{
			return View();
		}
		public async Task<IActionResult> SendEmail(ForgetPasswordViewModel model) 
		{
			if (model is null) 
			{
				return BadRequest();
			}
			if (ModelState.IsValid)
			{
				var User = await _userManager.FindByEmailAsync(model.Email);
				if (User != null)
				{
					var token = await _userManager.GeneratePasswordResetTokenAsync(User);
					var ResetPasswordLink = Url.Action("ResetPassword", "Auth", new { email = model.Email, token = token }, Request.Scheme);
					var ForgetPasswordEmail = new Email()
					{
						Id = Guid.NewGuid().ToString(),
						To = model.Email,
						Subject = "Reset Password",
						Body = "Click The Below Link To Reset The Password:\n" + ResetPasswordLink
					};
					try
					{
						EmailSettings.SendEmail(ForgetPasswordEmail);
					}
					catch (Exception ex)
					{
						ModelState.AddModelError(string.Empty, ex.Message);
					}
					return RedirectToAction(nameof(CheckYourInbox));
				}
				else 
				{
					ModelState.AddModelError(string.Empty, "The Email You Entered Is Not Valid, Please Enter A Valid Email");
				}
			}
			return View(nameof(ForgetPassword), model);
		}
		public IActionResult CheckYourInbox()
		{
			return View();
		}
		public IActionResult ResetPassword(string email, string token) 
		{
			TempData["email"] = email;
			TempData["token"] = token;
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> ResetPassword(RestPasswordViewModel model) 
		{
			if (model is null) 
			{
				return BadRequest();
			}
			if (ModelState.IsValid) 
			{
				string email = TempData["email"] as string;
				string token = TempData["token"] as string;	
				var User = await _userManager.FindByEmailAsync(email);
				if (User != null) 
				{
					try
					{
						var result = await _userManager.ResetPasswordAsync(User, token, model.NewPassword);
						if (result.Succeeded)
						{
							return RedirectToAction(nameof(Login));
						}
						else 
						{
							foreach (var error in result.Errors)
							{
								ModelState.AddModelError(string.Empty, error.Description);
							}
						}
					}
					catch (Exception ex)
					{
						ModelState.AddModelError(string.Empty, ex.Message);
					}
				}
				else 
				{
					ModelState.AddModelError(string.Empty, "User Not Valid, Please Call Support");
				}
			}
			return View(model);
		}
	}
}
