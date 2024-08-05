using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C42_G01_ADV03
{
    internal class BookFunctions
    {
        public static string GetTitle(Book B) => B.Title;
        public static string GetPrice(Book B) => B.Price.ToString();
        public static string GetAuthors(Book B) 
        {
            string AuthorsString = string.Empty;
            for (int i = 0; i < B.Authors.Length; i++)
                AuthorsString += $"{B.Authors[i]} ";
            return AuthorsString;
        }

    }
}
