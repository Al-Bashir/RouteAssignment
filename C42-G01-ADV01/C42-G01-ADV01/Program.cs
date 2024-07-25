using C42_G01_ADV01.Class;
using C42_G01_ADV01.Struct;
namespace C42_G01_ADV01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Part 01
            /* To optimize Bubble Sort we can terminate the sort early if the first round passed without swap, and this indicate the dataset is 
             * already sorted.
             * and this can be done by introduce boolean as Flag to check it every round, and if it's state not converted from false we will
             * terminate the operation due to the dataset is already sorted*/
            
            int[] array = { 5, 1, 4, 2, 8 };
            bool SwapFlag = false;
            for (int i = 0; i < array.Length - 1; i++)
            {
                SwapFlag = false;
                for (int j = 0; j < array.Length - 1 - i; j++) 
                {
                    if (array[j] > array[j + 1])
                    { 
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;

                        SwapFlag = true;
                    }
                }
                if (!SwapFlag)
                    break;
            }

            for (int i = 0;i < array.Length; i++) 
                Console.WriteLine(array[i]);

            #endregion

            #region Part 02
            ForRangeTest Minimum = new ForRangeTest(50);
            ForRangeTest Maximum = new ForRangeTest(100);
            ForRangeTest RangeTest = new ForRangeTest(99);
            Range<ForRangeTest> range = new Range<ForRangeTest>(Minimum, Maximum); 
            Console.WriteLine(range.Length());
            if (range.IsInRange(RangeTest))
                Console.WriteLine("Yes");
            else 
                Console.WriteLine("No");
            #endregion
        }
    }
}
