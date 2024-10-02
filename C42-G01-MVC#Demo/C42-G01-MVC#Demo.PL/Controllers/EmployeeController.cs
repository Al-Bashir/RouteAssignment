using AutoMapper;
using C42_G01_MVC_Demo.BLL.Interfaces;
using C42_G01_MVC_Demo.DAL.Models;
using C42_G01_MVC01_Demo.PL.Helpers;
using C42_G01_MVC01_Demo.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace C42_G01_MVC01_Demo.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeController(IUnitOfWork unitOfWork,  IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var Employees = _unitOfWork.EmployeeRepository.GetAll();
            var MappedEmployees = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(Employees);
            return View(MappedEmployees);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(string searchforname) 
        {
            if (searchforname is null)
            {
                return BadRequest();
            }
            var result = _unitOfWork.EmployeeRepository.GetEmployeesByName(searchforname);
            var MappedResult = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(result);
            return View(MappedResult);
        }
        [HttpGet]
        public IActionResult Create() 
        {
            ViewBag.Departments = _unitOfWork.DepartmentRepository.GetAll(); 
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeViewModel employeeVM) 
        {
            if (employeeVM is null) 
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                employeeVM.ImageFileName = DocumentSettings.UploadFile(employeeVM.Image, "Images");
                var Employee = _mapper.Map<EmployeeViewModel, Employee>(employeeVM);
                _unitOfWork.EmployeeRepository.Add(Employee);
                int result = _unitOfWork.Complete();
                if (result > 0)
                {
                    TempData["Message"] = "The Employee Is Added Successfully";
                }
                return RedirectToAction(nameof(Index));
            }
            else 
            {
                return View(nameof(Create), employeeVM);
            }
        }
        public IActionResult Details(int? id, string ViewName = "Details") 
        {
            if (id is null) 
            {
                return BadRequest();
            }
            var Employee = _unitOfWork.EmployeeRepository.GetById(id.Value);
            if (Employee is null) 
            {
                return NotFound();
            }
            var EmployeeVM = _mapper.Map<Employee, EmployeeViewModel>(Employee);
            return View(ViewName, EmployeeVM);
        }
        public IActionResult Edit(int id) 
        {
            ViewBag.Departments = _unitOfWork.DepartmentRepository.GetAll();
            return Details(id, nameof(Edit));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EmployeeViewModel employeeVM, [FromRoute] int id) 
        {
            if (employeeVM.Id != id)
            {
                return BadRequest();
            }
            try
            {
                if (ModelState.IsValid)
                {
                    employeeVM.ImageFileName = DocumentSettings.UploadFile(employeeVM.Image, "Images");
                    var employee = _mapper.Map<EmployeeViewModel, Employee>(employeeVM);
                    _unitOfWork.EmployeeRepository.Update(employee);
                    int result = _unitOfWork.Complete();
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
            return View(employeeVM);
        }
        public IActionResult Delete(int id) 
        {
            return Details(id, nameof(Delete));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(EmployeeViewModel employeeVM, [FromRoute] int? id) 
        {
            if (employeeVM.Id != id) 
            {
                return BadRequest();
            }
            try
            {
                if (ModelState.IsValid) 
                {
                    var employee = _mapper.Map<EmployeeViewModel, Employee>(employeeVM);
                    DocumentSettings.RemoveFile(employee.ImageFileName, "Images");
                    _unitOfWork.EmployeeRepository.Delete(employee);
                    _unitOfWork.Complete();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (System.Exception ex)
            {

                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(employeeVM);
        }
    }
}
