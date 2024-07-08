namespace C42_G01_OOP01
{
    enum WeekDays
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }

    enum Season
    {
        Spring = 1,
        Summer,
        Autumn,
        Winter
    }
    enum Colors
    {
        Red = 1,
        Green = 2,
        Blue = 3,
    }
    [Flags]
    enum Permissions : byte
    {
        Read = 1,
        write = 2,
        Delete = 4,
        Execute = 8,
    }
    internal class Program
    {

        static void Main()
        {
            
            #region 1.	Create an enum called "WeekDays" with the days of the week (Monday to Sunday) as its members. Then, write a C# program that prints out all the days of the week using this enum.
            for (int i = 0; i < Enum.GetNames(typeof(WeekDays)).Length; i++)
            {
                Console.WriteLine((WeekDays)i);
            }
            #endregion
            
            #region 2.	Create an enum called "Season" with the four seasons (Spring, Summer, Autumn, Winter) as its members. Write a C# program that takes a season name as input from the user and displays the corresponding month range for that season. Note range for seasons ( spring march to may , summer june to august , autumn September to November , winter December to February)
            bool UserInput02Flag = false;
            Season UserInputSeason = default;
            do
            {
                Console.WriteLine("Please enter season name: ");
                string UserInput02String = Console.ReadLine();
                if (UserInput02String == null || UserInput02String.Any(Char.IsDigit))
                    UserInput02Flag = false;
                else
                    UserInput02Flag = Enum.TryParse<Season>(UserInput02String, out UserInputSeason);
            } while (!UserInput02Flag);
            
            string Messege = UserInputSeason switch
            {
                Season.Spring => "spring march to may",
                Season.Summer => "summer june to august",
                Season.Autumn => "autumn September to November",
                Season.Winter => "winter December to February"
            };
            Console.WriteLine(Messege);
            #endregion
            
            #region 3.	Assign the following Permissions (Read, write, Delete, Execute) in a form of Enum.
            Permissions UserPermissions03 = Permissions.Read;
            //Add Permission
            UserPermissions03 = UserPermissions03 | Permissions.write;
            //check if specific Permission is existed inside variable
            Permissions UserPermissions03Check = UserPermissions03 & Permissions.write;
            //Remove Permission
            if ((UserPermissions03 & Permissions.write) == Permissions.write)
                UserPermissions03 = UserPermissions03 ^ Permissions.write;
            #endregion
            
            #region 4.	Create an enum called "Colors" with the basic colors (Red, Green, Blue) as its members. Write a C# program that takes a color name as input from the user and displays a message indicating whether the input color is a primary color or not.
            bool UserInput04Flag = true;
            Colors UserInputColor = default;
            Console.WriteLine("Please enter color name: ");
            string UserInput04String = Console.ReadLine();
            if (UserInput04String == null || UserInput04String.Any(Char.IsDigit))
                UserInput04Flag = false;
            Enum.TryParse<Colors>(UserInput04String, out UserInputColor);
            if (!UserInput04Flag)
            {
                Console.WriteLine("Please try again with a valid color name.");
            }
            else if (UserInputColor == Colors.Green || UserInputColor == Colors.Red || UserInputColor == Colors.Blue)
            {
                Console.WriteLine("The color you entered is a primary color.");
            }
            else
            {
                Console.WriteLine("The color you entered is not primary color.");
            }
            #endregion
            
            #region 5.	Create a struct called "Point" to represent a 2D point with properties "X" and "Y". Write a C# program that takes two points as input from the user and calculates the distance between them.
            Point Point05 = new Point();
            Console.WriteLine("Please enter the X value first the hight Enter to add Y value: ");
            if (int.TryParse(Console.ReadLine(), out Point05.X) && int.TryParse(Console.ReadLine(), out Point05.Y))
            {
                Console.WriteLine(Point05.CalculateDistance());    
            }
            else
            {
                Console.WriteLine("Please try again with a valid numbers");
            }
            #endregion
        }
    }
}
