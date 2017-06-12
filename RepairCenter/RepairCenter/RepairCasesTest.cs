using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace RepairCenter
{
    [TestClass]
    public class RepairCasesTest
    {
        private static readonly RepairCase phone = new RepairCase("phone", "Medium");
        private static readonly RepairCase tv = new RepairCase("tv", "High");
        private static readonly RepairCase iPhone = new RepairCase("iphone", "Low");
        private static readonly RepairCase boombox = new RepairCase("Boombox", "Medium");

        [TestMethod]
        public void TestAddRepairCaseInOrderOfPriority()
        {
            CollectionAssert.AreEqual(new RepairCases(new List<RepairCase> { })
                .AddRepairCaseInOrderOfPriority(tv), new RepairCase[] { tv });
        }

        [TestMethod]
        public void TestAddRepairCaseInOrderOfPriorityTwo()
        {
            CollectionAssert.AreEqual(new RepairCases(new List<RepairCase> { tv })
                .AddRepairCaseInOrderOfPriority(iPhone), new RepairCase[] { tv, iPhone });
        }

        [TestMethod]
        public void TestAddRepairCaseInOrderOfPriorityThree()
        {
            CollectionAssert.AreEqual(new RepairCases(new List<RepairCase> { tv, iPhone })
                .AddRepairCaseInOrderOfPriority(boombox), new RepairCase[] { tv, boombox, iPhone });
        }

        [TestMethod]
        public void TestAddRepairCaseInOrderOfPriorityFour ()
        {
            CollectionAssert.AreEqual(new RepairCases(new List<RepairCase> { tv, boombox, iPhone })
                .AddRepairCaseInOrderOfPriority(phone), new RepairCase[] { tv, boombox, phone, iPhone });
        }   
    }
}
