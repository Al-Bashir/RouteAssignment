using C42_G01_MVC_Demo.BLL.Interfaces;
using C42_G01_MVC_Demo.BLL.Repositories;
using C42_G01_MVC_Demo.DL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace C42_G01_MVC01_Demo.PL.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            var departments =await _unitOfWork.DepartmentRepository.GetAllAsync();
            return View(departments);
        }
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Department department)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.DepartmentRepository.AddAsync(department);
                int result = await _unitOfWork.CompleteAsync();
                if (result > 0) 
                {
                    TempData["Message"] = "The Department Is Added Successfully";
                }
                return RedirectToAction(nameof(Index));
            }
            else 
            {
                return View(department);
            }
        }
        public async Task<IActionResult> Details(int? id, string viewName = "Details") 
        {
            if (id is null)
            { 
                return BadRequest();
            }
            var department = await _unitOfWork.DepartmentRepository.GetByIdAsync(id.Value);
            if(department is null)
            { 
                return NotFound();
            }
            return View(viewName, department);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id) 
        {
            return await Details(id, "Edit");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Department department, [FromRoute] int id) 
        {
            if (department.Id != id) 
            {
                return BadRequest();
            }
            try
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.DepartmentRepository.Update(department);
                    int result = await _unitOfWork.CompleteAsync();
                    if (result > 0)
                    {
                        TempData["Message"] = "The Department Is Updated Successfully";
                    }
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (System.Exception ex)
            {

                ModelState.AddModelError(string.Empty, ex.Message); 
            }
            return View(department);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id) 
        {
            return await Details(id, "Delete");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Department department, [FromRoute] int id)
        {
            if (department.Id != id)
            {
                return BadRequest();
            }
            try
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.DepartmentRepository.Delete(department);
                    await _unitOfWork.CompleteAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (System.Exception ex)
            {

                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(department);
        }
    }
}
