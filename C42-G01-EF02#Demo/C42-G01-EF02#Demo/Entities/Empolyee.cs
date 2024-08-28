using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C42_G01_EF02_Demo.Entities;

namespace C42_G01_EF02_Demo.Classes
{
    internal class Empolyee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmpId { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        //[MaxLength(20)]
        [StringLength(50, MinimumLength = 10)]
        public string EmpName { get; set; }
        //[Column(TypeName = "Money")]
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
        [Range(20, 40)]
        public int? Age { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string PhoneNumper { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [ForeignKey("Department")]
        public int? DepartmentDeptId { get; set; }
        public Department Department { get; set; }
    }
}
