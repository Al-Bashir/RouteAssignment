using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteExam02.Classes
{
    internal abstract class Exam : IComparable<Exam>, ICloneable<Exam>
    {
        #region Properties
        public TimeSpan ExamDuration { get; set; }
        public int QuestionNumber { get; set; }
        public DateTime ExamStartTime { get; set; }
        public DateTime ExamEndTime { get; set; }

        private TimeSpan calcExamTime;

        public TimeSpan CalcExamTime
        {
            get { return ExamEndTime - ExamStartTime; }
        }
        public abstract Grade Grade { get; protected set; }
        #endregion

        #region Contractor 
        public Exam(TimeSpan examDuration, int questionNumber)
        {
            ExamDuration = examDuration;
            QuestionNumber = questionNumber;
        }
        #endregion

        #region OverrideMethod
        public override string ToString()
        {
            return $"Exam Duration: {ExamDuration} \nQuestion Number: {QuestionNumber}";
        }
        #endregion

        #region Methods
        public static Exam AddNewExam()
        {
            Console.WriteLine("Please Enter The Type Of Exam (1 For Practical | 2 For Final)");
            bool UserInputCheckerFlage = true;
            int UserExamChoise = 0;
            bool IsFirstTime = false;
            do
            {
                if (!UserInputCheckerFlage || IsFirstTime)
                    Console.WriteLine("The Number You Entered Is Invalid, Please Try Again With A Valid Number.");
                UserInputCheckerFlage = int.TryParse(Console.ReadLine(), out UserExamChoise);
                IsFirstTime = true;
            } while (!UserInputCheckerFlage || (UserExamChoise != 1 && UserExamChoise != 2));


            Console.WriteLine("Please Enter The Time For Exam From (30 min to 180 min)");
            IsFirstTime = false;
            int UserExamDuration = 0;
            do
            {
                if (!UserInputCheckerFlage || IsFirstTime)
                    Console.WriteLine("The Number You Entered Is Invalid, Please Try Again With A Valid Number.");
                UserInputCheckerFlage = int.TryParse(Console.ReadLine(), out UserExamDuration);
                IsFirstTime = true;
            } while (!UserInputCheckerFlage || (UserExamDuration < 30 || UserExamDuration > 180));

            Console.WriteLine("Please Enter The Number Of Questions");
            IsFirstTime = false;
            int UserExamQuestionNumber;
            do
            {
                if (!UserInputCheckerFlage || IsFirstTime)
                    Console.WriteLine("The Number You Entered Is Invalid, Please Try Again With A Valid Number.");
                UserInputCheckerFlage = int.TryParse(Console.ReadLine(), out UserExamQuestionNumber);
                UserInputCheckerFlage = UserExamQuestionNumber == 0 ? false: true;
            } while (!UserInputCheckerFlage);

            Console.Clear();

            if (UserExamChoise == 1)
            {
                Practical newPracticalExam = new Practical(TimeSpan.FromMinutes(UserExamDuration), UserExamQuestionNumber);
                for (int i = 0; i < newPracticalExam.QuestionNumber; i++)
                {
                    newPracticalExam.MCQQuestions[i] = (MCQ)Utility.GetTheQuestionFromUser(1);
                    Console.Clear();
                }
                return newPracticalExam;
            }
            else
            {
                Final newFinalExam = new Final(TimeSpan.FromMinutes(UserExamDuration), UserExamQuestionNumber);
                for (int i = 0; i < newFinalExam.QuestionNumber; i++)
                {
                    int QuestionType = Utility.GetTheQuestionTypeFromUser();
                    newFinalExam.Questions[i] = Utility.GetTheQuestionFromUser(QuestionType);
                    Console.Clear();
                }
                return newFinalExam;
            }
        }
        public abstract void StartStudentExamination();
        public abstract void ShowExamResult();
        public abstract Grade CalcGrad();

        public int CompareTo(Exam? obj) 
        {
            return Grade.CompareTo(obj?.Grade);
        }

        public abstract Exam Clone();
        #endregion
    }
}
