using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace ObjectLesson
{

    [TestClass]
    public partial class StudentRegistryTest
    {
        private static readonly Student razvan = new Student("razvan", new Subject[] {
                        new Subject(new int[] { 10, 7, 10 }),
                        new Subject(new int[] { 9, 8, 10 }),
                        new Subject(new int[] { 7, 8, 5 }) });

        private static readonly Student ovidiu = new Student("ovidiu", new Subject[] {
                        new Subject(new int[] { 9, 8, 10 }),
                        new Subject(new int[] { 9, 8, 9 }),
                        new Subject(new int[] { 10, 10, 10,10 }) });

        private static readonly Student paul = new Student("paul", new Subject[] {
                        new Subject(new int[] { 3, 4, 7 }),
                        new Subject(new int[] { 7, 5, 6 }),
                        new Subject(new int[] { 7, 5 }) });

        StudentRegistry studentRegistry = new StudentRegistry(
            new Student[] { razvan, ovidiu, paul });
                      
        [TestMethod]
        public void TestOrderStudentsInAlphabeticalOrder()
        {          
            CollectionAssert.AreEqual(new Student[] { ovidiu, paul, razvan },
                studentRegistry.OrderStudentsInAlphabeticalOrder().ToArray());
        }

        [TestMethod]
        public void FindStudentsWithCertainGradeAverageTest()
        {
            CollectionAssert.AreEqual(new Student[] { razvan },
                studentRegistry.FindStudentsWithCertainGrade(8.22m).ToArray());         
        }

        [TestMethod]
        public void FindStudentWithMostTensTest()
        {          
            Assert.AreEqual(studentRegistry.FindStudentWithMostTens(), ovidiu);
        }

        [TestMethod]
        public void ArrangeInOrderOfGradesTest()
        {          
            CollectionAssert.AreEqual(new Student[] { ovidiu, razvan, paul },
                studentRegistry.ArrangeInOrderOfGrades().ToArray());
        }
    
        [TestMethod]
        public void FindStudentWithLowestGradeAverageTest()
        {
            Assert.AreEqual(studentRegistry.FindStudentWithLowestGradeAverage(), paul);
        }

        [TestMethod]
        public void TestGetWantedStudent()
        {
            Assert.AreEqual(studentRegistry.GetWantedStudent(2), ovidiu);
        }
         
    }
}
