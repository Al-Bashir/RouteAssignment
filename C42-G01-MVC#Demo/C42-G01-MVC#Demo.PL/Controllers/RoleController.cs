using AutoMapper;
using C42_G01_MVC_Demo.DAL.Models;
using C42_G01_MVC01_Demo.PL.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace C42_G01_MVC01_Demo.PL.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, IMapper mapper) 
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index(string SearchValue)
        {
            if (string.IsNullOrEmpty(SearchValue))
            {
                var Roles = await _roleManager.Roles.ToListAsync();
                var MappedRples = _mapper.Map<IEnumerable<IdentityRole>, IEnumerable<IdentityRoleViewModel>>(Roles);
                return View(MappedRples);
            }
            else
            {
                var Role = await _roleManager.FindByNameAsync(SearchValue);
                var MappedRple = _mapper.Map<IdentityRole, IEnumerable<IdentityRoleViewModel>>(Role);
                return View(MappedRple); 
            }
        }
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IdentityRoleViewModel model) 
        {
            if (model is null) 
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                var MappedModel = _mapper.Map<IdentityRoleViewModel, IdentityRole>(model);
                await _roleManager.CreateAsync(MappedModel);
                return RedirectToAction(nameof(Index));
            }
            else 
            {
                return View(model);
            }
        }
        public async Task<IActionResult> Details(string id, string ViewName = "Details")
        {
            if (string.IsNullOrEmpty(id)) 
            {
                return BadRequest();
            }
            var Role = await _roleManager.FindByIdAsync(id);
            var MappedRole = _mapper.Map<IdentityRole, IdentityRoleViewModel>(Role);
            return View(ViewName, MappedRole);
        }
        public async Task<IActionResult> Edit(string id) 
        {
            return await Details(id, "Edit");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(IdentityRoleViewModel model, [FromRoute] string id) 
        {
            if (string.IsNullOrEmpty(id) || model.Id != id)  
            {
                return BadRequest();
            }
            if (ModelState.IsValid) 
            {
                try
                {
                    var Role = await _roleManager.FindByIdAsync(model.Id);
                    Role.Name = model.Name;
                    var result = await _roleManager.UpdateAsync(Role);
                    if (result.Succeeded)
                    {
                        TempData["Message"] = "The Role Is Updated Successfully";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        string errors = "";
                        foreach (var error in result.Errors)
                        {
                            errors += error.Description;
                        }
                        ModelState.AddModelError(string.Empty, errors);
                    }
                }
                catch (System.Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(model);
        }
        public async Task<IActionResult> Delete(string id) 
        {
            return await Details(id, "Delete");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(IdentityRoleViewModel model, [FromRoute] string id)  
        {
            if (string.IsNullOrEmpty(id) || model.Id != id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var Role = await _roleManager.FindByIdAsync(model.Id);
                    var result = await _roleManager.DeleteAsync(Role);
                    if (result.Succeeded)
                    {
                        TempData["Message"] = "The Role Is Deleted Successfully";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        string errors = "";
                        foreach (var error in result.Errors)
                        {
                            errors += error.Description;
                        }
                        ModelState.AddModelError(string.Empty, errors);
                    }
                }
                catch (System.Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(model);
        }
        public async Task<IActionResult> RoleAssignment(string id, bool error, string message) 
        {
            if (string.IsNullOrEmpty(id)) 
            {
                return BadRequest();
            }
            var Role = await _roleManager.FindByIdAsync(id);
            var MappedRole = _mapper.Map<IdentityRole, IdentityRoleViewModel>(Role);
            if (Role is null)
            {
                return BadRequest();
            }
            var RoleUserList = await _userManager.GetUsersInRoleAsync(Role.Name);
            var MappedRoleUserList = _mapper.Map<IEnumerable<ApplicationUser>, IEnumerable<LightUserViewModel>>(RoleUserList);
            var model = new RoleUsersViewModel()
            {
                Role = MappedRole,
                Users = MappedRoleUserList
            };

            if (error)
            {
                ModelState.AddModelError(string.Empty, message);
            }
            else 
            {
                TempData["Message"] = message;
            }

            return View(model);
        }
        public async Task<IActionResult> AssignNewRoleToUser(string RoleName, string SearchValue, bool error, string message) 
        {
            if (string.IsNullOrEmpty(RoleName)) 
            {
                return BadRequest();
            }
            TempData["RoleName"] = RoleName;
            var Role = await _roleManager.FindByNameAsync(RoleName);
            TempData["RoleId"] = Role.Id;
            var MappedUsers = _mapper.Map<IEnumerable<ApplicationUser>, IEnumerable<LightUserViewModel>>(_userManager.Users);
            var usersInRole = await _userManager.GetUsersInRoleAsync(RoleName);
            var MappedUsersInRole = _mapper.Map<IEnumerable<ApplicationUser>, IEnumerable<LightUserViewModel>>(usersInRole);
            var usersNotInRole = MappedUsers.ExceptBy(MappedUsersInRole.Select(U => U.Id), U => U.Id).ToList();
            if (string.IsNullOrEmpty(SearchValue))            
            {
                return View(usersNotInRole);
            }
            else
            {
                var ResultUsers = usersNotInRole.Where(U => U.FullName.Contains(SearchValue, StringComparison.OrdinalIgnoreCase) == true);
                return View(ResultUsers);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AssignNewRoleToUser(string UserId, string RoleName) 
        {
            if (string.IsNullOrEmpty(UserId) || string.IsNullOrEmpty(RoleName)) 
            {
                return RedirectToAction("AssignNewRoleToUser", new { RoleName = RoleName, error = true, message = "Bad Input" });
            }
            try
            {
                var User = await _userManager.FindByIdAsync(UserId);
                if (User is null || _userManager.GetRolesAsync(User).Result.Any(S => S == RoleName)) 
                {
                    return RedirectToAction("AssignNewRoleToUser", new { RoleName = RoleName, error = true, message = "Bad Input" });
                }
                var result =await _userManager.AddToRoleAsync(User, RoleName);
                if (result.Succeeded)
                {
                    return Json(new { success = true });
                }
                else 
                {
                    return RedirectToAction("AssignNewRoleToUser", new { RoleName = RoleName, error = true, message = "Operation Failed" });
                }
            }
            catch (System.Exception)
            {
                return RedirectToAction("AssignNewRoleToUser", new { RoleName = RoleName, error = true, message = "Operation Failed" });
            }
        }
        public async Task<IActionResult> RemoveRoleFromUser(string Id, string RoleName, string RoleId) 
        {
            if (string.IsNullOrEmpty(Id) || string.IsNullOrEmpty(RoleName))
            {
                return RedirectToAction("RoleAssignment", new { id = RoleId, error = true, message = "User or RoleName is Null" });
            }
            try
            {
                var User = await _userManager.FindByIdAsync(Id);
                if (User is null || !_userManager.GetRolesAsync(User).Result.Any(S => S == RoleName))
                {
                    return RedirectToAction("RoleAssignment", new { id = RoleId, error = true, message = "The User Is Not Found Or Not Assigned To This Role." });
                }
                var result = await _userManager.RemoveFromRoleAsync(User, RoleName);
                if (result.Succeeded)
                {
                    return RedirectToAction("RoleAssignment", new { id = RoleId, error = false, message = "The User Is Removed Successfully From This Role." });
                }
                else
                {
                    return RedirectToAction("RoleAssignment", new { id = RoleId, error = true, message = "Operation Failed" });
                }
            }
            catch (System.Exception)
            {
                return RedirectToAction("RoleAssignment", new { id = RoleId, error = true, message = "Operation Failed" });
            }
        }
    }
}
