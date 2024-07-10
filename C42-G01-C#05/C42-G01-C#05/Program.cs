namespace C42_G01_C_05

{
    internal class Program
    {
        static void Main()
        {
            #region 1- Explain the difference between passing (Value type parameters) by value and by reference then write a suitable c# example.
            /* When a parameter is passed by value, a copy of the data is passed to the method. This means that any changes made to the parameter within
             * the method do not affect the original data outside the method. 
             * By default, value types are passed by value.
             */
            // Passing by value
            int valueParam = 10;
            Console.WriteLine("Before passing by value: " + valueParam);
            CheckParameterPassingForValueTypePassByValue(valueParam);
            Console.WriteLine("After passing by value: " + valueParam);

            /*When a parameter is passed by reference, a reference to the actual data is passed to the method. This means that any changes made to 
             * the parameter within the method effect the original data outside the method. 
             * Reference types are inherently passed by reference.
             */
            // Passing by reference using ref
            int refParam = 66;
            Console.WriteLine("Before passing by reference (ref): " + refParam);
            CheckParameterPassingForValueTypePassByReference(ref refParam);
            Console.WriteLine("After passing by reference (ref): " + refParam);
            #endregion

            #region 2- Explain the difference between passing (Reference type parameters) by value and by reference then write a suitable c# example.
            /* For Reference Data Type ⇒ the Reference Type variables is by default passing by value.
             * Change in the variable in the function body Effect the original value of the variable because you pass a value contain a reference 
             * for the original value.
             */
            //Passing by value
            int[] referenceParamByValue = { 1, 2, 3 };
            Console.Write($"Before passing by value: ");
            for (int i = 0; i < referenceParamByValue.Length; i++)
            {
                Console.Write(referenceParamByValue[i]);
            }
            Console.WriteLine();            
            CheckParameterPassingForReferenceTypePassByValue(referenceParamByValue);
            Console.Write($"After passing by value:  ");
            for (int i = 0; i < referenceParamByValue.Length; i++)
            {
                Console.Write(referenceParamByValue[i]);
            }
            Console.WriteLine();

            /*For Reference Data Type ⇒ to pass Reference type variably by reference you should add ref before data type and variable name in the prototype 
             * and  when calling function.
             * Change in the variable in the function body Effect the original value of the variable because you pass you pass the Array (Object) itself.
             * The Main Difference between passing Reference Type Variable by Value or by Reference is when you passing by Value you pass the Reference
             * Value of the object but when you pass with Reference you pass the Object it self.
             * Passing by Reference or by Value will always give the Same Result unless in one case When passing by Value and change the object itself 
             * with another Object value.   
             */
            //Passing by Reference 
            int[] referenceParamByReference = { 1, 2, 3 };
            Console.Write($"Before passing by Reference: ");
            for (int i = 0; i < referenceParamByReference.Length; i++)
            {
                Console.Write(referenceParamByReference[i]);
            }
            Console.WriteLine();
            CheckParameterPassingForReferenceTypePassByReference(ref referenceParamByReference);
            Console.Write($"After passing by Reference:  ");
            for (int i = 0; i < referenceParamByReference.Length; i++)
            {
                Console.Write(referenceParamByReference[i]);
            }
            Console.WriteLine();
            #endregion

            #region 3- Write a c# Function that accept 4 parameters from user and return result of summation and subtracting of two numbers
            int Variable0301 = 10;
            int Variable0302 = 20;
            int Variable03OSummationOutPeramter;
            int Variable03OSubstractingOutPeramter;
            SummationAndSubstracting(Variable0301, Variable0302, out Variable03OSummationOutPeramter, out Variable03OSubstractingOutPeramter);
            Console.WriteLine($"{Variable03OSummationOutPeramter}, {Variable03OSubstractingOutPeramter}");
            #endregion

            #region 4- Write a program in C# Sharp to create a function to calculate the sum of the individual digits of a given number
            Console.WriteLine(SummationOfNumberDigits(50066984));
            #endregion

            #region 5- Create a function named "IsPrime", which receives an integer number and retuns true if it is prime, or false if it is not:
            Console.WriteLine(IsPrime(55));
            #endregion

            #region 7- Create a function named MinMaxArray, to return the minimum and maximum values stored in an array, using reference parameters
            int[] Variable0601Arr = { 5, 6, 9, 14, 1, 4, 99 };
            int Variable0602MinimumOut;
            int Variable0603MaximumOut;
            MinMaxArray(Variable0601Arr, out Variable0602MinimumOut, out Variable0603MaximumOut);
            Console.WriteLine(Variable0602MinimumOut);
            Console.WriteLine(Variable0603MaximumOut);
            #endregion

            #region 7- Create an iterative (non-recursive) function to calculate the factorial of the number specified as parameter
            Console.WriteLine(FactorialOfNumber(7));
            #endregion

            #region 8- Create a function named "ChangeChar" to modify a letter in a certain position (0 based) of a string, replacing it with a different letter
            Console.WriteLine(ChangeChar("Ahmed", 4, 'f'));
            #endregion
        }
        static void CheckParameterPassingForValueTypePassByValue(int x)
        {
            x = 5;
        }
        static void CheckParameterPassingForValueTypePassByReference(ref int x)
        {
            x = 5;
        }
        static void CheckParameterPassingForReferenceTypePassByValue(int[] x)
        {
            x = new int[3] {5, 6, 7};
        }
        static void CheckParameterPassingForReferenceTypePassByReference(ref int[] x)
        {
            x = new int[3] { 5, 6, 7 };
        }
        static void SummationAndSubstracting(int x, int y, out int sum, out int sub)
        {
            sum = x + y;
            sub = y - x;
        }   
        static int SummationOfNumberDigits(int x)
        {
            int Result = 0;
            int Reminder = 0;
            do
            {
                if (x % 10 == 0)
                {
                    if (x / 10 < 10)
                    {
                        Result += x / 10;
                        break;
                    }
                    else 
                    {                    
                        x /=  10;
                        continue;
                    }
                }
                else 
                {
                    Reminder = x % 10;
                    x -= Reminder;
                    Result += Reminder;
                }

            } while (x != 0);
            return Result;
        }
        static bool IsPrime(int x) 
        {
            if (x <= 1)
                return false;
            if (x == 2)
                return true;
            for (int i = x - 1; i > 1; i--) 
            {
                if (x % i == 0)
                    return false;
            }
            return true;
        }
        static void MinMaxArray(int[] x, out int minimun, out int maximum)
        {
            minimun = x.Min();
            maximum = x.Max();
        }
        static int FactorialOfNumber(int x) 
        {
            int Result = x; 
            for (int i = x-1; i > 0; i--)
            {
                Result *= i;
            }
            return Result;
        }
        static string ChangeChar(string word, int position, char letter)
        {
            return word.Replace(word[position], letter);
        }
    }
}
