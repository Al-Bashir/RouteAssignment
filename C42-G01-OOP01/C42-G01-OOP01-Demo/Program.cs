namespace C42_G01_OOP01_Demo
{
    internal class Program
    {
        #region Demo #6
        static void DoSomeProtectiveCode()
        {
            int x, y, z;
            bool flag;
            do
            {
                Console.WriteLine("Please enter first number");
                flag = int.TryParse(Console.ReadLine(), out x);
            } while (!flag);
            do
            {
                Console.WriteLine("Please enter second number");
                flag = int.TryParse(Console.ReadLine(), out y);
            } while (!flag || y == 0);

            z = x / y;

            int[] Numbers = { 1, 2, 3 };
            if (Numbers?.Length > 10)
                Numbers[10] = 100;
        }
        static void DoSomeCode()
        {
            int x, y, z;
            x = int.Parse(Console.ReadLine());
            y = int.Parse(Console.ReadLine());
            z = x / y;

            int[] Numbers = { 1, 2, 3 };
            Numbers[10] = 100;
        }
        static void Main()
        {
            try
            {
                DoSomeProtectiveCode();
                throw new Exception();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                //Free unmanaged resources 
                //Used wit connection with database
                Console.WriteLine("Finally");
            }
        }
        #endregion
    }
}
