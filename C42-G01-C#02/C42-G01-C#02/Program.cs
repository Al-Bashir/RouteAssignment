using C42_G01_C_02.Classes;

namespace C42_G01_C_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 1- Write a program that allows the user to enter a number then print it.
            Console.WriteLine("Please enter a number between -2,147,483,648 to 2,147,483,647");
            int UserInput;
            bool IsTrueNumber = Int32.TryParse(Console.ReadLine(), out UserInput);
            if (IsTrueNumber)
            {
                Console.WriteLine($"The number you entered is: {UserInput}");

            }
            else
            {
                Console.WriteLine("The number you entered is invalid please try again.");
            }
            #endregion

            #region 2- Write C# program that Assigning one value type variable to another and modifying the value of one variable and mention what will happen
            int X = 5;
            int Y = 10;

            X = Y;

            Y = 20;

            // Changing Y to 20 does not affect X because X already holds a copy of the value of Y not a reference to the Y variable.
            #endregion

            #region 3- Write C# program that Assigning one reference type variable to another and modifying the object through one variable and mention what will happen
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
        }
    }
}
