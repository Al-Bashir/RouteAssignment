using C42_G01_ADV02.Classes;
using System.Collections;

namespace C42_G01_ADV02
{
    internal class Program
    {
        static void Main()
        {
            #region Part 02 - 01
            Console.WriteLine("===========Part 02 - 01===========");
            ArrayList arrayList = new ArrayList(new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 });
            Utility.ReverseArrayList(arrayList);
            for (int i = 0; i < arrayList.Count; i++)
                Console.WriteLine(arrayList[i]);
            #endregion            
            
            #region Part 02 - 02
            Console.WriteLine("===========Part 02 - 02===========");
            List<int> list02 = new List<int>(new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 });
            list02 = Utility.ListWithEvenNumbersOnly(list02);
            for (int i = 0; i < list02.Count; i++)
                Console.WriteLine(list02[i]);
            #endregion

            #region Part 02 - 03
            Console.WriteLine("===========Part 02 - 03===========");
            FixedSizeList<int> fixedSizeList = new FixedSizeList<int>(5);
            try
            {
                fixedSizeList.Add(0);
                fixedSizeList.Add(1);
                fixedSizeList.Add(3);
                fixedSizeList.Add(3);
                fixedSizeList.Add(3);
                fixedSizeList.Add(6);
                Console.WriteLine(fixedSizeList.GetElementByIndex(0));
                Console.WriteLine(fixedSizeList.GetElementByIndex(-1));
                Console.WriteLine(fixedSizeList.GetElementByIndex(3));
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            Console.WriteLine(fixedSizeList.GetElementByIndex(0));
            try
            {
                Console.WriteLine(fixedSizeList.GetElementByIndex(-1));
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            try
            {
                Console.WriteLine(fixedSizeList.GetElementByIndex(7));
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            #endregion
        }
    }
}
