using System;
using System.Collections;
using System.Collections.Generic;

namespace ObjectLesson
{

    class StudentRegistry : IEnumerable<Student>
    {
        private Student[] students;
        public StudentRegistry(Student[] students)
        {
            this.students = students;
        }

        public IEnumerator<Student> GetEnumerator()
        {
            return new StudentRegistryEnumerator(students); 
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Student>)students).GetEnumerator();
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

        internal Student GetFirst()
        {
            return students[0];
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
        
        public Student GetWantedStudent(int wantedPosition)
        {
            IEnumerator i = students.GetEnumerator();
            for(int k = 0; k < wantedPosition; k++)
            {
                i.MoveNext();
            }          
            return (Student)i.Current;
        }
    }

    public class StudentRegistryEnumerator : IEnumerator<Student>
    {
        int position = -1;
        public Student[] students;

        public StudentRegistryEnumerator(Student[] students)
        {
            this.students = students;
        }

        public Student Current
        {
            get
            {
                return students[position];
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            position++;
            return (position < students.Length);
        }

        public void Reset()
        {
            position = -1;
        }
    }

}
