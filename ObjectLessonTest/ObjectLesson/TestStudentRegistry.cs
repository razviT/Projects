using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ObjectLesson
{

    [TestClass]
    public partial class TestStudentRegistry
    {
        StudentRegistry studentRegistry = new StudentRegistry(
            new Student[] {
                new Student("razvan", 
                    new Subject[] {
                        new Subject(new int[] { 10, 7, 10 }),
                        new Subject(new int[] { 8, 8, 7 }),
                        new Subject(new int[] { 7, 8, 5 }) }),
                new Student("ovidiu", 
                    new Subject[] {
                        new Subject(new int[] { 9, 8, 10 }),
                        new Subject(new int[] { 9, 8, 9 }),
                        new Subject(new int[] { 10, 10, 10,10 }) }),
                new Student("simplon", 
                    new Subject[] {
                        new Subject(new int[] { 3, 4, 7 }),
                        new Subject(new int[] { 7, 5, 6 }),
                        new Subject(new int[] { 7, 5 }) }) });
                      
        [TestMethod]
        public void TestOrderStudentsInAlphabeticalOrder()
        {
            StudentRegistry studentsInAlphabeticalOrder = new StudentRegistry(studentRegistry.OrderStudentsInAlphabeticalOrder());
            Assert.AreEqual(studentsInAlphabeticalOrder
                .CheckIfRegistriesHaveTheSameStudents(
                    new Student[] {
                        new Student(
                            "ovidiu", 
                            new Subject[] {
                                new Subject(new int[] { 9, 8, 10 }),
                                new Subject(new int[] { 7, 8, 7 }),
                                new Subject(new int[] { 10, 10, 10, 10 }) }),
                        new Student(
                            "razvan", 
                            new Subject[] {
                                new Subject(new int[] { 10, 7, 10 }),
                                new Subject(new int[] { 9, 8, 10 }),
                                new Subject(new int[] { 7, 8, 5 }) }),
                        new Student(
                            "simplon", 
                            new Subject[] {
                                new Subject(new int[] { 5, 4, 8 }),
                                new Subject(new int[] { 10, 8, 10 }),
                                new Subject(new int[] { 9, 5 }) }) }), true);
        }

        [TestMethod]
        public void FindStudentsWithCertainGradeAverageTest()
        {
            StudentRegistry studentsWithCertainGrade = new StudentRegistry(studentRegistry.FindStudentsWithCertainGradeAverage(8.22m));
            Assert.AreEqual(studentsWithCertainGrade
                .CheckIfRegistriesHaveTheSameStudents(
                    new Student[] {
                        new Student(
                            "razvan",
                            new Subject[] {
                                new Subject(new int[] { 10, 7, 10 }),
                                new Subject(new int[] { 9, 8, 10 }),
                                new Subject(new int[] { 7, 8, 5 }) }) }), true);
        }

        [TestMethod]
        public void FindStudentWithMostTensTest()
        {
            Assert.AreEqual(studentRegistry
                .FindStudentWithMostTens()
                .IsSameStudent(
                    new Student(
                        "ovidiu", 
                        new Subject[] {
                            new Subject(new int[] { 9, 8, 10 }),
                            new Subject(new int[] { 7, 8, 7 }),
                            new Subject(new int[] { 10, 10, 10, 10 }) })), true);
        }
            
        [TestMethod]
        public void ArrangeInOrderOfGradesTest()
        {           
            StudentRegistry orderedStudents = new StudentRegistry(studentRegistry.ArrangeInOrderOfGrades());
            Assert.AreEqual(orderedStudents
                .CheckIfRegistriesHaveTheSameStudents(
                    new Student[] {
                        new Student(
                            "ovidiu",
                            new Subject[] {
                                new Subject(new int[] { 9, 8, 10 }),
                                new Subject(new int[] { 7, 8, 7 }),
                                new Subject(new int[] { 10, 10, 10, 10 }) }),
                        new Student(
                            "razvan", 
                            new Subject[] {
                                new Subject(new int[] { 10, 7, 10 }),
                                new Subject(new int[] { 9, 8, 10 }),
                                new Subject(new int[] { 7, 8, 5 }) }),
                        new Student(
                            "simplon", 
                            new Subject[] {
                                new Subject(new int[] { 5, 4, 8 }),
                                new Subject(new int[] { 10, 8, 10 }),
                                new Subject(new int[] { 9, 5 }) }) }),true);
        }

        [TestMethod]
        public void FindStudentWithLowestGradeAverageTest()
        {       
            Assert.AreEqual(studentRegistry
                .FindStudentWithLowestGradeAverage()
                .IsSameStudent(
                    new Student(
                        "simplon", 
                        new Subject[] {
                            new Subject(new int[] { 5, 4, 8 }),
                            new Subject(new int[] { 10, 8, 10 }),
                            new Subject(new int[] { 9, 5 }) })), true);
        }

        [TestMethod]
        public void FindStudentWithLowestGradeAverageTestTwo()
        {
            Assert.AreEqual(studentRegistry
                .FindStudentWithLowestGradeAverage()
                .IsSameStudent(
                    new Student(
                        "razvan", 
                        new Subject[] {
                            new Subject(new int[] { 10, 7, 10 }),
                            new Subject(new int[] { 9, 8, 10 }),
                            new Subject(new int[] { 7, 8, 5 }) })), false);
        }

        [TestMethod]
        public void ArrangeInOrderOfGradesTestTwo()
        {
            StudentRegistry orderedStudents = new StudentRegistry(studentRegistry.ArrangeInOrderOfGrades());
            Assert.AreEqual(orderedStudents
                .CheckIfRegistriesHaveTheSameStudents(
                    new Student[] {
                         new Student(
                            "razvan", 
                            new Subject[] {
                                new Subject(new int[] { 10, 7, 10 }),
                                new Subject(new int[] { 8, 8, 7 }),
                                new Subject(new int[] { 7, 8, 5 }) }),
                         new Student(
                            "ovidiu", 
                            new Subject[] {
                                new Subject(new int[] { 9, 8, 10 }),
                                new Subject(new int[] { 9, 8, 9 }),
                                new Subject(new int[] { 10, 10, 10,10 }) }),
                         new Student(
                            "simplon", 
                            new Subject[] {
                                new Subject(new int[] { 3, 4, 7 }),
                                new Subject(new int[] { 7, 5, 6 }),
                                new Subject(new int[] { 7, 5 }) }) }), false);
        }

        [TestMethod]
        public void FindStudentsWithMostTensTestTwo()
        {
            Assert.AreEqual(studentRegistry
                .FindStudentWithMostTens()
                .IsSameStudent(
                    new Student(
                        "razvan", 
                        new Subject[] {
                            new Subject(new int[] { 10, 7, 10 }),
                            new Subject(new int[] { 8, 8, 7 }),
                            new Subject(new int[] { 7, 8, 5 }) })), false);
        }
    }
}
