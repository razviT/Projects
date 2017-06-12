using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        public void SortCasesAccordingToPriorityTest()
        {
            var testCases = new RepairCases(new RepairCase[] { phone, tv, iPhone, boombox });
            CollectionAssert.AreEqual(testCases.SortCasesAccordingToPriority(),
                new RepairCase[] { tv, phone, boombox, iPhone });
        }

        [TestMethod]
        public void SortCasesAccordingToPriorityTestTwo()
        {
            var testCases = new RepairCases(new RepairCase[] { iPhone, boombox, phone, tv });
            CollectionAssert.AreEqual(testCases.SortCasesAccordingToPriority(),
                new RepairCase[] { tv, boombox, phone, iPhone });
        }

        [TestMethod]
        public void GetWantedCaseTest()
        {
            var testCases = new RepairCases(new RepairCase[] { iPhone, boombox, phone, tv });
            Assert.AreEqual(testCases.GetWantedCase(2), boombox);
        }

        [TestMethod]
        public void GetWantedCaseTestTwo()
        {
            var testCases = new RepairCases(new RepairCase[] { iPhone, boombox, phone, tv });
            Assert.AreEqual(testCases.GetWantedCase(4), tv);
        }
    }
}
