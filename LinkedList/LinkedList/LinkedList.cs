using System;
using System.Collections;
using System.Collections.Generic;
namespace CircularDoublyLinkedList
{

    public class NodeId<T> : Node<T>
    {

        public bool Removed { get; set; }
        public Guid Id { get; set; }
        public NodeId(T data) : base(data)
        {
            Removed = false;
        }
        
    }

    public class MyLinkedList<T> : Node<T>, IEnumerable<T>
    {
        private NodeId<T> root = null;
        protected Guid listId=Guid.NewGuid();
        private static T data;      
        public MyLinkedList() : base(data)
        {   
            root = new NodeId<T>(default(T));
            Clear();
        }
        public void Add(T data)
        {
            InsertBefore(root, data);
        }

        public void AddFirst(T data)
        {
            InsertAfter(root, data);
        }

        public NodeId<T> GetAt(int index)
        {
            var node = root.Next;
            for (int i = 0; i < index; i++)
            {
                node = node.Next;
            }
            return node;
        }
        public void InsertAfter(NodeId<T> node, T data)
        {
            if (node.Removed == true || node.Id != listId)
                throw new InvalidOperationException();

            var nodeAdded = new NodeId<T>(data)
            {
                Next = node.Next,
                Previous = node
            };
            node.Next.Previous = nodeAdded;
            node.Next = nodeAdded;         
            nodeAdded.Id = listId;
        }

        public void InsertBefore(NodeId<T> node, T data)
        {
            if (node.Removed == true || node.Id != listId)
                throw new InvalidOperationException();

            InsertAfter(node.Previous, data);
        }

        public void Remove(NodeId<T> nodeToRemove)
        {
            if (nodeToRemove.Removed == true || nodeToRemove.Id != listId)
                throw new InvalidOperationException();

            nodeToRemove.Removed = true;
            nodeToRemove.Previous.Next = nodeToRemove.Next;
            nodeToRemove.Next.Previous = nodeToRemove.Previous;
        }

        public void RemoveFirst()
        {
            if (root.Previous == root)
                throw new InvalidOperationException();

            root.Next.Removed = true;
            root.Next.Next.Previous = root;
            root.Next = root.Next.Next;
        }

        public void RemoveLast()
        {
            if (root.Previous == root)
                throw new InvalidOperationException();

            root.Previous.Removed = true;
            root.Previous.Previous.Next = root;
            root.Previous = root.Previous.Previous;
        }

        public bool RemoveFirst(T data)
        {
            var node = Find(data);
            if (node != null)
            {
                Remove(node);
                return true;
            }
            return false;
        }

        public bool RemoveLast(T data)
        {
            var node = FindLast(data);
            if (node != null)
            {
                Remove(node);
                return true;
            }
            return false;
        }

        public NodeId<T> Find(T data)
        {
            for (var node = root.Next; node != root; node = node.Next)
            {
                if (node.Data.Equals(data))
                    return node;
            }
            return null;
        }

        public NodeId<T> FindLast(T data)
        {
            for (var node = root.Previous; node != root; node = node.Previous)
            {
                if (node.Data.Equals(data))
                    return node;
            }
            return null;
        }

        public bool Contains(T data)
        {
            return Find(data) != null;
        }

        public T[] CopyTo(T[] array, int index)
        {
            if (array == null)
                throw new ArgumentNullException();
            if (index < 0)
                throw new ArgumentOutOfRangeException();
            if (Count() > array.Length - index - 1)
                throw new ArgumentException();

            for (var node = root.Next; node != root; node = node.Next)
            {
                array[index++] = node.Data;
            }
            return array;
        }

        public int Count()
        {
            int count = 0;
            for (var node = root.Next; node != root; node = node.Next)
            {
                count++;
            }
            return count;
        }

        public void Clear()
        {
            root.Id = listId;
            root.Next = root;
            root.Previous = root;        
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var current = root.Next; current != root; current = current.Next)
                yield return current.Data;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public class Node<T>
    {
        
        public T Data { get; set; }
        public Node(T data)
        {           
            Data = data;                     
        }
        public NodeId<T> Next { get; set; }
        public NodeId<T> Previous { get; set; }
        protected void Method1()
        {
            
        }
    }
}
