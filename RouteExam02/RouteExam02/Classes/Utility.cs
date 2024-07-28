using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteExam02.Classes
{
    internal static class Utility
    {
        #region Methods
        public static int GetTheQuestionTypeFromUser() 
        {
            bool UserInputCheckerFlage = true;
            bool IsFirstTime = false;
            Console.WriteLine("Please Enter The Type Of Question (1 For MCQ | 2 For True | False)");
            int UserQuestionChoise = 0;
            IsFirstTime = false;
            do
            {
                if (!UserInputCheckerFlage || IsFirstTime)
                    Console.WriteLine("The Number You Entered Is Invalid, Please Try Again With A Valid Number.");
                UserInputCheckerFlage = int.TryParse(Console.ReadLine(), out UserQuestionChoise);
                IsFirstTime = true;
            } while (!UserInputCheckerFlage || (UserQuestionChoise != 1 && UserQuestionChoise != 2));
            return UserQuestionChoise;
        }        
        public static Question GetTheQuestionFromUser(int QuestionType) 
        {
            bool UserInputCheckerFlage = true;
            string UserQuestuinBody;
            bool IsFirstTime = false;
            Console.WriteLine("Please Enter The Question Body");
            IsFirstTime = false;
            do
            {
                if (!UserInputCheckerFlage || IsFirstTime)
                    Console.WriteLine("Please Enter A Valid Question Body");
                UserQuestuinBody = Console.ReadLine();
                UserInputCheckerFlage = UserQuestuinBody == String.Empty ? false : true;
                IsFirstTime = true;
            } while (!UserInputCheckerFlage);

            UserInputCheckerFlage = true;
            int UserQuestionMark = 0;
            IsFirstTime = false;
            Console.WriteLine("Please Enter Question Mark");
            IsFirstTime = false;
            do
            {
                if (!UserInputCheckerFlage || IsFirstTime)
                    Console.WriteLine("Please Enter A Valid Question Mark");
                UserInputCheckerFlage = int.TryParse(Console.ReadLine(), out UserQuestionMark);
                IsFirstTime = true;
            } while (!UserInputCheckerFlage || UserQuestionMark == 0);

            if (QuestionType == 1)
            {
                UserInputCheckerFlage = true;
                Answer<string>[] UserMCQQuestuinAnswer = new Answer<string>[3];
                string UserAnswerInput = null;
                IsFirstTime = false;
                Console.WriteLine("Choice Of Question");
                IsFirstTime = false;
                for (int i = 0; i < 3; i++)
                {
                    do
                    {
                        Console.WriteLine($"Please Enter The Choice Number {i + 1}");
                        if (!UserInputCheckerFlage && IsFirstTime)
                            Console.WriteLine("Please Enter A Valid Answer");
                        UserAnswerInput = Console.ReadLine();
                        IsFirstTime = true;
                        if (UserAnswerInput == String.Empty)
                        {
                            UserInputCheckerFlage = false;
                            continue;
                        }
                        UserMCQQuestuinAnswer[i] = new Answer<string> (i+1, UserAnswerInput);
                        UserInputCheckerFlage = true;
                    } while (!UserInputCheckerFlage);
                }
                return new MCQ(UserQuestuinBody, UserQuestionMark, UserMCQQuestuinAnswer, GetTheRightAnswerIdFromUser(QuestionType));
            }
            else
            { 
                return new TrueOrFalse(UserQuestuinBody, UserQuestionMark, GetTheRightAnswerIdFromUser(QuestionType));
            }
            
        }

        public static int GetTheRightAnswerIdFromUser(int QuestionType) 
        {
            bool UserInputCheckerFlage = true;
            int UserValidAnswerId = 0;
            bool IsFirstTime = false;
            Console.WriteLine("Please Enter The Right Answer Id");
            IsFirstTime = false;
            do
            {
                if (!UserInputCheckerFlage || IsFirstTime)
                    Console.WriteLine("Please Enter A Valid Answer Id");
                UserInputCheckerFlage = int.TryParse(Console.ReadLine(), out UserValidAnswerId);
                IsFirstTime = true;
            } while (!UserInputCheckerFlage || UserValidAnswerId <= 0 || UserValidAnswerId > (QuestionType == 1 ? 3 : 2));
            return UserValidAnswerId;
        }

        public static char GetUserChoiceForStartExam() 
        {
            bool UserInputCheckerFlage = true;
            bool IsFirstTime = false;
            Console.WriteLine("Do You Want To Start The Exam? (Y|N)");
            char UserStartExamChoice;
            IsFirstTime = false;
            do
            {
                if (!UserInputCheckerFlage || IsFirstTime)
                    Console.WriteLine("The Value You Entered Is Invalid, Please Try Again With A Valid Char:");
                UserInputCheckerFlage = char.TryParse(Console.ReadLine(), out UserStartExamChoice);
                IsFirstTime = true;
            } while (!UserInputCheckerFlage || !(Char.ToLower(UserStartExamChoice) == 'y' || Char.ToLower(UserStartExamChoice) == 'n'));
            return UserStartExamChoice;
        }
        #endregion
    }
}
