using C42_G01_MVC_Demo.BLL.Interfaces;
using C42_G01_MVC_Demo.BLL.Repositories;
using C42_G01_MVC_Demo.DL.Models;
using Microsoft.AspNetCore.Mvc;

namespace C42_G01_MVC01_Demo.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public IActionResult Index()
        {
            var departments = _departmentRepository.GetAll();
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
                _departmentRepository.Add(department);
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
            var department = _departmentRepository.GetById(id.Value);
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
                    _departmentRepository.Update(department);
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
                    _departmentRepository.Delete(department);
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
