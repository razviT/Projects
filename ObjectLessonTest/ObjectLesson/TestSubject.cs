using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ObjectLesson
{
    public partial class TestStudentRegistry
    {
        [TestClass]
        public partial class TestSubject
        {
            [TestMethod]
            public void TestCountTensForSubject()
            {
                Subject subject = new Subject ( new int[] { 10, 2, 6});
                Assert.AreEqual(subject.CountGradesOfTenForEachSubject(), 1);
            }

            [TestMethod]
            public void TestAverageGradeForSubject()
            {
                Subject subject = new Subject(new int[] { 10, 2, 6 });
                Assert.AreEqual(subject.GetAverageGradeForSubject(), 6);
            }
        }


    }
}
