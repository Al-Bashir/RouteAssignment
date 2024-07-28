using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteExam02.Classes
{
    internal class Subject : ICloneable, IComparable<Subject>
    {
        #region Properties
        public int SubjectID { get; }
        public string SubjectName { get; set; }
        public Exam SubjectExam { get; private set; }
        #endregion

        #region Constructor 
        public Subject(int subjectID, string subjectName)
        {
            SubjectID = subjectID;
            SubjectName = subjectName;
        }
        #endregion

        #region Override Methods
        public override string ToString()
        {
            return $"Subject ID: {SubjectID}\n Subject Name: {SubjectName}";
        }
        #endregion

        #region Methods
        public void InitiateSubjectExam() 
        
        {
            SubjectExam = Exam.AddNewExam();
            Console.Clear();
            if (Utility.GetUserChoiceForStartExam() == 'y')
            {
                Console.Clear();
                StartExamination();
            }
        }        
        public void StartExamination() 
        {
            SubjectExam.StartStudentExamination();
            Console.Clear();
            SubjectExam.CalcGrad();
            SubjectExam.ShowExamResult();
        }

        public object Clone()
        {
            Subject ClonedSubject = new Subject(SubjectID, SubjectName);
            ClonedSubject.SubjectExam = SubjectExam.Clone();
            return ClonedSubject;
        }

        public int CompareTo(Subject? other)
        {
            return SubjectID.CompareTo(other?.SubjectID);
        }
        #endregion
    }
}
