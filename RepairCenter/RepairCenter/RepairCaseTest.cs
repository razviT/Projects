using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RepairCenter
{
    [TestClass]
    public class RepairCaseTest
    {
        [TestMethod]
        public void GetPriorityInIntTest()
        {
            Assert.AreEqual(new RepairCase("ItemOne", "Low").GetPriorityInInt(), 1);
        }

        [TestMethod]
        public void GetPriorityInIntTestTwo()
        {
            Assert.AreEqual(new RepairCase("ItemTwo", "High").GetPriorityInInt(), 3);
        }

        [TestMethod]
        public void GetPriorityInIntTestThree()
        {
            Assert.AreEqual(new RepairCase("Item Three", "Medium").GetPriorityInInt(), 2);
        }

        [TestMethod]
        public void GetPriorityInIntTestFour()
        {
            Assert.AreEqual(new RepairCase("item four", "no priority").GetPriorityInInt(), 0);
        }      
    }
}
