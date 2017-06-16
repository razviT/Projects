using System;
using System.Linq;
using Xunit;

namespace IListImplementation
{
    public class MyListTest
    {
        [Fact]
        public void AddTest()
        {
            MyList<string> myList = new MyList<string>
            {
                "banane"
            };
            Assert.Equal(new string[] { "banane" }, myList);
        }

        [Fact]
        public void AddTestTwo()
        {
            MyList<string> myList = new MyList<string> { "1", "2", "3", "4", "5", "6", "7", "8" };
            myList.Add("9");
            Assert.Equal(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" },
                myList);
        }

        [Fact]
        public void InsertTest()
        {
            MyList<string> myList = new MyList<string> { "1", "2", "3", "4", "5", "6", "7", "8" };
            myList.Insert(3, "12");
            Assert.Equal(new string[] { "1", "2", "3","12","4", "5", "6", "7", "8" },
                myList);
        }

        [Fact]
        public void CointainsTest()
        {
            MyList<string> myList = new MyList<string> { "1", "2", "3", "4", "5", "6", "7", "8" };
            Assert.Equal(true, myList.Contains("3"));
        }

        [Fact]
        public void CointainsTestTwo()
        {
            MyList<string> myList = new MyList<string> { "1", "2", "3", "4", "5", "6", "7", "8" };
            Assert.Equal(false, myList.Contains("9"));
        }

        [Fact]
        public void IndexOfTest()
        {
            MyList<string> myList = new MyList<string> { "1", "2", "3", "4", "5", "6", "7", "8" };
            Assert.Equal(3, myList.IndexOf("4"));
        }

        [Fact]
        public void IndexOfTestTwo()
        {
            MyList<string> myList = new MyList<string> { "1", "2", "3", "4", "5", "6", "7", "8" };
            Assert.Equal(-1, myList.IndexOf("10"));
        }

        [Fact]
        public void RemoveAtTest()
        {
            MyList<string> myList = new MyList<string> { "1", "2", "3", "4", "5", "6", "7", "8" };
            myList.RemoveAt(5);
            Assert.Equal(new string[] { "1", "2", "3", "4", "5", "7", "8" }, myList);
        }

        [Fact]
        public void RemoveTest()
        {
            MyList<string> myList = new MyList<string> { "1", "2", "3", "4", "5", "6", "7", "8" };
            myList.Remove("4");
            Assert.Equal(new string[] { "1", "2", "3", "5", "6", "7", "8" }, myList);
        }
       
        [Fact]
        public void ClearTest()
        {
            MyList<string> myList = new MyList<string> { "1", "2", "3", "4", "5", "6", "7", "8" };
            myList.Clear();
            Assert.Equal(new string[0], myList);
        }

        [Fact]
        public void CopyToTest()
        {
            MyList<int> myList = new MyList<int> { 1, 2, 3, 4, 5 };           
            var array = new int[8];
            myList.CopyTo(array,2);
            Assert.Equal(new int[] { 0, 0, 1, 2, 3, 4, 5, 0 }, array);
        }

        [Fact]
        public void TestInsertArgumentOutOfRangeException()
        {
            MyList<string> myList = new MyList<string> { "1", "2", "3", "4", "5", "6", "7", "8" };           
            var exception = Record.Exception(() => myList.Insert(9, "12"));
            Assert.IsType(typeof(System.ArgumentOutOfRangeException), exception);              
        }

        [Fact]
        public void TestCopyToArgumentNullException()
        {
            MyList<int> myList = new MyList<int> { 1, 2, 3, 4, 5 };
            int[]array =new int[] { };
            array = null;        
            var exception = Record.Exception(() => myList.CopyTo(array, 2));
            Assert.IsType(typeof(System.ArgumentNullException),exception);
        }

        [Fact]
        public void TestCopyToArgumentException()
        {
            MyList<int> myList = new MyList<int> { 1, 2, 3, 4, 5 };
            int[] array = new int[4];
            Assert.Throws<ArgumentException>(() => myList.CopyTo(array, 2));
        }

        [Fact]
        public void TestCopyToArgumentOutOfRangeException()
        {
            MyList<int> myList = new MyList<int> { 1, 2, 3, 4, 5 };
            int[] array = new int[4];
            var exception = Record.Exception(() => myList.CopyTo(array, -1));
            Assert.IsType(typeof(System.ArgumentOutOfRangeException), exception);
        }

        [Fact]
        public void RemoveAtIndexOutOfRangeException()
        {
            MyList<string> myList = new MyList<string> { "1", "2", "3", "4", "5", "6", "7", "8" };
            var exception = Record.Exception(() => myList.RemoveAt(10));
            Assert.IsType(typeof(System.ArgumentOutOfRangeException), exception);
        }
    }
}
