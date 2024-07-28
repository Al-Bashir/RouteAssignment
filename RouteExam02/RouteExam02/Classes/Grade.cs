using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteExam02.Classes
{
    internal class Grade
    {
        public int StudentGrade { get; set; }
        public int FullMarkGrade{ get; set; }

        public Grade(int studentGrade, int fullMarkGradeStudentGrade)
        {
            StudentGrade = studentGrade;
            FullMarkGrade = fullMarkGradeStudentGrade;
        }

    }
}
