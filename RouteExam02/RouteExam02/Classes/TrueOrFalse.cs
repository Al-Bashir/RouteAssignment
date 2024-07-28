using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteExam02.Classes
{
    internal class TrueOrFalse : Question
    {
        #region Properties
        public override int RightAnswerId { get; set; }
        public Answer<bool>[] Answers { get; }
        public override bool QuestionResult { get { return UserQuestionAnswer == RightAnswerId; } }
        #endregion

        #region Constructor
        public TrueOrFalse(string body, int mark, int rightAnswer) : base("True | False Question", body, mark)
        {
            RightAnswerId = rightAnswer;
            Answers = new Answer<bool>[2] { new Answer<bool>(1, true), new Answer<bool>(2, false) };
        }
        #endregion

        #region Override Methods
        public override string ToString()
        {
            string mcqQuestionAnswers = $"{Header}      Mark: {Mark}\n\n{Body}\n\n";
            for (int i = 0; i < Answers.Length; i++)
                mcqQuestionAnswers += Answers[i].ToString();
            return mcqQuestionAnswers;
        }

        public override string GetRightAnswer()
        {
            return Answers[RightAnswerId-1].AnswerText.ToString();
        }
        public override string GetUserAnswer()
        {
            return UserQuestionAnswer == 0 ? "Not Solved" : Answers[UserQuestionAnswer - 1].AnswerText.ToString();
        }
        #endregion

    }
}
