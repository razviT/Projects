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
    }
}
