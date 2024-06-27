using static System.Runtime.InteropServices.JavaScript.JSType;
using System.ComponentModel;

namespace C42_G01_C_04
{
    internal class Program
    {
        static void Main()
        {
            
            #region 1- Write a program that allows the user to insert an integer then print all numbers between 1 to that number.
            Console.Write("Please enter a number: ");
            int UserInputNum01;
            bool IsTrueNumberNum01 = int.TryParse(Console.ReadLine(), out UserInputNum01);
            if (IsTrueNumberNum01)
            {
                for (int i = 1; i <= UserInputNum01; i++)
                {
                    if (i == UserInputNum01)
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
            
            #region 2- Write a program that allows the user to insert an integer then print a multiplication table up to 12.
            Console.Write("Please enter a number: ");
            int UserInputNum02;
            bool IsTrueNumberNum02 = int.TryParse(Console.ReadLine(), out UserInputNum02);
            int BaseNumber = UserInputNum02;
            if (IsTrueNumberNum02)
            {
                for (int i = 1; i <= 12; i++)
                {
                    UserInputNum02 = BaseNumber * i; 
                    Console.Write($"{UserInputNum02} "); 
                }
                Console.WriteLine();
            }
            else
            {
                Console.Write("Please try again with a valid number");
            }
            #endregion
            
            #region 3 - Write a program that allows to user to insert number then print all even numbers between 1 to this number
            Console.Write("Please enter a number: ");
            int UserInputNum03;
            bool IsTrueNumberNum03 = int.TryParse(Console.ReadLine(), out UserInputNum03);
            if (IsTrueNumberNum03)
            {
                for (int i = 1; i <= UserInputNum03; i++)
                {
                    if (i % 2 == 0)
                        Console.Write($"{i} "); 
                }
                Console.WriteLine();
            }
            else
            {
                Console.Write("Please try again with a valid number");
            }
            #endregion
            
            #region 4- Write a program that takes two integers then prints the power.
            Console.Write("Please enter two numbers: ");
            string UserInputNum04 = Console.ReadLine();
            string[] UserInputNum04ToArr = UserInputNum04.Split(" ", StringSplitOptions.TrimEntries);
            int baseNum;
            int power;  
            if (!int.TryParse(UserInputNum04ToArr[0], out baseNum) || !int.TryParse(UserInputNum04ToArr[1], out power))
            {
                Console.Write("Please try again with a valid number");
            }
            else
            {
                int Result = baseNum;
                for (int i = 1; i < power; i++)
                {
                    Result *= baseNum;
                }
                Console.WriteLine(Result); 
            }
            #endregion
            
            #region 5- Write a program to allow the user to enter a string and print the REVERSE of it.
            Console.Write("Please enter a string: ");
            string UserInput05 = Console.ReadLine();
            char [] ReverseInput = new char[UserInput05.Length];
            if (UserInput05 != null)
            {
                for (int i = UserInput05.Length; i > 0; i--)
                {
                    ReverseInput[UserInput05.Length - i] = UserInput05[i - 1];
                }
                string result = new string(ReverseInput);
                Console.WriteLine(result);
            }
            else
            {
                Console.Write("Please try again with a valid string");
            }
            #endregion
            
            #region 6- Write a program in C# Sharp to find prime numbers within a range of numbers.
            Console.Write("Input starting number of range: ");
            string UserInputNum0401 = Console.ReadLine();
            Console.Write("Input ending number of range: ");
            string UserInputNum0402 = Console.ReadLine();
            int RangeStart;
            int RangeEnd;
            if (!int.TryParse(UserInputNum0401, out RangeStart) || !int.TryParse(UserInputNum0402, out RangeEnd))
            {
                Console.Write("Please try again with a valid range");
            }
            else
            {
                Console.WriteLine($"The prime number between {RangeStart} and {RangeEnd} are: ");
                //The principle to check an number is prime or not is by check the modulus of number with all number starting of 2 to the Square root of the number
                for (int i = RangeStart; i <= RangeEnd; i++)
                {
                    double NumberSquareRoot = Math.Sqrt(i);
                    if (i <= 1)
                        continue;
                    if (i == 2)
                    {
                        Console.Write($"{i} ");
                        continue;
                    }
                    bool IsPrime = true;
                    for (int j = 2; j <= NumberSquareRoot; j++) 
                    {
                        if (i % j == 0)
                        {
                            IsPrime = false;
                            break;
                        }
                    }
                    if (IsPrime) 
                    {
                        Console.Write($"{i} ");
                    }
                }
                Console.WriteLine();
            }
            #endregion
            
            #region 7- . Write a program in C# Sharp to convert a decimal number into binary without using an array.
            Console.Write("Enter a number to convert: ");
            int UserInputNum07;
            bool IsTrueNumberNum07 = int.TryParse(Console.ReadLine(), out UserInputNum07);
            if (IsTrueNumberNum07)
            {
                string Result = UserInputNum07.ToString("B");
                Console.WriteLine($"The Binary of {UserInputNum07} is {Result}");
            }
            else
            {
                Console.Write("Please try again with a valid number");
            }
            #endregion
            
            #region 8- . Write a program that prints an identity matrix using for loop, in other words takes a value n from the user and shows the identity table of size n * n.
            Console.Write("Enter a number of identity matrix: ");
            int UserInputNum08;
            bool IsTrueNumberNum08 = int.TryParse(Console.ReadLine(), out UserInputNum08);
            if (IsTrueNumberNum08)
            {
                for (int i = 0; i < UserInputNum08; i++)
                {
                    for (int j = 0; j < UserInputNum08; j++)
                    {
                        if (i == j)
                        {
                            Console.Write(1);
                        }
                        else
                        {
                            Console.Write(0);
                        }
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.Write("Please try again with a valid number");
            }
            #endregion
            
            #region 9- Write C# program that Extract a substring from a given string.
            Console.WriteLine("Please enter string: ");
            string UserInputNum09 = Console.ReadLine();
            if (UserInputNum09 == null || UserInputNum09.Length < 2) 
            { 
                Console.WriteLine("Please enter a valid string and try again.");
            }
            else
            {
                Console.WriteLine($"This is the substring from the string: {UserInputNum09.Substring(UserInputNum09.Length / 2)}");
            }
            #endregion
            
            #region 10- Write C# program that take two string variables and print them as one variable 
            Console.WriteLine("Please enter the first string: ");
            string UserInputNum101 = Console.ReadLine();
            Console.WriteLine("Please enter the second string: ");
            string UserInputNum102 = Console.ReadLine();
            Console.WriteLine(string.Concat(UserInputNum101, " ", UserInputNum102));
            #endregion
            
            #region 11- . Write a program that prints an identity matrix using for loop, in other words takes a value n from the user and shows the identity table of size n * n.
            Console.Write("Enter a number of identity matrix: ");
            int UserInputNum11;
            bool IsTrueNumberNum11 = int.TryParse(Console.ReadLine(), out UserInputNum11);
            if (IsTrueNumberNum11)
            {
                for (int i = 0; i < UserInputNum11; i++)
                {
                    for (int j = 0; j < UserInputNum11; j++)
                    {
                        if (i == j)
                        {
                            Console.Write(1);
                        }
                        else
                        {
                            Console.Write(0);
                        }
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.Write("Please try again with a valid number");
            }
            #endregion
            
            #region 12- Write a program in C# Sharp to find the sum of all elements of the array.
            int[] ArrayForQ12 = { 1, 2, 3, 4, 5 };
            Console.WriteLine(ArrayForQ12.Sum());  
            #endregion
            
            #region 13- Write a program in C# Sharp to merge two arrays of the same size sorted in ascending order.
            int[] ArrayForQ13Num01 = { 6, 7, 8, 9, 10 };
            int[] ArrayForQ13Num02 = { 1, 2, 3, 4, 5 };
            int[] ArrayForQ13Num03 = new int[ArrayForQ13Num01.Length+ ArrayForQ13Num02.Length]; 
            Array.Copy(ArrayForQ13Num01, 0, ArrayForQ13Num03, 0, ArrayForQ13Num01.Length);
            Array.Copy(ArrayForQ13Num02, 0, ArrayForQ13Num03, ArrayForQ13Num01.Length, ArrayForQ13Num02.Length);
            Array.Sort(ArrayForQ13Num03);
            for (int i = 0; i < ArrayForQ13Num03.Length; i++)
            {

                Console.WriteLine(ArrayForQ13Num03[i]);
            }
            #endregion
            
            #region 14- Write a program in C# Sharp to count the frequency of each element of an array.
            int[] ArrayNum14 = new int[35] { 55, 23, 23, 67, 67, 67, 89, 89, 34, 34, 34, 78, 78, 78, 12, 12, 12, 12, 56, 56,
                                             56, 90, 90, 90, 90, 33, 33, 33, 45, 45, 45, 45, 45, 45, 45  };
            Array.Sort(ArrayNum14);
            int DuplicationNumber = 0;
            for (int i = 1; i < ArrayNum14.Length; i++)
            {
                if (ArrayNum14[i] == ArrayNum14[i-1])
                {
                    DuplicationNumber++;
                    if(i == ArrayNum14.Length - 1 && DuplicationNumber > 0)
                        Console.WriteLine($"Number {ArrayNum14[i]} found duplicated {DuplicationNumber + 1} times");
                }
                else
                {
                    if (DuplicationNumber > 0)
                    {
                        Console.WriteLine($"Number {ArrayNum14[i-1]} found duplicated {DuplicationNumber + 1} times");
                        DuplicationNumber = 0;
                    }
                }
            }
            #endregion
            
            #region Write a program in C# Sharp to find maximum and minimum element in an array
            int[] ArrayNum15 = new int[35] { 55, 23, 23, 67, 67, 67, 89, 89, 34, 34, 34, 78, 78, 78, 12, 12, 12, 12, 56, 56,
                                             56, 90, 90, 90, 90, 33, 33, 33, 45, 45, 45, 45, 45, 45, 45  };
            Array.Sort(ArrayNum15);
            Console.WriteLine($"The Maximum number is: {ArrayNum15.Last()}");
            Console.WriteLine($"The Minimum number is: {ArrayNum15[0]}");
            #endregion
            
            #region 16- Write a program in C# Sharp to find the second largest element in an array.
            int[] ArrayNum16 = new int[35] { 55, 23, 103, 67, 67, 67, 1, 1, 34, 34, 34, 106, 78, 78, 12, 12, 12, 12, 56, 56,
                                             56, 99, 90, 90, 90, 33, 103, 33, 45, 45, 45, 45, 45, 45, 45  };
            Array.Sort(ArrayNum16);
            for (int i = ArrayNum16.Length - 1; i >= 0; i--)
            {
                if (ArrayNum16[i] != ArrayNum16[i-1] && i != (ArrayNum16.Length - 1))
                {
                    Console.WriteLine($"The second Maximum number is: {ArrayNum16[i]}");
                    break;
                }
            }
            #endregion
            
            #region 17-. Consider an Array of Integer values with size N, having values as in this Example
            Console.WriteLine("Please enter the array numbers in one line separated with space: ");
            string UserInputNum17 = Console.ReadLine();
            string[] UserInputNum17AsArrayOfStrings = UserInputNum17.Split(" ", StringSplitOptions.TrimEntries);
            int[] UserInputNum17ArrayOfInt = new int[UserInputNum17AsArrayOfStrings.Length];
            for (int i = 0; i < UserInputNum17AsArrayOfStrings.Length; i++)
            {
                if (!int.TryParse(UserInputNum17AsArrayOfStrings[i], out UserInputNum17ArrayOfInt[i]))
                {
                    Console.WriteLine("Please enter a valid array numbers and try again.");
                    Environment.Exit(0);
                } 
            }
            int HighestDistance = 0;
            int HighLastIndex = 0;
            int HighFirstIndex = 0;
            int HighLastIndexStore = 0;
            int HighFirstIndexStore = 0;
            int NumbersBetween = 0;
            for (int i = 0; i < UserInputNum17ArrayOfInt.Length; i++)
            {
                for (int j =  (i + 1); j < UserInputNum17ArrayOfInt.Length; j++)
                {
                    if (UserInputNum17ArrayOfInt[i] == UserInputNum17ArrayOfInt[j])
                    {                        
                        HighFirstIndex = i;
                        HighLastIndex = j;
                    }
                }
                if (HighLastIndex - HighLastIndex == 1)
                {
                    break;
                }
                NumbersBetween = (HighLastIndex - HighFirstIndex) - 1;
                if (NumbersBetween >= HighestDistance)
                {
                    HighestDistance = NumbersBetween;
                    HighFirstIndexStore = HighFirstIndex;
                    HighLastIndexStore = HighLastIndex;
                }
            }
            Console.WriteLine($"The Highest distance is {HighestDistance} and it is between INDEX number {HighFirstIndexStore + 1} and {HighLastIndexStore + 1}.");
            #endregion
                
            #region 18- Write a program to create two multidimensional arrays of same size. Accept value from user and store them in first array. Now copy all the elements of first array on second array and print second array.
            Console.WriteLine("Please enter the array dimensions in one line separated with space: ");
            string UserInputNum18ArrDimensions = Console.ReadLine();
            string[] UserInputNum18ArrDimensionsAsArray = UserInputNum18ArrDimensions.Split(" ", StringSplitOptions.TrimEntries);
            int UserInputNum18ArrayFirstDimension;
            int UserInputNum18ArraySecondDimension;
            if (!(int.TryParse(UserInputNum18ArrDimensionsAsArray[0], out UserInputNum18ArrayFirstDimension) && int.TryParse(UserInputNum18ArrDimensionsAsArray[1], out UserInputNum18ArraySecondDimension)))
            {
                Console.WriteLine("Please enter a valid array numbers and try again.");
            }
            else {
                int[,] UserInputNum182DArr = new int[UserInputNum18ArrayFirstDimension, UserInputNum18ArraySecondDimension];
                for (int i = 0; i < UserInputNum182DArr.GetLength(0); i++)
                {
                    Console.WriteLine($"The {i + 1} Row: ");
                    Console.Write($"Please enter the column number for the {i + 1} row with space separated: ");
                    string UserInputNum18ForColumnsNum = Console.ReadLine();
                    string[] Num18TempArray = UserInputNum18ForColumnsNum.Split(" ", StringSplitOptions.TrimEntries);
                    for (int k = 0; k < Num18TempArray.Length; k++)
                    {
                        if (!int.TryParse(Num18TempArray[k], out UserInputNum182DArr[i,k])) 
                        {
                            Console.WriteLine("Please enter a valid array numbers and try again.");
                            Environment.Exit(0);
                        }
                    }
                }
                int[,] UserInputNum182DArrCopy = new int[UserInputNum18ArrayFirstDimension, UserInputNum18ArraySecondDimension];
                for (int i = 0; i < UserInputNum182DArr.GetLength(0); i++)
                {
                    for (int j = 0; j < UserInputNum182DArr.GetLength(1); j++)
                    {
                        UserInputNum182DArrCopy[i, j] = UserInputNum182DArr[i, j];
                        Console.Write($"{UserInputNum182DArrCopy[i, j]} ");
                    }
                    Console.WriteLine();
                }
            }
            #endregion

            #region 19- Write a Program to Print One Dimensional Array in Reverse Order
            int[] ArrayNum19 = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            for (int i = (ArrayNum19.Length - 1); i >= 0; i--)
            {
                Console.Write($"{ArrayNum19[i]} ");
            }
            #endregion       
        }
    }
}
