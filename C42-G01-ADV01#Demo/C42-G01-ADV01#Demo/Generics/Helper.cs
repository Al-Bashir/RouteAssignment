using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C42_G01_OOP06_Demo.Generics
{
    //T must be class or struct implement interface ICloneable
    internal class Helper <T> where T : ICloneable
    {
        public T Salary { get; set; }

        //T => Generic type
        public static void Swap<T>(ref T x, ref T y)
        { 
            T temp  =  x;
            x = y;
            y = temp;
        }

        //public static int SearchArray(T[] array, T value)
        //{
        //    if (array is not null)
        //    {
        //        for (int i = 0; i < array.Length; i++)
        //        { 
        //            //Can not use == with Generics 
        //            if (array[i].Equals(value))
        //                return i;
        //        }
        //    }
        //    return -1;
        //}

        #region Bubble Sort
        public static void BubbleSort(T[] arr) 
        {
            if (arr is not null)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    for (int j = 0; j < arr.Length - i -1; j++)
                    {
                        if (arr[j].CompareTo(arr[j + 1]))
                            Swap(ref arr[j], ref arr[j + 1]);
                    }
                }
            }
        }
        #endregion
    }
}
