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
            var repairCasesOne = new RepairCases(new List<RepairCase> { });
            repairCasesOne.Add(tv);          
            CollectionAssert.AreEqual( new RepairCases(new List<RepairCase> { tv }).ToArray(), repairCasesOne.ToArray());
        }

        [TestMethod]
        public void TestAddRepairCaseInOrderOfPriorityTwo()
        {
            var repairCasesTwo = new RepairCases(new List<RepairCase> { tv });
            repairCasesTwo.Add(iPhone);
            CollectionAssert.AreEqual(new RepairCases(new List<RepairCase> { tv, iPhone }).ToArray(), repairCasesTwo.ToArray());
        }

        [TestMethod]
        public void TestAddRepairCaseInOrderOfPriorityThree()
        {
            var repairCasesThree = new RepairCases(new List<RepairCase> { tv, iPhone });
            repairCasesThree.Add(boombox);          
            CollectionAssert.AreEqual(new RepairCases(new List<RepairCase> { tv, boombox, iPhone }).ToArray(), repairCasesThree.ToArray());
        }

        [TestMethod]
        public void TestAddRepairCaseInOrderOfPriorityFour ()
        {
            var repairCasesFour = new RepairCases(new List<RepairCase> { tv, boombox, iPhone });
            repairCasesFour.Add(phone);
            CollectionAssert.AreEqual(new RepairCases(new List<RepairCase> { tv, boombox, phone, iPhone }).ToArray(), repairCasesFour.ToArray());
        }

        [TestMethod]
        public void TestGetNextCase()
        {
            var repairCasesFive =new RepairCases(new List<RepairCase> { tv, boombox, iPhone });
            repairCasesFive.Add(phone);
            Assert.AreEqual(tv, repairCasesFive.GetNextCase());
        }

        [TestMethod]
        public void TestGetNextCaseTwo()
        {
            var repairCasesSix = new RepairCases(new List<RepairCase> {boombox, iPhone });
            Assert.AreEqual(boombox, repairCasesSix.GetNextCase());
        }
    }
}
