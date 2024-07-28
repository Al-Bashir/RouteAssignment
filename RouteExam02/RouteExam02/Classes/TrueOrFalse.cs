using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteExam02.Classes
{
    internal class TrueOrFalse : Question, ICloneable,IComparable
    {
        #region Properties
        public override int RightAnswerId { get; set; }
        public Answer<bool>[] Answers { get; set; }
        public override bool QuestionResult { get { return UserQuestionAnswer == RightAnswerId; } protected set { } }
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

        public override object Clone()
        {
            TrueOrFalse ClonedTrueOrFalse = new TrueOrFalse((string)Body.Clone(), Mark, RightAnswerId);
            ClonedTrueOrFalse.Answers = (Answer<bool>[])Answers.Clone();
            ClonedTrueOrFalse.UserQuestionAnswer = UserQuestionAnswer;
            ClonedTrueOrFalse.QuestionResult= QuestionResult;
            return ClonedTrueOrFalse;
        }

        public override int CompareTo(object? x)
        {
            if (x == null)
                return 1;
            TrueOrFalse other = (TrueOrFalse)x;
            if (Mark > other?.Mark)
                return 1;
            else if (Mark < other?.Mark)
                return -1;
            return 0;
        }
        #endregion

    }
}
