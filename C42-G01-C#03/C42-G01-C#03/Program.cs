using C42_G01_C_02.Classes;
using System.Diagnostics;

namespace C42_G01_C_03
{
    internal class Program
    {
        static void Main()
        {
            #region 1- Write a program that takes a number from the user then print yes if that number can be divided by 3 and 4 otherwise print no.
            Console.Write("Please enter a number: ");
            int UserInputNum01;
            bool IsTrueNumberNum01 = int.TryParse(Console.ReadLine(), out UserInputNum01);
            if (IsTrueNumberNum01)
            {
                Console.WriteLine(UserInputNum01 % 3 == 0 && UserInputNum01 % 4 == 0 ? "Yes" : "No");
            }
            else {
                Console.Write("Please try again with a valid number");
            }
            #endregion

            #region 2- Write a program that allows the user to insert an integer then print negative if it is negative number otherwise print positive.
            Console.Write("Please enter a number: ");
            int UserInputNum02;
            bool IsTrueNumberNum02 = int.TryParse(Console.ReadLine(), out UserInputNum02);
            if (IsTrueNumberNum02)
            {
                Console.WriteLine(UserInputNum02 >= 0 ? "positive" : "negative");
            }
            else
            {
                Console.Write("Please try again with a valid number");
            }
            #endregion
            
            #region 3- Write a program that takes 3 integers from the user then prints the max element and the min element.
            Console.Write("Please enter three numbers: ");
            string UserInputNum03 = Console.ReadLine();
            char[] separators = new char[] { ' ', ',' };
            string[] UserInputNum03ToArr = UserInputNum03.Split(separators, StringSplitOptions.TrimEntries);
            int[] UserInputNum03ToIntArr = new int[3];
            for (int i = 0; i < UserInputNum03ToArr.Length; i++)
            {
                UserInputNum03ToIntArr[i] = int.Parse(UserInputNum03ToArr[i]);
            }
            Console.WriteLine($"Max element = {UserInputNum03ToIntArr.Max()}");
            Console.WriteLine($"Min element = {UserInputNum03ToIntArr.Min()}");
            #endregion

            #region 4- Write a program that allows the user to insert an integer number then check If a number is even or odd.
            Console.Write("Please enter a number: ");
            int UserInputNum04;
            bool IsTrueNumberNum04 = int.TryParse(Console.ReadLine(), out UserInputNum04);
            if (IsTrueNumberNum04)
            {
                Console.WriteLine(UserInputNum04 % 2 == 0  ? "Even" : "Odd");
            }
            else
            {
                Console.Write("Please try again with a valid number");
            }
            #endregion

            #region 5- Write a program that takes character from the user then if it is a vowel chars (a,e,I,o,u) then print (vowel) otherwise print (consonant).
            Console.Write("Please enter a character: ");
            char UserInputNum05;
            bool IsTrueInputNum05 = char.TryParse(Console.ReadLine().ToLower(), out UserInputNum05);
            if (IsTrueInputNum05)
            {
                if (UserInputNum05 == 'a' || UserInputNum05 == 'e' || UserInputNum05 == 'i' || UserInputNum05 == 'o' || UserInputNum05 == 'u')
                    Console.WriteLine("vowel");
                else
                    Console.WriteLine("Consonant");
            }
            else {
                Console.Write("Please try again with a valid character");
            }
            #endregion

            #region 6- Write a program that allows the user to insert an integer then print all numbers between 1 to that number.
            Console.Write("Please enter a number: ");
            int UserInputNum06;
            bool IsTrueNumberNum06 = int.TryParse(Console.ReadLine(), out UserInputNum06);
            if (IsTrueNumberNum06)
            {
                for (int i = 1; i < UserInputNum06 + 1; i++)
                {
                    if (i == UserInputNum06)
                        Console.WriteLine(i);
                    else
                        Console.Write($"{i}, ");
                }
            }
            else
            {
                Console.Write("Please try again with a valid number");
            }
            #endregion

            #region 7- Write a program that allows the user to insert an integer then print a multiplication table up to 12.
            Console.Write("Please enter a number: ");
            int UserInputNum07;
            bool IsTrueNumberNum07 = int.TryParse(Console.ReadLine(), out UserInputNum07);
            if (IsTrueNumberNum07)
            {
                for (int i = 1; i <= 12; i++)
                {
                    if (i == 12)
                        Console.WriteLine(i * UserInputNum07);
                    else
                        Console.Write($"{i * UserInputNum07}, ");
                }
            }
            else
            {
                Console.Write("Please try again with a valid number");
            }
            #endregion

            #region 8- Write a program that allows to user to insert number then print all even numbers between 1 to this number
            Console.Write("Please enter a number: ");
            int UserInputNum08;
            bool IsTrueNumberNum08 = int.TryParse(Console.ReadLine(), out UserInputNum08);
            if (IsTrueNumberNum08)
            {
                for (int i = 1; i <= UserInputNum08; i++)
                {
                    if (i % 2 == 0)
                        Console.Write($"{i} ");
                }
                Console.WriteLine(" ");
            }
            else
            {
                Console.Write("Please try again with a valid number");
            }
            #endregion
            
            #region 9- Write a program that takes two integers then prints the power.
            Console.Write("Please enter two numbers: ");
            string UserInputNum09 = Console.ReadLine();
            string[] UserInputNum09ToArr = UserInputNum09.Split(" ", StringSplitOptions.TrimEntries);
            int baseNum = int.Parse(UserInputNum09ToArr[0]);
            int power = int.Parse(UserInputNum09ToArr[1]);
            int Result = 1;
            for (int i = 1; i <= power; i++)
            {
                Result *= baseNum;
            }
            Console.WriteLine(Result);
            #endregion

            #region 10- Write a program to enter marks of five subjects and calculate total, average and percentage.
            Console.Write("Enter Marks of five subjects: ");
            string UserInputNum10 = Console.ReadLine();
            string[] UserInputNum10ToArr = UserInputNum10.Split(" ", StringSplitOptions.TrimEntries);
            int[] UserInputNum10ToArrNum = new int[UserInputNum10ToArr.Length];
            for (int i = 0; i < UserInputNum10ToArr.Length; i++)
            {
                UserInputNum10ToArrNum[i] = int.Parse(UserInputNum10ToArr[i]);
            }
            double PercentageCalc = UserInputNum10ToArrNum.Sum();
            double Total = UserInputNum10ToArr.Length * 100;
            double PercentageResult = (PercentageCalc / Total) * 100;
            Console.WriteLine($"Total marks = {UserInputNum10ToArrNum.Sum()}");
            Console.WriteLine($"Average Marks = {UserInputNum10ToArrNum.Average()}");
            Console.WriteLine($"Percentage = {PercentageResult}%");
            #endregion

            #region 11 - Write a program to input the month number and print the number of days in that month.
            Console.Write("Month Number: ");
            int UserInputNum11;
            bool IsTrueNumberNum11 = int.TryParse(Console.ReadLine(), out UserInputNum11);
            if (IsTrueNumberNum11 && UserInputNum11 <= 12)
            {
                if (UserInputNum11 == 2)
                    Console.WriteLine("Days in Month: 28");
                else if (UserInputNum11 == 11 || UserInputNum11 == 4 || UserInputNum11 == 6 || UserInputNum11 == 9)
                    Console.WriteLine("Days in Month: 30");
                else
                    Console.WriteLine("Days in Month: 31");
            }
            else
            {
                Console.Write("Please try again with a valid month number");
            }
            #endregion
            
            #region 17- Create a program that asks the user to input three points (x1, y1), (x2, y2), and (x3, y3), and determines whether these points lie on a single straight line.
            Console.WriteLine("Please enter three points: ");
            double[] XPoints = new double[3];
            double[] YPoints = new double[3];
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"x{i+1}: ");
                XPoints[i] = double.Parse(Console.ReadLine());
                Console.Write($"y{i+1}: ");
                YPoints[i] = double.Parse(Console.ReadLine());
            }
            string ResultNum17 =
                (YPoints[1] - YPoints[0]) * (XPoints[2] - XPoints[0])
                == (YPoints[2] - YPoints[0]) * (XPoints[1] - XPoints[0])
                ? "The three points lies on a single straight line"
                : "The three points NOT lies on a single straight line";
            Console.WriteLine(ResultNum17);
            #endregion
            
