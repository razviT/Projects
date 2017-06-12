using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ObjectLesson
{
    public partial class StudentRegistryTest
    {
        [TestClass]
        public partial class TestSubject
        {
            [TestMethod]
            public void TestCountTensForSubject()
            {
                Subject subject = new Subject ( new int[] { 10, 2, 6});
                Assert.AreEqual(subject.CountGradesOfTen(), 1);
            }

            [TestMethod]
            public void TestAverageGradeForSubject()
            {
                Subject subject = new Subject(new int[] { 10, 2, 6 });
                Assert.AreEqual(subject.GetAverageGrade(), 6);
            }      
        }
    }
}
