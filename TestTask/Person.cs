using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace TestTask
{
    class Person
    {

        public Gender gender { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public enum Gender
        {
            Чоловiк,
            Жiнка
        }

        public void personEditor()
        {
            Console.WriteLine("Введiть iм'я, прiзвище та стать з нової стрiчки:");

            FirstName = Console.ReadLine();
            FirstName = FirstName.Replace('?', 'і');
            LastName = Console.ReadLine();
            LastName = LastName.Replace('?', 'і');
            if (Regex.Match(FirstName, @"[^a-zA-Zа-яА-Я]").Success ||
                Regex.Match(LastName, @"[^a-zA-Za-яА-Я]").Success)
            {
                throw new Exception("Стрiчка може мiстити тiльки символи латиницi або кирилицi");
            }

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
        }
    }
}
