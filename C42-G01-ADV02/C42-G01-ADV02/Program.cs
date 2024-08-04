using C42_G01_ADV02.Classes;
using System.Collections;

namespace C42_G01_ADV02
{
    internal class Program
    {
        static void Main()
        {
            #region Part 01
            /*
             => ArrayList:
                Structure: 
                           ArrayList can store elements of any data type because it stores elements as objects.
                           This flexibility comes at the cost of type safety, as you can insert mixed data types into the same ArrayList.
                           The capacity of an `ArrayList` automatically increases as needed by reallocating the internal array.
                Time Complexity: 
                           Access -> O(1)  Direct indexing is constant time.
                           Search -> O(n)  Linear search is needed for unsorted data.
                           Insertion -> O(1) For adding at the end (amortized), but O(n) for inserting or removing at arbitrary positions due to shifting elements.
                           Memory Overhead -> Due to boxing/unboxing when storing value types, and the lack of type safety, `ArrayList` has more overhead than List<T>.
                Business Cases:
                           Situations where type flexibility is more important than performance, such as dynamically typed collections where the type of data isn’t known beforehand.

            => List<T>
                Structure: 
                           is a generic collection, which it can only store elements of a specified type.It uses an internal array that dynamically resizes as elements are added.
                Time Complexity: 
                           Access -> O(1)  Direct indexing is constant time.
                           Search -> O(n)  Linear search is needed for unsorted data.
                           Insertion -> O(1) for adding at the end (amortized), but O(n) for inserting or removing at arbitrary positions due to shifting elements.
                           Memory Overhead -> Is more memory-efficient, especially with value types, as it avoids boxing/unboxing.
                Business Cases:
                           Where performance and type safety are crucial. it is ideal when the data type is known and consistent, such as managing a list of users, products.
            
            => linkedList<T>
                Structure: 
                           Consist of collection of nodes each node contains of two parts, first is a reference to the previous and the next node, second a value stored in
                           this node. The nodes are not sorted.
                Time Complexity: 
                           Access -> O(n) for accessing elements, as it requires traversal from the beginning.
                           Search -> O(n)  Linear search is required.
                           Insertion -> O(1) inserting or deleting elements at any position if the node reference is known, but O(n) for searching the position then inserting or deleting the unknown node.
                Business Cases:
                           Useful when frequent insertion elements is required without retrieving data.                           
            
            =>  Queue<T>
                Structure: 
                           Store elements  based on the First-In-First-Out (FIFO) principle. It uses an internal array to store elements, with pointers for the front and rear.
                Time Complexity: 
                           Enqueue -> O(1) for adding elements at the rear.
                           Dequeue -> O(1) for removing elements from the front.
                           Search -> O(n), doesn’t allow direct access to elements.
                Business Cases:
                           Useful where elements need to be processed in the order they arrive, like Managing customer support requests. 
            
            =>  Queue<T>
                Structure: 
                           Store elements based on the Last-In-First-Out (LIFO) principle. It uses an internal array to store elements.
                Time Complexity: 
                           Push -> O(1) for adding elements on top of the stack.
                           Pop -> O(1) for removing elements from the top.
                           Search -> O(n), doesn’t allow direct access to elements.
                Business Cases:
                           Useful where requiring reverse processing order,
             */
            #endregion

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
