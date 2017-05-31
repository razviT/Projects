using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ObjectLesson
{
    class Student
    {
        private string name;
        private Subject math;
        private Subject english;
        private Subject biology;
        public Student(string name, Subject math, Subject english, Subject biology)
        {
            this.name = name;
            this.math = math;
            this.english = english;
            this.biology = biology;
        }
        public string Name() 
        {
             return name;
        }
        public Subject Math()
        {
            return math;
        }
        public Subject English()
        {
            return english;
        }
        public Subject Biology()
        {
            return biology;
        }
       
               
    }
    class Subject
    {
        private int[] grades;
        public Subject(int[] grades)
        {
            this.grades = grades;
        }
        public decimal GetAverageGrade()
        {
            var sum = 0;
            for(int i = 0; i < grades.Length; i++)
            {
                sum += grades[i];
            }
            return sum / grades.Length;
        }
    }
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(AverageGrade(), 9);
        }
        decimal AverageGrade()
        {
            Student oneStudent = new Student("razvan", new Subject(new int[] { 10, 7, 10 }), new Subject(new int[] { 9, 8, 10 }), new Subject(new int[] { 7, 8, 5 }));
            var averageGrade = oneStudent.Math().GetAverageGrade();
            return averageGrade;
            
            
        }
    }
}
