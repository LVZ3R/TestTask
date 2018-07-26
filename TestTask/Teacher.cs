using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestTask
{
    class Teacher : Person
    {
        public int workExp { get; set; }
        //public Gender gender;
        private List<String> lessons = new List<String>(0);

        public Teacher() { }

        public Teacher(String fName, String lName, Gender sex, DateTime dateOfBirth, int workExp, List<String> lessons)
        {
            try
            {
                FirstName = fName;
                LastName = lName;
                gender = sex;
                this.DateOfBirth = dateOfBirth;
                this.workExp = workExp;
                this.lessons = lessons;
            }
            catch (Exception ex)
            {
                Console.WriteLine("!!! Error: " + ex.Message);
            }
        }

        public void teacherEditor()
        {
            Console.Clear();
            personEditor();

            Console.WriteLine("Вкажiть числом досвiд роботи:");
            workExp = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Скiльки предметiв викладає цей викладач?");
            int lessonsCount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введiть назви предметiв (кожний з нової стрiчки):");

            for (int i = 0; i < lessonsCount; i++)
            {
                lessons.Add(Console.ReadLine());
            }
        }

        public override string ToString()
        {
            String infoStr = ": " + FirstName + " " + LastName + ", " + gender + "\n";
            infoStr += "Стаж: " + workExp + ", кiлькiсть предметiв: " + (lessons.Count()) + "\n";
            infoStr += "Дата народження: " + DateOfBirth.ToShortDateString();
            infoStr += "\nПредмети:\n";

            for (int i = 0; i < lessons.Count; i++)
            {
                infoStr += "\t- " + lessons[i] + "\n";
            }

            return infoStr;
        }
    }
}
