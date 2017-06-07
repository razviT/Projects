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
                inAlphabeticalOrder = SwapUntilInAlphabeticalOrder(inAlphabeticalOrder);
            }
            return students;
        }

        private bool SwapUntilInAlphabeticalOrder(bool order)
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

        public Student[] FindStudentsWithCertainGradeAverage(decimal grade)
        {
            Student[] studentsWithCertainGradeAverage = new Student[0];
            for (int i = 0; i < students.Length; i++)
            {
                if (students[i].GetGeneralGradeAverage() == grade)
                {
                    Array.Resize(ref studentsWithCertainGradeAverage, studentsWithCertainGradeAverage.Length + 1);
                    studentsWithCertainGradeAverage[studentsWithCertainGradeAverage.Length - 1] = students[i];
                }
            }
            return studentsWithCertainGradeAverage;  
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

        public Student[] OrderStudentsInOrderOfTheirGeneralGradeAverage()
        {
            bool inOrderOfGrade = false;
            while (inOrderOfGrade == false) 
            {
                inOrderOfGrade = true;
                inOrderOfGrade = SwapUntilInOrderOfGeneralGradeAverage(inOrderOfGrade);
            }
            return students;
        }

        private bool SwapUntilInOrderOfGeneralGradeAverage(bool inOrder)
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

        public bool CheckIfRegistriesHaveTheSameStudents(Student[] otherStudents)
        {           
            for(int i = 0; i < students.Length; i++)
            {
                if (!students[i].IsSameStudent(otherStudents[i]))
                    return false;
            }
            return true;
        }
    }
}
