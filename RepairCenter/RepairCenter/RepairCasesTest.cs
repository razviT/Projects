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
        public void AddTest()
        {
            var repairCasesOne = new RepairCases(new List<RepairCase> { });
            repairCasesOne.Add(tv);          
            CollectionAssert.AreEqual( new RepairCases(new List<RepairCase> { tv }).ToArray(), 
                repairCasesOne.ToArray());
        }

        [TestMethod]
        public void AddTestTwo()
        {
            var repairCasesTwo = new RepairCases(new List<RepairCase> { tv });
            repairCasesTwo.Add(iPhone);
            CollectionAssert.AreEqual(new RepairCases(new List<RepairCase> { tv, iPhone }).ToArray(), 
                repairCasesTwo.ToArray());
        }

        [TestMethod]
        public void AddTestThree()
        {
            var repairCasesThree = new RepairCases(new List<RepairCase> { tv, iPhone })
            {
                boombox
            };
            CollectionAssert.AreEqual(new RepairCases(new List<RepairCase> { tv, boombox, iPhone }).ToArray(),
                repairCasesThree.ToArray());
        }

        [TestMethod]
        public void AddTestFour ()
        {
            var repairCasesFour = new RepairCases(new List<RepairCase> { tv, boombox, iPhone })
            {
                { "another case", "high" }
            };
            CollectionAssert.AreEqual(new RepairCases(new List<RepairCase> { tv, boombox, phone, iPhone }).ToArray(), 
                repairCasesFour.ToArray());
        }

        [TestMethod]
        public void GetNextTest()
        {
            var repairCasesFive = new RepairCases(new List<RepairCase> { tv, boombox, iPhone });
            repairCasesFive.Add(phone);
            Assert.AreEqual(tv, repairCasesFive.GetNext());
        }

        [TestMethod]
        public void GetNextTestTwo()
        {
            var repairCasesSix = new RepairCases(new List<RepairCase> {boombox, iPhone });
            Assert.AreEqual(boombox, repairCasesSix.GetNext());
        }
    }
}
