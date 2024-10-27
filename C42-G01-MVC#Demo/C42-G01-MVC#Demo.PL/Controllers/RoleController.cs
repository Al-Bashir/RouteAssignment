using AutoMapper;
using C42_G01_MVC01_Demo.PL.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace C42_G01_MVC01_Demo.PL.Controllers
{
    [Authorize]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public RoleController(RoleManager<IdentityRole> roleManager, IMapper mapper) 
        {
            _roleManager = roleManager;
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
    }
}
