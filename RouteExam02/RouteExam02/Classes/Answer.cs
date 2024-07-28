using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteExam02.Classes
{
    internal class Answer<T>
    {
        #region Properties
        public int AnswerId { get; }
        public T AnswerText { get; set; } 
        #endregion

        #region Constructor
        public Answer(int answerId, T answerText)
        {
            AnswerId = answerId;
            AnswerText = answerText;
        }
        #endregion

        #region Override Methods
        public override string ToString()
        {
            return $"{AnswerId}- {AnswerText.ToString()}\n";
        }
        #endregion

    }
}
