using System.Diagnostics;

namespace C42_G01_ADV03
{
    internal class Program
    {
        static void Main()
        {
            #region Part-01 a)
            Book[] books = { new Book("1", "A", ["A1", "B1", "C1"], DateTime.Now, 10),
                             new Book("2", "B", ["A2", "B2", "C2"], DateTime.Now, 20),
                             new Book("3", "C", ["A3", "B3", "C3"], DateTime.Now, 30),
                             new Book("4", "D", ["A4", "B4", "C4"], DateTime.Now, 20)};
            List<Book> bookList = new List<Book>(books);
            LibraryEngine.ProcessBooks(bookList, BookFunctions.GetTitle); 
            LibraryEngine.ProcessBooks(bookList, BookFunctions.GetAuthors);
            LibraryEngine.ProcessBooks(bookList, BookFunctions.GetPrice);
            #endregion

            #region Part-01 b), c)
            Func<Book, string> GetISBN = delegate (Book book)
            {
                return book.ISBN;
            };
            LibraryEngine.ProcessBooks(bookList, GetISBN);
            #endregion

            #region Part-01 b), c)
            Func<Book, DateTime> GetPublicationDate = b => b.PublicationDate;
            LibraryEngine.ProcessBooks(bookList, GetPublicationDate);
            #endregion

            #region Part-02
            //Exist
            Predicate<Book> ExistPredicate = b => b.Price == 10;
            Console.WriteLine($"Exist: {bookList.Exists(ExistPredicate)}");

            //Find
            Predicate<Book> FindPredicate = b => b.Title == "B";
            Console.WriteLine($"Find: {bookList.Find(FindPredicate)}");
            
            //Find All
            Predicate<Book> FindAllPredicate = b => b.Price == 20;
            List<Book> FindAllList = bookList.FindAll(FindAllPredicate);
            foreach (Book book in FindAllList)
                Console.WriteLine($"Find All: {book}");   
            
            //Find Index
            Predicate<Book> FindIndexPredicate01 = b => b.ISBN == "4";
            Console.WriteLine($"Find Index: {bookList.FindIndex(FindIndexPredicate01)}");       
            
            Predicate<Book> FindIndexPredicate02 = b => b.ISBN == "1";
            Console.WriteLine($"Find Index: {bookList.FindIndex(2, FindIndexPredicate02)}");

            Predicate<Book> FindIndexPredicate03 = b => b.Price == 20;
            Console.WriteLine($"Find Index: {bookList.FindIndex(1, 3,FindIndexPredicate03)}");

            //Find Last
            Predicate<Book> FindLastPredicate = b => b.Price == 20;
            Console.WriteLine($"Find Last: {bookList.FindLast(FindLastPredicate)}");
            
            //Find Last Index
            Predicate<Book> FindLastIndexPredicate01 = b => b.Price == 20;
            Console.WriteLine($"Find Last Index: {bookList.FindLastIndex(FindLastIndexPredicate01)}");

            Predicate<Book> FindLastIndexPredicate02 = b => b.Price == 30;
            Console.WriteLine($"Find Last Index: {bookList.FindLastIndex(1,FindLastIndexPredicate02)}");

            Predicate<Book> FindLastIndexPredicate03 = b => b.Price == 10;
            Console.WriteLine($"Find Last Index: {bookList.FindLastIndex(3, 1, FindLastIndexPredicate03)}");

            //Foreach
            Action<Book> ForeachAction = x => Console.WriteLine($"Book[{x.ISBN}] Title: {x.Title}");
            bookList.ForEach(ForeachAction);

            //TrueForAll
            Predicate<Book> TrueForAllPredicate = b => b.PublicationDate.Day == DateTime.Now.Day;
            Console.WriteLine($"True For All: {bookList.TrueForAll(TrueForAllPredicate)}");
            #endregion
        }
    }
}
