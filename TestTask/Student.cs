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
        public Gender gender;

        public void studentEditor()
        {
            Console.Clear();
            Console.WriteLine("Введiть iм'я, прiзвище та стать студента з нової стрiчки:");

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

            int day, month, year;
            Console.WriteLine("Введiть дату народження");
            Console.Write("\tДень: ");
            day = Convert.ToInt32(Console.ReadLine());
            if (day > 31 || day <= 0) throw new Exception("Неможливе значення");
            Console.Write("\tМiсяць: ");
            month = Convert.ToInt32(Console.ReadLine());
            if (month <= 0 || month > 12) throw new Exception("Неможливе значення");
            Console.Write("\tРiк: ");
            year = Convert.ToInt32(Console.ReadLine());
            if (year <= 0 || year >= DateTime.Today.Year) throw new Exception("Неможливе значення");
            this.DateOfBirth = new DateTime(year, month, day);

            Console.WriteLine("Вкажiть числом курс, на якому навчається студент:");
            Course = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введiть номер залiкової книжки:");
            numOfRecBook = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введiть середню оцiнку зi всiх предметiв: ");
            AverageGraduation = Convert.ToInt32(Console.ReadLine());
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
