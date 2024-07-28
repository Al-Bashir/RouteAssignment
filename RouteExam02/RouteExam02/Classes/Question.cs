using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteExam02.Classes
{
    internal abstract class Question
    {
        #region Properties
        public string Header { get; set; }
        public string Body { get; set; }
        public int Mark { get; set; }
        public abstract int RightAnswerId { get; set; }
        public int UserQuestionAnswer { get; set; }
        public abstract bool QuestionResult { get; }


        #endregion

        #region Constructor
        public Question(string header, string body, int mark)
        {
            Header = header;
            Body = body;
            Mark = mark;
        }
        #endregion

        #region Override Methods
        public override string ToString()
        {
            return $"{Header}   Mark: {Mark}\n\n {Body}";
        }
        #endregion

        #region Methods
        public abstract string GetRightAnswer();
        public abstract string GetUserAnswer();
        #endregion
    }
}
