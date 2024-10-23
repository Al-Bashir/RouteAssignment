using AutoMapper;
using C42_G01_MVC_Demo.DAL.Models;
using C42_G01_MVC_Demo.DL.Models;
using C42_G01_MVC01_Demo.PL.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C42_G01_MVC01_Demo.PL.Controllers
{
    
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public UserController(UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index(string SearchValue)
        {
            if (string.IsNullOrEmpty(SearchValue))
            {
                var Users = await _userManager.Users.Select(U => new UserViewModel()
                {
                    Id = U.Id,
                    FName = U.FName,
                    LName = U.LName,
                    Email = U.Email,
                    PhoneNumber = U.PhoneNumber,
                    Roles = _userManager.GetRolesAsync(U).Result
                }).ToListAsync();
                return View(Users);
            }
            else
            {
                var ApplicationUser = await _userManager.FindByEmailAsync(SearchValue);
                var UserList = new List<UserViewModel>();
                if (ApplicationUser is not null)
                {
                    var User = new UserViewModel()
                    {
                        Id = ApplicationUser.Id,
                        FName = ApplicationUser.FName,
                        LName = ApplicationUser.LName,
                        Email = ApplicationUser.Email,
                        PhoneNumber = ApplicationUser.PhoneNumber,
                        Roles = _userManager.GetRolesAsync(ApplicationUser).Result
                    };
                    UserList.Add(User);
                }
                return View(UserList);
            }
        }
        
        public async Task<IActionResult> Details(string id, string ViewName = "Details") 
        {
            if (string.IsNullOrEmpty(id)) 
            {
                return BadRequest();
            }
            var User = await _userManager.FindByIdAsync(id);
            if (User == null) 
            {
                return NotFound();
            }
            var MappedUser = _mapper.Map<ApplicationUser, UserViewModel>(User); 
            return View(ViewName, MappedUser);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            return await Details(id, "Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserViewModel model, [FromRoute] string id) 
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var MappedUser = _mapper.Map<UserViewModel, ApplicationUser>(model);
                    var result = await _userManager.UpdateAsync(MappedUser);
                    if (result.Succeeded)
                    {
                        TempData["Message"] = "The Department Is Updated Successfully";
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(nameof(Edit), id);
        }
    }
}
