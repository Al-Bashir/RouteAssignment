// Ignore Spelling: Inbox

using C42_G01_MVC_Demo.DAL.Models;
using C42_G01_MVC01_Demo.PL.Helpers;
using C42_G01_MVC01_Demo.PL.Validation;
using C42_G01_MVC01_Demo.PL.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace C42_G01_MVC01_Demo.PL.Controllers
{
	public class AuthController : Controller
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IMailSetting _mailSetting;
		private readonly ITwilioSMSSetting _twilioSMSSetting;

		public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IMailSetting mailSetting, ITwilioSMSSetting twilioSMSSetting)
		{
			_userManager = userManager;
			_signInManager = signInManager;
            _mailSetting = mailSetting;
			_twilioSMSSetting = twilioSMSSetting;
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
				if (registerViewModel.PhoneNumber is not null)
				{
					var IsPhoneNumberRegisterBefore = await _userManager.Users.AnyAsync(U => U.PhoneNumber == registerViewModel.PhoneNumber);
					if (IsPhoneNumberRegisterBefore == true)
					{
						ModelState.AddModelError(string.Empty, "Phone Number Has Been Used Before, Please Try With New Phone Number.");
					}
				}
				var User = new ApplicationUser()
				{
					UserName = registerViewModel.Email.Split('@')[0],
					Email = registerViewModel.Email,
					FName = registerViewModel.FName,
					LName = registerViewModel.LName,
					PhoneNumber = registerViewModel.PhoneNumber,
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
				if (ValidationMethods.IsValidEmail(model.EmailOrPhone))
				{
					var User = await _userManager.FindByEmailAsync(model.EmailOrPhone);
					if (User != null)
					{
						var token = await _userManager.GeneratePasswordResetTokenAsync(User);
						var ResetPasswordLink = Url.Action("ResetPassword", "Auth", new { email = model.EmailOrPhone, token = token }, Request.Scheme);
						var ForgetPasswordEmail = new Email()
						{
							Id = Guid.NewGuid().ToString(),
							To = model.EmailOrPhone,
							Subject = "Reset Password",
							Body = "Click The Below Link To Reset The Password:\n" + ResetPasswordLink
						};
						try
						{
							_mailSetting.SendEmail(ForgetPasswordEmail);
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
				if (ValidationMethods.IsValidPhoneNumber(model.EmailOrPhone)) 
				{
					var User = await _userManager.Users.FirstOrDefaultAsync(U => U.PhoneNumber == model.EmailOrPhone);
					if (User != null)
					{
						var token = await _userManager.GeneratePasswordResetTokenAsync(User);
						var ResetPasswordLink = Url.Action("ResetPassword", "Auth", new { email = model.EmailOrPhone, token = token }, Request.Scheme);
						var ForgetPasswordSMS = new SMS()
						{
							PhoneNumber = model.EmailOrPhone,
							SMSBody = "Click The Below Link To Reset The Password:\n" + ResetPasswordLink
						};
						try
						{
							_twilioSMSSetting.SendSMS(ForgetPasswordSMS);
						}
						catch (Exception ex)
						{
							ModelState.AddModelError(string.Empty, ex.Message);
						}
						return RedirectToAction(nameof(CheckYourInbox));
					}
					else 
					{
						ModelState.AddModelError(string.Empty, "The Phone Number You Entered Is Not Valid, Please Enter A Valid Phone Number");

					}
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
			var model = new RestPasswordViewModel() 
			{
				EmailOrPhone = email,
				Token = token
			};
			return View(model);
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
				ApplicationUser User = null;
				if (ValidationMethods.IsValidEmail(model.EmailOrPhone))
				{
					User = await _userManager.FindByEmailAsync(model.EmailOrPhone);
				}
				else if(ValidationMethods.IsValidPhoneNumber(model.EmailOrPhone))
				{
					User = await _userManager.Users.FirstOrDefaultAsync(U => U.PhoneNumber == model.EmailOrPhone);
				}
				if (User != null) 
				{
					try
					{
						var result = await _userManager.ResetPasswordAsync(User, model.Token, model.NewPassword);
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
