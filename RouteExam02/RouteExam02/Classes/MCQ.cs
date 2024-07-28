using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteExam02.Classes
{
    internal class MCQ : Question
    {
        #region Properties
        public Answer<string>[] Answers { get; set; }
        public override int RightAnswerId { get; set; }
        public override bool QuestionResult { get { return UserQuestionAnswer == RightAnswerId; } }
        #endregion

        #region Constructor
        public MCQ(string body, int mark, Answer<string>[] answers, int rightAnswer) : base("MCQ Question", body, mark)
        {
            Answers = answers;
            RightAnswerId = rightAnswer;
        }

        #endregion

        #region Override Method
        public override string ToString()
        {
            string mcqQuestionAnswers = $"{Header}      Mark: {Mark}\n\n{Body}\n\n";
            for (int i = 0; i < Answers.Length; i++)
                mcqQuestionAnswers += Answers[i].ToString();
            return mcqQuestionAnswers;
        }
        #endregion

        #region Methods
        public override string GetRightAnswer()
        {
            return Answers[RightAnswerId-1].AnswerText;
        }

        public override string GetUserAnswer()
        {
            return UserQuestionAnswer == 0 ? "Not Solved" : Answers[UserQuestionAnswer - 1].AnswerText;
        }
        #endregion
    }
}
