using System;
using System.Collections.Generic;
using System.Collections;

// doubly linked list circular si sa schimb la teste cu assert.throw<>

namespace IListImplementation
{
    public class MyList<T> : IList<T>
    {
        private T[] myList = new T[8];
        private int count;

        public MyList()
        {
            count = 0;
        }

        public T this[int index]
        {
            get
            {   
                return myList[index];
            }
            set
            {
                myList[index] = value;
            }
        }

        public int Count
        {
            get
            {
                return count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public void Add(T item)
        {
            if (myList.IsReadOnly)
            {
                throw new NotSupportedException();
            }

            EnsureCapacity();
            myList[count++] = item;
        }

        public void Clear()
        {
            if (myList.IsReadOnly)
            {
                throw new NotSupportedException();
            }

            count = 0;
        }

        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }
            if (arrayIndex < 0)
            {
                  throw new ArgumentOutOfRangeException();
            }
            if (count > array.Length - arrayIndex)
            {
                  throw new ArgumentException();
            }

            for (int i = 0; i < Count; i++)
            {
                array[arrayIndex++] = myList[i];
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return myList[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (myList[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            if (myList.IsReadOnly)
            {
                throw new NotSupportedException();
            }           
            if (index < 0 || index >= count)
            {
                throw new ArgumentOutOfRangeException();
            }  
            
            EnsureCapacity();
            for (int i = Count; i > index; i--)
            {
                myList[i] = myList[i - 1];
            }
            count++;
            myList[index] = item;
        }

        private void EnsureCapacity()
        {
            if (count == myList.Length -1)
            {
                Array.Resize(ref myList, myList.Length * 2);
            }
        }

        public bool Remove(T item)
        {
            if (myList.IsReadOnly)
            {
                throw new NotSupportedException();
            }  
            
            int countBeforeRemoving = count;
            RemoveAt(IndexOf(item));
            return (countBeforeRemoving != count);
        }

        public void RemoveAt(int index)
        {
            if (myList.IsReadOnly)
            {
                throw new NotSupportedException();
            }              
            if (index < 0 || index >= count)
            {
                throw new ArgumentOutOfRangeException();
            }
            
            for (int i = index; i < Count - 1; i++)
            {
                myList[i] = myList[i + 1];
            }
            count--;
        }       
    }
}
