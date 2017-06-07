using System;

namespace ObjectLesson
{
    class Student
    {
        private string name;
        private Subject[] subjects;

        public Student(string name, Subject[] subjects)
        {
            this.name = name;
            this.subjects = subjects;
        }

        public decimal GetGeneralGradeAverage()
        {
            decimal sum = 0;
            for (int i = 0; i < subjects.Length; i++)
            {
                sum += subjects[i].GetAverageGradeForSubject();
            }
            return decimal.Round(sum / subjects.Length, 2, MidpointRounding.AwayFromZero);
        }

        public decimal CountTotalGradesOfTen()
        {
            decimal count = 0;
            for (int i = 0; i < subjects.Length; i++)
            {
                count += subjects[i].CountGradesOfTenForEachSubject();
            }
            return count;
        }

        public bool IsInAlphabeticalOrder(Student student)
        {
            if (student.name.CompareTo(name) > 0)
            {
                return false;
            }            
            else
            {
                return true;
            }
        }
        public bool IsSameName(Student student)
        {
            if (student.name == name)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsSameGradesForEachSubject(Student student)
        {
            bool sameGradesForEachSubject = true;
            int minLength = Math.Min(student.subjects.Length, subjects.Length);
            for (int i = 0; i < minLength; i++)
            {
                if (subjects[i].AreTheSameGrades(student.subjects[i]) == false)
                {
                    sameGradesForEachSubject = false;
                }
            }
            return sameGradesForEachSubject;
        }
        
    }
}
