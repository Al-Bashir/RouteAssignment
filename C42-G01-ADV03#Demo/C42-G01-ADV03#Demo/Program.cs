namespace C42_G01_ADV03_Demo
{
    internal class Program
    {
        static void Main( )
        {
            StringFuncDelegate stringFuncDelegate = FunctionsClass1.GEtCountOfUpperChars;
            int Result = stringFuncDelegate.Invoke("Ahmed");
            Console.WriteLine(Result);
        }
    }
}
