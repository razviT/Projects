using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RepairCenter
{
    [TestClass]
    public class RepairCaseTest
    {
        [TestMethod]
        public void ConvertPriorityToIntegerTest()
        {
            Assert.AreEqual(new RepairCase("ItemOne", "Low").ConvertPriorityToInteger(), 1);
        }

        [TestMethod]
        public void ConvertPriorityToIntegerTestTwo()
        {
            Assert.AreEqual(new RepairCase("ItemTwo", "High").ConvertPriorityToInteger(), 3);
        }

        [TestMethod]
        public void ConvertPriorityToIntegerTestThree()
        {
            Assert.AreEqual(new RepairCase("Item Three", "Medium").ConvertPriorityToInteger(), 2);
        }

        [TestMethod]
        public void ConvertPriorityToIntegerTestFour()
        {
            Assert.AreEqual(new RepairCase("item four", "no priority").ConvertPriorityToInteger(), 0);
        }      
    }
}
