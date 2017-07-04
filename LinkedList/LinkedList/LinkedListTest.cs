using Xunit;
using System;
using System.Linq;
using System.Collections.Generic;

namespace CircularDoublyLinkedList
{
    public class LinkedListTest
    {
        [Fact]
        public void AddTest()
        {
            var list = new MyLinkedList<int> { 10 };
            Assert.Equal(new int[] { 10 }, list);
        }

        [Fact]
        public void AddFirstTest()
        {
            var list = new MyLinkedList<int> { 10, 12, 16, 12 };
            list.Add(13);
            list.AddFirst(6);
            Assert.Equal(new int[] { 6, 10, 12, 16, 12, 13 }, list);
        }

        [Fact]
        public void MultipleAddsTest()
        {
            var list = new MyLinkedList<int> { 10, 12, 16 };
            Assert.Equal(new int[] { 10, 12, 16 }, list);
        }

        [Fact]
        public void GetAtTest()
        {
            var list = new MyLinkedList<int> { 10, 12, 16 };
            Assert.Equal(12, list.GetAt(1).Data);
        }

        [Fact]
        public void InsertAfterTest()
        {
            var list = new MyLinkedList<int> { 10, 12, 16 };
            list.InsertAfter(list.GetAt(1), 13);
            Assert.Equal(new int[] { 10, 12, 13, 16 }, list);
        }

        [Fact]
        public void InsertBeforeTest()
        {
            var list = new MyLinkedList<int> { 10, 12, 16 };
            list.InsertBefore(list.GetAt(1), 13);
            Assert.Equal(new int[] { 10, 13, 12, 16 }, list);
        }

        [Fact]
        public void RemoveTest()
        {
            var list = new MyLinkedList<int> { 10, 12, 16, 18 };
            list.Remove(list.GetAt(2));
            Assert.Equal(new int[] { 10, 12, 18 }, list);
        }

        [Fact]
        public void RemoveFirst()
        {
            var list = new MyLinkedList<int> { 10, 12, 16, 18 };
            list.RemoveFirst();
            Assert.Equal(new int[] { 12, 16, 18 }, list);
        }

        [Fact]
        public void RemoveLast()
        {
            var list = new MyLinkedList<int> { 10, 12, 16, 18 };
            list.RemoveLast();
            Assert.Equal(new int[] { 10, 12, 16 }, list);
        }

        [Fact]
        public void RemoveFirstValue()
        {
            var list = new MyLinkedList<int> { 10, 12, 16, 12 };           
            Assert.Equal(true, list.RemoveFirst(12));
        }

        [Fact]
        public void FindFirstTest()
        {
            var list = new MyLinkedList<int> { 10, 12, 16, 12};
            Assert.Equal(list.GetAt(1),list.Find(12));
        } 
        
        [Fact]
        public void FindLastTest()
        {
            var list = new MyLinkedList<int> { 10, 12, 16, 12 };
            Assert.Equal(list.GetAt(3), list.FindLast(12));
        }

        [Fact]
        public void ContainsTest()
        {
            var list = new MyLinkedList<int> { 10, 12, 13, 6, 3, 20 };
            Assert.Equal(true, list.Contains(13));
        }

        [Fact]
        public void ContainsTestTwo()
        {
            var list = new MyLinkedList<int> { 10, 12, 13, 6, 3, 20 };
            Assert.Equal(false, list.Contains(7));
        }

        [Fact]
        public void CopyToTest()
        {
            var list = new MyLinkedList<int> { 10, 12, 13, 6, 3, 20 };
            var array = new int[10];
            Assert.Equal(new int[] { 0, 0, 10, 12, 13, 6, 3, 20, 0, 0 }, list.CopyTo(array, 2));
        }

        [Fact]
        public void ClearTest()
        {
            var list = new MyLinkedList<int> { 10, 12, 13, 6, 3, 20 };
            list.Clear();
            Assert.Equal(new int[] { }, list);
        }

        [Fact]
        public void InsertAfterInvalidOperationExceptionTest()
        {
            var list = new MyLinkedList<int> {1,2,3,4};
            Assert.Throws<InvalidOperationException>(() => list.InsertAfter(new NodeId<int>(10), 10));
        }

        [Fact]
        public void InsertBeforeInvalidOperationExceptionTest()
        {
            var list = new MyLinkedList<int> { 1, 2, 3, 4 };
            Assert.Throws<InvalidOperationException>(() => list.InsertBefore(new NodeId<int>(10), 10));
        }

        [Fact]
        public void CopyToArgumentNullExceptionTest()
        {
            var list = new MyLinkedList<int> { 1, 2, 3, 4 };
            int[] array = null;
            Assert.Throws<ArgumentNullException>(() => list.CopyTo(array, 2));
        }

        [Fact]
        public void CopyToArgumentOutOfRangeExceptionTest()
        {
            var list = new MyLinkedList<int> { 1, 2, 3, 4 };
            Assert.Throws<ArgumentOutOfRangeException>(() => list.CopyTo(new int[9], -1));
        }

        [Fact]
        public void CopyToArgumentExceptionTest()
        {
            var list=new MyLinkedList<int> { 1, 2, 3, 4 };
            Assert.Throws<ArgumentException>(() => list.CopyTo(new int[5], 3));
        }

        [Fact]
        public void RemoveInvalidOperationExceptionTest()
        {
            var list=new MyLinkedList<int> { 1, 2, 3, 4 };
            var anotherList = new MyLinkedList<int> { 3, 2, 1, 5 };
            Assert.Throws<InvalidOperationException>(() => list.Remove(anotherList.GetAt(0)));
        }

        [Fact]
        public void RemoveFirstInvalidOperationExceptionTest()
        {
            var list = new MyLinkedList<int> { };
            Assert.Throws<InvalidOperationException>(() => list.RemoveFirst());
        }

        [Fact]
        public void RemoveLastInvalidOperationExceptionTest()
        {
            var list = new MyLinkedList<int> { };
            Assert.Throws<InvalidOperationException>(() => list.RemoveLast());
        }
    }
}
