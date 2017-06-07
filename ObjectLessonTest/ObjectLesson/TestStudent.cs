﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ObjectLesson
{  
    public partial class TestStudentRegistry
    {   
        [TestClass]
        public partial class TestStudent
        {
            [TestMethod]
            public void TestGeneralAverageGrade()
            {
                Student oneStudent = new Student("razvan", new Subject[] {
                new Subject(new int[] { 10, 7, 10 }),
                new Subject(new int[] { 9, 8, 10 }),
                new Subject(new int[] { 7, 8, 5 }) });
                Assert.AreEqual(oneStudent.GetGeneralGradeAverage(), 8.22m);
            }

            [TestMethod]
            public void TestTotalGradesOfTen()
            {
                Student oneStudent = new Student("razvan", new Subject[] {
                new Subject(new int[] { 10, 7, 10 }),
                new Subject(new int[] { 9, 8, 10 }),
                new Subject(new int[] { 7, 8, 5 }) });
                Assert.AreEqual(oneStudent.CountTotalGradesOfTen(), 3);
            }

            [TestMethod]
            public void TestIsInAlphabeticalOrder()
            {
                Student oneStudent = new Student("razvan", new Subject[] {
                new Subject(new int[] { 10, 7, 10 }),
                new Subject(new int[] { 9, 8, 10 }),
                new Subject(new int[] { 7, 8, 5 }) });
                Assert.AreEqual(oneStudent.IsInAlphabeticalOrder(new Student("marcel", new Subject[] {
                new Subject(new int[] { 10, 7, 10 }),
                new Subject(new int[] { 9, 8, 10 }),
                new Subject(new int[] { 7, 8, 5 }) })), true);
            }

            [TestMethod]
            public void TestIsInAlphabeticalOrderTwo()
            {
                Student oneStudent = new Student("razvan", new Subject[] {
                new Subject(new int[] { 10, 7, 10 }),
                new Subject(new int[] { 9, 8, 10 }),
                new Subject(new int[] { 7, 8, 5 }) });
                Assert.AreEqual(oneStudent.IsInAlphabeticalOrder(new Student("simina", new Subject[] {
                new Subject(new int[] { 10, 7, 10 }),
                new Subject(new int[] { 9, 8, 10 }),
                new Subject(new int[] { 7, 8, 5 }) })), false);
            }

            [TestMethod]
            public void TestIsSameStudent()
            {
                Student oneStudent = new Student("razvan", new Subject[] {
                new Subject(new int[] { 10, 7, 10 }),
                new Subject(new int[] { 9, 8, 10 }),
                new Subject(new int[] { 7, 8, 5 }) });
                Assert.AreEqual(oneStudent.IsSameStudent(new Student("razvan", new Subject[] {
                new Subject(new int[] { 10, 7, 10 }),
                new Subject(new int[] { 9, 8, 10 }),
                new Subject(new int[] { 7, 8, 5 }) })), true);
            }

            [TestMethod]
            public void TestIsSameStudentTwo()
            {
                Student oneStudent = new Student("razvan", new Subject[] {
                new Subject(new int[] { 10, 7, 10 }),
                new Subject(new int[] { 9, 8, 10 }),
                new Subject(new int[] { 7, 8, 5 }) });
                Assert.AreEqual(oneStudent.IsSameStudent(new Student("ovidiu", new Subject[] {
                new Subject(new int[] { 10, 7, 10 }),
                new Subject(new int[] { 9, 8, 10 }),
                new Subject(new int[] { 7, 8, 5 }) })), false);
            }
        }
    }
}