            #region No.: 18
            Console.Write("Please enter the duration taken to complete the task: ");
            float UserInputNum18;
            bool IsTrueNumberNum18 = float.TryParse(Console.ReadLine(), out UserInputNum18);
            if (IsTrueNumberNum18 && UserInputNum18 > 0)
            {
                string ResultNum18 = UserInputNum18 switch
                {
                    float Num when Num <= 3 => "Worker is highly efficient.",
                    float Num when Num <= 4 => "The worker should be instructed to increase his speed.",
                    float Num when Num <= 5 => "The worker should be provided with training to enhance his speed.",
                    _ => "The worker should leave the company.",
                };
                Console.WriteLine(ResultNum18);
            }else
            {
                Console.Write("Please try again with a valid number");
            }
            #endregion
            
            #region 21-	Write C# program that Assigning one value type variable to another and modifying the value of one variable and mention what will happen
            int X = 5;
            int Y = 10;

            X = Y;

            Y = 20;

            // Changing Y to 20 does not affect X because X already holds a copy of the value of Y not a reference to the Y variable.
            #endregion
            
            #region 22-	Write C# program that Assigning one reference type variable to another and modifying the object through one variable and mention what will happen
            ClassForTest variableOne = new ClassForTest();
            variableOne.x = 1;
            variableOne.y = 2;

            ClassForTest variableTwo = new ClassForTest();
            variableTwo.x = 3;
            variableTwo.y = 4;

            variableOne = variableTwo;
            variableTwo.x = 5;
            variableTwo.y = 6;

            //After assign the variableTwo reference to the variableOne the change in variableTwo x and y values effect directly on variableOne x and because now they shear the same reference
            #endregion
            
            #region 23-	Which of the following statements is correct about the C#.NET code snippet given below?
            // Answer: b)	A value 1 will be assigned to d.
            #endregion
             
            #region 24-	Which of the following is the correct output for the C# code given below?
            // Answer: d)	6 1
            #endregion
            
            #region 25-	What will be the output of the C# code given below?
            // Answer: d)	7 7
            #endregion
            
        }
    }
}
