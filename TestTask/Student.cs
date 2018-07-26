using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    class Student : Person
    {
        public int numOfRecBook { get; set; }
        public int Course { get; set; }
        public int AverageGraduation { get; set; }
        //public Gender gender;

        public Student() { }

        public Student(String fName, String lName, Gender sex, DateTime dateOfBirth, 
            int numOfRecBook, int Course, int AverageGraduation)
        {
            try
            {
                FirstName = fName;
                LastName = lName;
                gender = sex;
                this.DateOfBirth = dateOfBirth;
                this.numOfRecBook = numOfRecBook;
                this.Course = Course;
                this.AverageGraduation = AverageGraduation;
            }
            catch (Exception ex)
            {
                Console.WriteLine("!!! Error: " + ex.Message);
            }
        }

        public void studentEditor()
        {
            Console.Clear();
            personEditor();

            Console.WriteLine("Вкажiть числом курс, на якому навчається студент:");
            Course = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введiть номер залiкової книжки:");
            numOfRecBook = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введiть середню оцiнку зi всiх предметiв: ");
            AverageGraduation = Convert.ToInt32(Console.ReadLine());
        }

        public static void studentSorter(List<Student> students)
        {
            var sortedStudents = students.OrderBy(o => o.LastName);
            int sID = 0;
            foreach (Student s in sortedStudents)
            {
                Console.WriteLine(sID + s.ToString() + "\n");
                sID++;
            }
            Console.ReadLine();
        }

        public override string ToString()
        {
            String infoStr = ": " + FirstName + " " + LastName + ", " + gender + "\n";
            infoStr += "Курс: " + Course + ", номер залiковки: " + numOfRecBook + ", середнiй бал: " + AverageGraduation + "\n";
            infoStr += "Дата народження: " + DateOfBirth.ToShortDateString();

            return infoStr;
        }
    }
}
