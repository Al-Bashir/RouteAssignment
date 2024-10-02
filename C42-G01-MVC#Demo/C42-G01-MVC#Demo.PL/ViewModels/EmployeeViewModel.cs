using C42_G01_MVC_Demo.DL.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.AspNetCore.Http;

namespace C42_G01_MVC01_Demo.PL.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name is Required.")]
        [MaxLength(50, ErrorMessage = "The Name must be less than 50 character.")]
        [MinLength(5, ErrorMessage = "The Name must be more than 5 character.")]
        public string Name { get; set; }

        public IFormFile Image { get; set; }
        public string ImageFileName { get; set; }

        [Range(22, 35, ErrorMessage = "Age must be between 22 and 35.")]
        public int? Age { get; set; }

        [RegularExpression("^[0-9]{1,3}-[a-zA-Z]{5,10}-[a-zA-Z]{4,10}-[a-zA-Z]{5,10}$", ErrorMessage = "Address must be like: 123-Street-City-Country.")]
        public string Address { get; set; }

        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        public bool IsActive { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        public DateTime HireDate { get; set; }

        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }

        [InverseProperty("Employees")]
        public Department Department { get; set; }
    }
}
