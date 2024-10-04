using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C42_G01_MVC_Demo.DAL.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required(ErrorMessage = "First Name Is Required.")]
        public string FName { get; set; }
        [Required(ErrorMessage = "Last Name Is Required.")]
        public string LName { get; set; }
        [Required]
        public bool IsAgreed { get; set; }
    }
}
