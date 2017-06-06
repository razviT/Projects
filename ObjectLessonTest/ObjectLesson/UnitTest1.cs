using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ObjectLesson
{

    [TestClass]
    public partial class UnitTest1
    {
        StudentRegistry studentRegistry = new StudentRegistry(new Student[] { new Student("razvan", new Subject[] { new Subject(new int[] { 10, 7, 10 }), new Subject(new int[] { 8, 8, 7 }), new Subject(new int[] { 7, 8, 5 }) }),
                                                                                  new Student("ovidiu", new Subject[] { new Subject(new int[] { 9, 8, 10 }), new Subject(new int[] { 9, 8, 9 }), new Subject(new int[] { 10, 10, 10,10 }) }),
                                                                                  new Student("simplon", new Subject[] { new Subject(new int[] { 3, 4, 7 }), new Subject(new int[] { 7, 5, 6 }), new Subject(new int[] { 7, 5 }) }) });

        [TestMethod]
        public void TestGeneralAverageGrade()
        {
            Student oneStudent = new Student("razvan", new Subject[] { new Subject(new int[] { 10, 7, 10 }), new Subject(new int[] { 9, 8, 10 }), new Subject(new int[] { 7, 8, 5 }) });
            Assert.AreEqual(oneStudent.GetGeneralGradeAverage(), 8.22m);
        }

        [TestMethod]
        public void TestGradesOfTen()
        {
            Student oneStudent = new Student("razvan", new Subject[] { new Subject(new int[] { 10, 7, 10 }), new Subject(new int[] { 9, 8, 10 }), new Subject(new int[] { 7, 8, 5 }) });
            Assert.AreEqual(oneStudent.CountTotalGradesOfTen(), 3);
        }

        [TestMethod]
        public void TestForAlphabeticalOrder()
        {
            StudentRegistry studentsInAlphabeticalOrder = new StudentRegistry(studentRegistry.OrderStudentsInAlphabeticalOrder());
            Assert.AreEqual(studentsInAlphabeticalOrder.CheckIfRegistriesHaveTheSameStudents(new Student[] { new Student("ovidiu", new Subject[] { new Subject(new int[] { 9, 8, 10 }), new Subject(new int[] { 7, 8, 7 }), new Subject(new int[] { 10, 10, 10, 10 }) }),
                                                                                                             new Student("razvan", new Subject[] { new Subject(new int[] { 10, 7, 10 }), new Subject(new int[] { 9, 8, 10 }), new Subject(new int[] { 7, 8, 5 }) }),
                                                                                                             new Student("simplon", new Subject[] { new Subject(new int[] { 5, 4, 8 }), new Subject(new int[] { 10, 8, 10 }), new Subject(new int[] { 9, 5 }) }) }), true);
        }

        [TestMethod]
        public void FindStudentsWithCertainGradeAverageTest()
        {
            StudentRegistry studentsWithCertainGradeAverage = new StudentRegistry(studentRegistry.FindStudentWithCertainGradeAverage(8.22m));
            Assert.AreEqual(studentsWithCertainGradeAverage.CheckIfRegistriesHaveTheSameStudents(new Student[] { new Student("razvan", new Subject[] { new Subject(new int[] { 10, 7, 10 }), new Subject(new int[] { 9, 8, 10 }), new Subject(new int[] { 7, 8, 5 }) }) }), true);
        }

        [TestMethod]
        public void FindStudentWithMostTensTest()
        {
            Assert.AreEqual(studentRegistry.FindStudentWithMostTens().IsSameName(new Student("ovidiu", new Subject[] { new Subject(new int[] { 9, 8, 10 }), new Subject(new int[] { 7, 8, 7 }), new Subject(new int[] { 10, 10, 10, 10 }) })), true);
        }
            
        [TestMethod]
        public void OrderStudentsInOrderOfTheirGeneralGradeAverageTest()
        {           
            StudentRegistry orderedStudents = new StudentRegistry(studentRegistry.OrderStudentsInOrderOfTheirGeneralGradeAverage());
            Assert.AreEqual(orderedStudents.CheckIfRegistriesHaveTheSameStudents(new Student[] { new Student("ovidiu", new Subject[] { new Subject(new int[] { 9, 8, 10 }), new Subject(new int[] { 7, 8, 7 }), new Subject(new int[] { 10, 10, 10, 10 }) }),
                                                                                                 new Student("razvan", new Subject[] { new Subject(new int[] { 10, 7, 10 }), new Subject(new int[] { 9, 8, 10 }), new Subject(new int[] { 7, 8, 5 }) }),
                                                                                                 new Student("simplon", new Subject[] { new Subject(new int[] { 5, 4, 8 }), new Subject(new int[] { 10, 8, 10 }), new Subject(new int[] { 9, 5 }) }) }),true);
        }

        [TestMethod]
        public void FindStudentWithLowestGradeAverageTest()
        {       
            Assert.AreEqual(studentRegistry.FindStudentWithLowestGradeAverage().IsSameName(new Student("simplon", new Subject[] { new Subject(new int[] { 5, 4, 8 }), new Subject(new int[] { 10, 8, 10 }), new Subject(new int[] { 9, 5 }) })), true);
        }

        [TestMethod]
        public void FindStudentWithLoestGradeAverageTestTwo()
        {
            Assert.AreEqual(studentRegistry.FindStudentWithLowestGradeAverage().IsSameName(new Student("razvan", new Subject[] { new Subject(new int[] { 10, 7, 10 }), new Subject(new int[] { 9, 8, 10 }), new Subject(new int[] { 7, 8, 5 }) })), false);
        }

        [TestMethod]
        public void OrderStudentsInORderOfTheirGeneralGradeAverageTestTwo()
        {
            StudentRegistry orderedStudents = new StudentRegistry(studentRegistry.OrderStudentsInOrderOfTheirGeneralGradeAverage());
            Assert.AreEqual(orderedStudents.CheckIfRegistriesHaveTheSameStudents(new Student[] { new Student("razvan", new Subject[] { new Subject(new int[] { 10, 7, 10 }), new Subject(new int[] { 8, 8, 7 }), new Subject(new int[] { 7, 8, 5 }) }),
                                                                                  new Student("ovidiu", new Subject[] { new Subject(new int[] { 9, 8, 10 }), new Subject(new int[] { 9, 8, 9 }), new Subject(new int[] { 10, 10, 10,10 }) }),
                                                                                  new Student("simplon", new Subject[] { new Subject(new int[] { 3, 4, 7 }), new Subject(new int[] { 7, 5, 6 }), new Subject(new int[] { 7, 5 }) }) }), false);
        }

        [TestMethod]
        public void FindStudentsWithMostTensTestTwo()
        {
            Assert.AreEqual(studentRegistry.FindStudentWithMostTens().IsSameName(new Student("razvan", new Subject[] { new Subject(new int[] { 10, 7, 10 }), new Subject(new int[] { 8, 8, 7 }), new Subject(new int[] { 7, 8, 5 }) })), false);
        }
    }
}
