using System.Collections;

namespace C42_G01_ADV02_Demon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayList array = new ArrayList();

            Console.WriteLine($"Count: {array.Count}");
            Console.WriteLine($"Capacity: {array.Capacity}");
            array.Add(1);
            Console.WriteLine($"Count: {array.Count}");
            Console.WriteLine($"Capacity: {array.Capacity}");

            array.AddRange(new int[] { 2, 3, 4 });
            Console.WriteLine($"Count: {array.Count}");

            Console.WriteLine($"Capacity: {array.Capacity}");

            array.Add(5);
            Console.WriteLine($"Count: {array.Count}");
            Console.WriteLine($"Capacity: {array.Capacity}");

            array.AddRange(new int[] { 6, 7, 8, 9 });
            Console.WriteLine($"Count: {array.Count}");
            Console.WriteLine($"Capacity: {array.Capacity}");

            Console.WriteLine(array[5]);

            ArrayList array2 = new ArrayList(5) { 1, 2, 3, 4, 5 };

            array2.Add(6);
            Console.WriteLine($"Count:2 {array2.Count}");
            Console.WriteLine($"Capacity2: {array2.Capacity}");
            //TrimTosize => deallocate unused bytes
            array2.TrimToSize();

            Console.WriteLine("============ After Trim ===========");
            Console.WriteLine($"Count:2 {array2.Count}");
            Console.WriteLine($"Capacity2: {array2.Capacity}");

            List<int> listNum = new List<int>();

            Console.WriteLine("============ List ===========");
            Console.WriteLine($"List Count: {listNum.Count}");
            Console.WriteLine($"List Capacity: {listNum.Capacity}");

            listNum.AddRange(new int[] { 5, 6, 7, 8, 9 });
            Console.WriteLine($"List Count: {listNum.Count}");
            Console.WriteLine($"List Capacity: {listNum.Capacity}");

            //listNum[6] = 10; invalid using of indexer to set non initialized index
            listNum.Add(10);
            Console.WriteLine($"List Count: {listNum.Count}");
            Console.WriteLine($"List Capacity: {listNum.Capacity}");

            listNum.TrimExcess();
            Console.WriteLine($"List Count: {listNum.Count}");
            Console.WriteLine($"List Capacity: {listNum.Capacity}");


            #region List Methods 
            List<int> listNum02 = new List<int>(5) {1,2,3,4 };
            Console.WriteLine($"List Count: {listNum02.Count}");
            Console.WriteLine($"List Capacity: {listNum02.Capacity}");

            listNum02.Add(5);
            Console.WriteLine($"List Count: {listNum02.Count}");
            Console.WriteLine($"List Capacity: {listNum02.Capacity}");

            listNum02.AddRange(new int[] {6,7 });
            Console.WriteLine($"List Count: {listNum02.Count}");
            Console.WriteLine($"List Capacity: {listNum02.Capacity}");

            listNum02.Insert(0,1000);
            Console.WriteLine($"List Count: {listNum02.Count}");
            Console.WriteLine($"List Capacity: {listNum02.Capacity}");
            Console.WriteLine(listNum02.BinarySearch(1000));

            foreach (int item in listNum02)
                Console.Write($"{item} ");
            Console.WriteLine();

            listNum02.InsertRange(0, new int[] { 1001, 1002, 1003, 1004 });
            
            foreach (int item in listNum02)
                Console.Write($"{item} ");
            Console.WriteLine();


            Console.WriteLine(listNum02.BinarySearch(1002));
            //binary search

            listNum02.Clear();
            Console.WriteLine($"List Count: {listNum02.Count}");
            Console.WriteLine($"List Capacity: {listNum02.Capacity}");
            foreach (int item in listNum02)
                Console.Write($"{item} ");
            Console.WriteLine();

            List<int> listNum03 = new List<int>(5) { 1, 2, 3, 4 };
            int[] arrNum03 = new int[4];

            listNum03.CopyTo(arrNum03);

            //Ensure Capacity 
            Console.WriteLine($"List Count: {listNum03.Count}");
            Console.WriteLine($"List Capacity: {listNum03.Capacity}");   
            
            listNum03.EnsureCapacity(7);
            Console.WriteLine($"List Count: {listNum03.Count}");
            Console.WriteLine($"List Capacity: {listNum03.Capacity}");            
            
            listNum03.EnsureCapacity(21);
            Console.WriteLine($"List Count: {listNum03.Count}");
            Console.WriteLine($"List Capacity: {listNum03.Capacity}");

            Console.WriteLine(listNum02.LastIndexOf(1003));

            #endregion

            #region LinkedList, Stack, Queue
            Console.WriteLine("============ LinkedList ===========");
            LinkedList<int> linkedList = new LinkedList<int>();
            Console.WriteLine($"LinkedList Count: {linkedList.Count}");
            linkedList.AddFirst(1);
            linkedList.AddFirst(2);
            linkedList.AddLast(3);

            Console.WriteLine($"LinkedList Count: {linkedList.Count}");
            foreach (int item in linkedList)
                Console.Write($"{item} ");
            Console.WriteLine();        
            
            linkedList.AddAfter(linkedList.Find(1), 2);
            foreach (int item in linkedList)
                Console.Write($"{item} ");
            Console.WriteLine();

            Console.WriteLine(linkedList.Find(1).ValueRef);
            #endregion

            #region Stack
            //Stack non generic => based on object
            //Generic Stack => Recommended 
            //Last in - First out
            Stack<int> ints = new Stack<int>();
            Console.WriteLine($"Stack Count: {ints.Count}");

            ints.Push(1);
            ints.Push(2);
            ints.Push(3);
            //Console.WriteLine($"Stack Capacity: {ints}");
            foreach (int item in ints)
                Console.Write($"{item} ");
            Console.WriteLine();
            Console.WriteLine(ints.Peek());
            Console.WriteLine(ints.Pop()); //return element then remove it
            Console.WriteLine(ints.Peek());

            ints.TryPop(out int element);
            ints.TryPop(out element);
            ints.TryPop(out element);
            foreach (int item in ints)
                Console.Write($"{item} ");
            Console.WriteLine();

            #endregion

            #region Queue
            //Queue non generic => based on object
            //Generic Queue => Recommended 
            //Last in - Last out
            
            Console.WriteLine("===========Queue========");
            Queue<int> Q = new Queue<int>();
            Q.Enqueue(1);
            Q.Enqueue(2);
            Q.Enqueue(3);

            Console.WriteLine(Q.Peek());

            Console.WriteLine(Q.Dequeue());

            Console.WriteLine(Q.Peek());

            Console.WriteLine(Q.TryDequeue(out element));
            Console.WriteLine(Q.TryDequeue(out element));
            Console.WriteLine(Q.TryDequeue(out element));
            Console.WriteLine(Q.TryDequeue(out element));
            Console.WriteLine(Q.TryDequeue(out element));
            #endregion

            SortedList sortedList = new SortedList();
            sortedList.Add(1, 2);
            sortedList.Add(20, 3);
            Console.WriteLine($"SortedList count: {sortedList.Count}");
            Console.WriteLine($"SortedList Capacity: {sortedList.Capacity}");
            Console.WriteLine($"SortedList: {sortedList[20]}");
        }
    }
}
