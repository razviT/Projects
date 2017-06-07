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

            [TestMethod]
            public void TestAreTheSameGrades()
            {
                Subject subject = new Subject(new int[] { 10, 2, 6 });
                Assert.AreEqual(subject.AreTheSameGrades(new Subject(new int[] { 10, 2, 6 })), true);
            }

            [TestMethod]
            public void TestAreTheSameGradesTwo()
            {
                Subject subject = new Subject(new int[] { 10, 2, 6 });
                Assert.AreEqual(subject.AreTheSameGrades(new Subject(new int[] { 10, 3, 6 })), false);
            }
        }


    }
}
