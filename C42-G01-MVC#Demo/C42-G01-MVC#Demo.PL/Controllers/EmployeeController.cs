using C42_G01_MVC_Demo.BLL.Interfaces;
using C42_G01_MVC_Demo.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.CodeDom.Compiler;

namespace C42_G01_MVC01_Demo.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmpolyeeRepository _empolyeeRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public EmployeeController(IEmpolyeeRepository empolyeeRepository, IDepartmentRepository departmentRepository)
        {
            _empolyeeRepository = empolyeeRepository;
            _departmentRepository = departmentRepository;
        }
        public IActionResult Index()
        {
            var Employees = _empolyeeRepository.GetAll();
            return View(Employees);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(string searchforname) 
        {
            if (searchforname is null)
            {
                return BadRequest();
            }
            var result = _empolyeeRepository.GetEmployeesByName(searchforname);
            return View(result);
        }
        [HttpGet]
        public IActionResult Create() 
        {
            ViewBag.Departments = _departmentRepository.GetAll(); 
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee) 
        {
            if (employee is null) 
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                int result = _empolyeeRepository.Add(employee);
                if (result > 0)
                {
                    TempData["Message"] = "The Employee Is Added Successfully";
                }
                return RedirectToAction(nameof(Index));
            }
            else 
            {
                return View(nameof(Create), employee);
            }
        }
        public IActionResult Details(int? id, string ViewName = "Details") 
        {
            if (id is null) 
            {
                return BadRequest();
            }
            var Employee = _empolyeeRepository.GetById(id.Value);
            if (Employee is null) 
            {
                return NotFound();
            }
            return View(ViewName, Employee);
        }
        public IActionResult Edit(int id) 
        {
            ViewBag.Departments = _departmentRepository.GetAll();
            return Details(id, nameof(Edit));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee employee, [FromRoute] int id) 
        {
            if (employee.Id != id)
            {
                return BadRequest();
            }
            try
            {
                if (ModelState.IsValid)
                {
                    int result = _empolyeeRepository.Update(employee);
                    if (result > 0)
                    {
                        TempData["Message"] = "The Employee Is Updated Successfully";
                    }
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (System.Exception ex)
            {

                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(employee);
        }
        public IActionResult Delete(int id) 
        {
            return Details(id, nameof(Delete));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Employee employee, [FromRoute] int? id) 
        {
            if (employee.Id != id) 
            {
                return BadRequest();
            }
            try
            {
                if (ModelState.IsValid) 
                {
                    _empolyeeRepository.Delete(employee);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (System.Exception ex)
            {

                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(employee);
        }
    }
}
