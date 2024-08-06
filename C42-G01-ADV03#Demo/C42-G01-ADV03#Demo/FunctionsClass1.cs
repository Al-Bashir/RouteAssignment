using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C42_G01_ADV03_Demo
{
    internal class FunctionsClass1
    {
        public static int GEtCountOfUpperChars(string Name)
        { 
            int count = 0;
            if (Name is not null)
            {
                for (int i = 0; i < Name.Length; i++)
                {
                    if (Char.IsUpper(Name[i]))
                        count++;
                } 

            }
            return count;
        }
    }
}
