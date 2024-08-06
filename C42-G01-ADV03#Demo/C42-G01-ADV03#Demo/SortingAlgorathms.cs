using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C42_G01_ADV03_Demo
{
    internal class SortingAlgorathms
    {
        public static void BubbleSort(int[] arr)
        {
            if (arr is not null)
                for (int i = 0; i < arr.Length; i++)
                {
                    for (int j = 0; j < arr.Length - i - 1; j++)
                    {
                        if ((arr[j] > arr[j + 1])
                            SWAP(ref arr[j], ref arr[j + 1]);
                    }
                }
        }

        public static void SWAP(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }
    }
}
