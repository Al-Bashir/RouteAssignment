using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteExam02.Classes
{
    internal class Practical : Exam, ICloneable<Exam>
    {
        #region Properties
        public MCQ[] MCQQuestions { get; set; }
        public override Grade Grade { get; protected set; }
        #endregion

        #region Constructor
        public Practical(TimeSpan examDuration, int questionNumber) : base(examDuration, questionNumber)
        {
            MCQQuestions = new MCQ[questionNumber];
            Grade = new Grade(0, 0);
        }

        public override Grade CalcGrad()
        {
            foreach (MCQ mcq in MCQQuestions)
            {
                Grade.FullMarkGrade += mcq.Mark;
                if (mcq.QuestionResult == true)
                    Grade.StudentGrade += mcq.Mark;
            }
            return Grade;
        }
        public override void ShowExamResult()
        {
            for (int i = 0; i < MCQQuestions.Length; i++)
            {
                Console.WriteLine($"Question {i + 1}: {MCQQuestions[i].Body}");
                Console.WriteLine($"Your Answer => {MCQQuestions[i].GetUserAnswer()}");
                Console.WriteLine($"Right Answer => {MCQQuestions[i].GetRightAnswer()}");
            }
            Console.WriteLine("Thank You");
        }

        public override void StartStudentExamination()
        {
            Console.Clear();
            int i = 0;
            ExamStartTime = DateTime.Now;
            while ( DateTime.Now - ExamStartTime < ExamDuration && i < QuestionNumber)
            {
                Console.WriteLine(MCQQuestions[i]);
                MCQQuestions[i].UserQuestionAnswer = Utility.GetTheRightAnswerIdFromUser(1);
                i++;
            }
            ExamEndTime = DateTime.Now;
            if (DateTime.Now - ExamStartTime > ExamDuration)
            {
                Console.Clear();
                Console.WriteLine("Timeout!!! \nYou Ran Out Of Time. \nYou Will Navigated To Your Result");
                Thread.Sleep(10000);
            }
        }

        public override Exam Clone()
        {
            Practical ClonedPracticalExam = new Practical(ExamDuration, QuestionNumber);
            ClonedPracticalExam.MCQQuestions = (MCQ[])MCQQuestions.Clone();
            ClonedPracticalExam.Grade = Grade.Clone();
            ClonedPracticalExam.ExamStartTime = ExamStartTime;
            ClonedPracticalExam.ExamEndTime = ExamEndTime;
            return ClonedPracticalExam;
        }
        #endregion
    }
}
