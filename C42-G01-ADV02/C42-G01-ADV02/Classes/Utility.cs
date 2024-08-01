using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C42_G01_ADV02.Classes
{
    internal static class Utility
    {
        public static void ReverseArrayList(ArrayList arrayList) 
        {
            if (arrayList is not null)
                for (int i = 0; i < arrayList.Count - 1; i++)
                    for (int j = 0; j < arrayList.Count - i - 1; j++)
                    {
                        object temp = arrayList[j] ?? 0;
                        arrayList[j] = arrayList[j + 1];
                        arrayList[j + 1] = temp;
                    }
        }

        public static List<int> ListWithEvenNumbersOnly(List<int> values) 
        {
            List<int> ListWithEvenNumber = new List<int>(values.Capacity);
            for (int i = 0; i <= values.Count - 1; i++)
                if (values[i] % 2 == 0)
                    ListWithEvenNumber.Add(values[i]);
            ListWithEvenNumber.TrimExcess();
            return ListWithEvenNumber;
        }
    }
}
