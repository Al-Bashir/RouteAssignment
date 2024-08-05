using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C42_G01_ADV03
{
    internal class LibraryEngine
    {
        public static void ProcessBooks <T>(List<Book> bList,Func<Book, T> fPtr) 
        {
            foreach (Book B in bList)
            {
                Console.WriteLine(fPtr.Invoke(B));
            }
        }
    }
}
