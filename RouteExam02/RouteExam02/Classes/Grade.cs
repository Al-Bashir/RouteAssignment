using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteExam02.Classes
{
    internal class Grade : ICloneable<Grade>, IComparable<Grade>
    {
        public int StudentGrade { get; set; }
        public int FullMarkGrade{ get; set; }

        public Grade(int studentGrade, int fullMarkGradeStudentGrade)
        {
            StudentGrade = studentGrade;
            FullMarkGrade = fullMarkGradeStudentGrade;
        }

        public Grade Clone()
        {
            return new Grade(StudentGrade, FullMarkGrade);
        }

        public int CompareTo(Grade? other)
        {
            if (StudentGrade > other?.StudentGrade) 
                return 1;
            else if (StudentGrade < other?.StudentGrade)
                return -1;
            return 0;
        }
    }
}
