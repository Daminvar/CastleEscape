using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CastleEscape.CustomStructs
{
    class DennisArray<T>
    {
        private const int DEFAULT_CAPACITY = 10;
        
        private T[] data;
        private int currentCount = 0;

        public DennisArray()
        {
            data = new T[DEFAULT_CAPACITY];
        }

        public DennisArray(int initialCapacity)
        {
            data = new T[initialCapacity];
        }

        public void Add(T item)
        {
            if (currentCount == data.Length)
                resizeArray();
            currentCount++;
            data[currentCount - 1] = item;
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= currentCount)
                throw new Exception(string.Format("Index {0} is out of bounds.", index));

            var newArray = new T[data.Length - 1];
            for (int i = 0; i < index; i++)
                newArray[i] = data[i];
            for (int i = index + 1; i < newArray.Length; i++)
                newArray[i - 1] = data[i];
            data = newArray;
            currentCount--;
        }

        private void resizeArray()
        {
            var newArray = new T[data.Length * 2];
            for (int i = 0; i < data.Length; i++)
                newArray[i] = data[i];
            data = newArray;
        }

        public int Count
        {
            get { return currentCount; }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= currentCount)
                    throw new Exception(string.Format("Index {0} is out of bounds.", index));
                else
                    return data[index];
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append("[");
            for (int i = 0; i < currentCount; i++)
            {
                string formatString;
                if (i < currentCount - 1)
                    formatString = " {0},";
                else
                    formatString = " {0}]";
                builder.Append(string.Format(formatString, data[i])); 
            }
            return builder.ToString();
        }
    }
}
