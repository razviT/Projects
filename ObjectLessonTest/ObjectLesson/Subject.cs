namespace ObjectLesson
{
    class Subject
    {
        private int[] grades;
        public Subject(int[] grades)
        {
            this.grades = grades;
        }
        public decimal GetAverageGradeForSubject()
        {
            decimal sum = 0;
            for(int i = 0; i < grades.Length; i++)
            {
                sum += grades[i];
            }
            return sum / grades.Length;
        }
        public decimal CountGradesOfTenForEachSubject()
        {
            decimal count = 0;
            for(int i = 0; i < grades.Length; i++)
            {
                count = (grades[i] == 10) ? count + 1 : count;
            }
            return count;
        }
    }
}
