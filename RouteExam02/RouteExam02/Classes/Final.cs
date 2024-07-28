namespace RouteExam02.Classes
{
    internal class Final : Exam
    {
        #region Properties
        public Question[] Questions { get; set; }
        public override Grade Grade { get; protected set; }
        #endregion
        #region Contractor
        public Final(TimeSpan examDuration, int questionNumber) : base(examDuration, questionNumber)
        {
            Questions = new Question[questionNumber];
            Grade = new Grade(0, 0);
        }
        #endregion

        public override Grade CalcGrad()
        {
            foreach (Question question in Questions)
            {
                Grade.FullMarkGrade += question.Mark;
                if (question.QuestionResult == true)
                    Grade.StudentGrade += question.Mark;
            }
            return Grade;
        }

        public override void ShowExamResult()
        {
            for (int i = 0; i < Questions.Length; i++)
            {
                Console.WriteLine($"Question {i + 1}: {Questions[i].Body}");
                Console.WriteLine($"Your Answer => {Questions[i].GetUserAnswer()}");
                Console.WriteLine($"Right Answer => {Questions[i].GetRightAnswer()}");
            }
            Console.WriteLine($"Your Grad Is {Grade.StudentGrade} Of {Grade.FullMarkGrade}");
            Console.WriteLine($"Time: {CalcExamTime}");
            Console.WriteLine("Thank You");
        }

        public override void StartStudentExamination()
        {
            Console.Clear();
            int i = 0;
            ExamStartTime = DateTime.Now;
            while (DateTime.Now - ExamStartTime < ExamDuration && i < QuestionNumber)
            {
                Console.WriteLine(Questions[i]);
                Questions[i].UserQuestionAnswer = Utility.GetTheRightAnswerIdFromUser(Questions[i] is MCQ ? 1 : 2);
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
    }
}
