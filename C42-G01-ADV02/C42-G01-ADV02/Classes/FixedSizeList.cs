using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C42_G01_ADV02.Classes
{
    internal class FixedSizeList<T> 
    {
        private const int DefaultCapacity = 4;

        internal T[] _items; 
        internal int _size; 
        internal int _version; 


        private static readonly T[] s_emptyArray = new T[0];

        public FixedSizeList(int capacity)
        {
            if (capacity < 0)
                throw new System.ArgumentOutOfRangeException();

            if (capacity == 0)
                _items = s_emptyArray;
            else
                _items = new T[capacity];
        }

        public void Add(T item)
        {
            _version++;
            T[] array = _items;
            int size = _size;
            if ((uint)size < (uint)array.Length)
            {
                _size = size + 1;
                array[size] = item;
            }
            else
            {
                throw new ArgumentOutOfRangeException("The List Is Full Capacity");
            }
        }        
        
        public T GetElementByIndex(int index)
        {
            if(index > _size - 1 || index < 0)
                throw new ArgumentOutOfRangeException("Invalid Index");
            return _items[index];
        }
    }
}
