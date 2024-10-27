using AutoMapper;
using C42_G01_MVC_Demo.BLL.Interfaces;
using C42_G01_MVC_Demo.DAL.Models;
using C42_G01_MVC01_Demo.PL.Helpers;
using C42_G01_MVC01_Demo.PL.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace C42_G01_MVC01_Demo.PL.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeController(IUnitOfWork unitOfWork,  IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var Employees = await _unitOfWork.EmployeeRepository.GetAllAsync();
            var MappedEmployees = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(Employees);
            return View(MappedEmployees);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(string SearchValue) 
        {
            if (SearchValue is null)
            {
                return BadRequest();
            }
            var result = _unitOfWork.EmployeeRepository.GetEmployeesByName(SearchValue);
            var MappedResult = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(result);
            return View(MappedResult);
        }
        [HttpGet]
        public async Task<IActionResult> Create() 
        {
            ViewBag.Departments = await _unitOfWork.DepartmentRepository.GetAllAsync(); 
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeViewModel employeeVM) 
        {
            if (employeeVM is null) 
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                employeeVM.ImageFileName = DocumentSettings.UploadFile(employeeVM.Image, "Images");
                var Employee = _mapper.Map<EmployeeViewModel, Employee>(employeeVM);
                await _unitOfWork.EmployeeRepository.AddAsync(Employee);
                int result = await _unitOfWork.CompleteAsync();
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
        public async Task<IActionResult> Details(int? id, string ViewName = "Details") 
        {
            if (id is null) 
            {
                return BadRequest();
            }
            var Employee = await _unitOfWork.EmployeeRepository.GetByIdAsync(id.Value);
            if (Employee is null) 
            {
                return NotFound();
            }
            var EmployeeVM = _mapper.Map<Employee, EmployeeViewModel>(Employee);
            return View(ViewName, EmployeeVM);
        }
        public async Task<IActionResult> Edit(int id) 
        {
            ViewBag.Departments = await _unitOfWork.DepartmentRepository.GetAllAsync();
            return await Details(id, nameof(Edit));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EmployeeViewModel employeeVM, [FromRoute] int id) 
        {
            if (employeeVM.Id != id)
            {
                return BadRequest();
            }
            try
            {
                if (ModelState.IsValid)
                {
                    var OldImageFileName = employeeVM.ImageFileName;
                    if (employeeVM.Image is not null)
                    {
                        employeeVM.ImageFileName = DocumentSettings.UploadFile(employeeVM.Image, "Images");
                    }
                    else {
                        employeeVM.ImageFileName = OldImageFileName;
                        OldImageFileName = null;
                    }
                    var employee = _mapper.Map<EmployeeViewModel, Employee>(employeeVM);
                    _unitOfWork.EmployeeRepository.Update(employee);
                    int result = await _unitOfWork.CompleteAsync();
                    if (result > 0)
                    {
                        TempData["Message"] = "The Employee Is Updated Successfully";
                        if (OldImageFileName is not null)
                        { 
                            DocumentSettings.RemoveFile(OldImageFileName, "Images");
                        }
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
        public async Task<IActionResult> Delete(int id) 
        {
            return await Details(id, nameof(Delete));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(EmployeeViewModel employeeVM, [FromRoute] int? id) 
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
                    _unitOfWork.EmployeeRepository.Delete(employee);
                    var result =await _unitOfWork.CompleteAsync();
                    if (result > 0 && employee.ImageFileName is not null) 
                    {
                        DocumentSettings.RemoveFile(employee.ImageFileName, "Images");
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
    }
}
