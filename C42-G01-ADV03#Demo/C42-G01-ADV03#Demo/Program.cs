namespace C42_G01_ADV03_Demo
{
    internal class Program
    {
        static void Main( )
        {
            StringFuncDelegate stringFuncDelegate = FunctionsClass1.GEtCountOfUpperChars;
            int Result = stringFuncDelegate.Invoke("Ahmed");
            Console.WriteLine(Result);

            Predicate<int> predicate = delegate (int x) { return x > 0; };

            Func<int, string> func = test02;
            func(5);

            Action action;
            Action<string> actionT = test04;
            actionT("55");

        }
        public static string test02(int x) {
            return x.ToString();
        }
        public static void test03() {
            Console.WriteLine();
        }      
        public static void test04(string x) {
            Console.WriteLine(x);
        }
    }
}
