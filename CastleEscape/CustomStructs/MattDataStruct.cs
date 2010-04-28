using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace CastleEscape.CustomStructs
{
    class MattDataStruct<T, M>
    {
        private M[] data;
        private const int size = 500000;
    
        public MattDataStruct()
        {
            //data's length
            data = new M[size];
        }
        //method to add to the arraylist
        public void add(T key, M value)
        {
            //Gets the key as hash code
            int hashcode = Math.Abs(key.GetHashCode());
            int index = hashcode % size;
            data[index] = value;
        }

        public M this[T key]
        {
            get
            {
                int hashcode = Math.Abs(key.GetHashCode());
                int index = hashcode % size;
                return data[index]; 
            }

            set
            {
                int hashcode = Math.Abs(key.GetHashCode());
                int index = hashcode % size;
                data[index] = value;
            }

        }

    }
}
