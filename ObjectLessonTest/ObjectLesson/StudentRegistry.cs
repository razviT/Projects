using System;

namespace ObjectLesson
{
    class StudentRegistry
    {
        private Student[] students;
        public StudentRegistry(Student[] students)
        {
            this.students = students;
        }
        public Student[] OrderStudentsInAlphabeticalOrder()
        {
            var inAlphabeticalOrder = false;
            while (inAlphabeticalOrder == false)
            {
                inAlphabeticalOrder = true;
                inAlphabeticalOrder = SwapStudentsUntilInAlphabeticalOrder(inAlphabeticalOrder);
            }
            return students;
        }

        private bool SwapStudentsUntilInAlphabeticalOrder(bool order)
        {
            for (int i = 1; i < students.Length; i++)
            {               
                if (!students[i].IsInAlphabeticalOrder(students[i - 1]))
                {
                    SwapStudents(i);
                    order = false;
                }
            }
            return order;
        }

        private void SwapStudents(int i)
        {
            var temporary = students[i];
            students[i] = students[i - 1];
            students[i - 1] = temporary;
        }

        public Student[] FindStudentsWithCertainGrade(decimal grade)
        {
            Student[] studentsWithCertainGrade = new Student[0];
            for (int i = 0; i < students.Length; i++)
            {
                if (students[i].GetGeneralGradeAverage() == grade)
                {
                    Array.Resize(ref studentsWithCertainGrade, studentsWithCertainGrade.Length + 1);
                    studentsWithCertainGrade[studentsWithCertainGrade.Length - 1] = students[i];
                }
            }
            return studentsWithCertainGrade;  
        }
        
        public Student FindStudentWithMostTens()
        {
            var studentWithMostTens = students[0];
            for (int i = 1; i < students.Length; i++)
            {
                studentWithMostTens = (students[i].CountTotalGradesOfTen() > students[i - 1].CountTotalGradesOfTen()) ? students[i] : studentWithMostTens;
            }
            return studentWithMostTens;
        }

        public Student FindStudentWithLowestGradeAverage()
        {
            var studentWithLowestGradeAverage = students[0];
            for(int i = 1; i < students.Length; i++)
            {
                studentWithLowestGradeAverage = (students[i].GetGeneralGradeAverage() < students[i - 1].GetGeneralGradeAverage()) ? students[i] : studentWithLowestGradeAverage;
            }
            return studentWithLowestGradeAverage;
        }

        public Student[] ArrangeInOrderOfGrades()
        {
            bool inOrderOfGrade = false;
            while (inOrderOfGrade == false) 
            {
                inOrderOfGrade = true;
                inOrderOfGrade = SwapStudentsUntilInOrderOfGeneralGradeAverage(inOrderOfGrade);
            }
            return students;
        }

        private bool SwapStudentsUntilInOrderOfGeneralGradeAverage(bool inOrder)
        {
            for (int i = 1; i < students.Length; i++)
            {
                if (students[i].GetGeneralGradeAverage() > students[i - 1].GetGeneralGradeAverage())
                {
                    inOrder = false;
                    SwapStudents(i);
                }
            }
            return inOrder;
        }

        public bool CheckIfRegistriesMatch(Student[] otherStudents)
        {
            int minLength = Math.Min(students.Length, otherStudents.Length);            
            for(int i = 0; i < minLength; i++)
            {
                if (!students[i].IsSameName(otherStudents[i]) && !students[i].IsSameGradesForEachSubject(otherStudents[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
