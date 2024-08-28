using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C42_G01_EF02_Demo.Entities
{
    internal class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        //public ICollection<Student> Students { get; set; } = new List<Student>();
        public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
    }
}
