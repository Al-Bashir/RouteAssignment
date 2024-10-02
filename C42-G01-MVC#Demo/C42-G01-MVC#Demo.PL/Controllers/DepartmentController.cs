using C42_G01_MVC_Demo.BLL.Interfaces;
using C42_G01_MVC_Demo.BLL.Repositories;
using C42_G01_MVC_Demo.DL.Models;
using Microsoft.AspNetCore.Mvc;

namespace C42_G01_MVC01_Demo.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var departments = _unitOfWork.DepartmentRepository.GetAll();
            return View(departments);
        }
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.DepartmentRepository.Add(department);
                int result = _unitOfWork.Complete();
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
        public IActionResult Details(int? id, string viewName = "Details") 
        {
            if (id is null)
            { 
                return BadRequest();
            }
            var department = _unitOfWork.DepartmentRepository.GetById(id.Value);
            if(department is null)
            { 
                return NotFound();
            }
            return View(viewName, department);
        }
        [HttpGet]
        public IActionResult Edit(int? id) 
        {
            return Details(id, "Edit");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Department department, [FromRoute] int id) 
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
                    int result = _unitOfWork.Complete();
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
        public IActionResult Delete(int? id) 
        {
            return Details(id, "Delete");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Department department, [FromRoute] int id)
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
                    _unitOfWork.Complete();
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
