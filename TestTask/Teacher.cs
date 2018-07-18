using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    public class Teacher : Person
    {
        public int iD { get; set; }
        public int workExp { get; set; }
        public Gender gender;
        private List<String> lessons = new List<String>(0);

        public void removeLesson(String lessonName)
        {
            for (int i = 0; i < lessons.Count; i++)
            {
                if (lessons[i] == lessonName)
                {
                    lessons.RemoveAt(i);
                    break;
                }
            }
        }

        public void teacherEditor(int teacherID)
        {
            Console.Clear();
            Console.WriteLine("Введiть iм'я, прiзвище та стать викладача з нової стрiчки:");

            FirstName = Console.ReadLine();
            FirstName = FirstName.Replace('?', 'і');
            LastName = Console.ReadLine();
            LastName = LastName.Replace('?', 'і');

            String gender = Console.ReadLine();
            gender = gender.ToLower();
            if (gender == "чоловiча" || gender == "чоловiк" ||
                gender == "чолов?к" || gender == "чолов?ча" ||
                gender == "ч")
            {
                this.gender = Gender.Чоловiк;
            }
            else
            if (gender == "жiноча" || gender == "жiнка" ||
                gender == "ж?нка" || gender == "ж?ноча" ||
                gender == "ж")
            {
                this.gender = Gender.Жiнка;
            }
            else
                throw new Exception("Такої статi не iснує");

            iD = teacherID;

            Console.WriteLine("Введiть дату народження у форматi ДД/ММ/РРРР:");
            DateOfBirth = Console.ReadLine();

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
            infoStr += "Дата народження: " + DateOfBirth;
            infoStr += "\nПредмети:\n";

            for (int i = 0; i < lessons.Count; i++)
            {
                infoStr += "\t- " + lessons[i] + "\n";
            }

            return infoStr;
        }
    }
}
