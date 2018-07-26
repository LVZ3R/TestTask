using System;
using System.Collections.Generic;
using System.Linq;
using static TestTask.Functional;

namespace TestTask
{
    class Program
    {
        static void Main(string[] args)
        {
            int userChoise;
            bool appIsRunning = true;

            while (appIsRunning)
            {
                Console.Clear();
                Console.WriteLine("1 - Додати нового викладача");
                Console.WriteLine("2 - Додати нового студента\n");
                Console.WriteLine("3 - Вивести всiх викладачiв");
                Console.WriteLine("4 - Вивести всiх студентiв\n");
                Console.WriteLine("5 - Видалити викладача");
                Console.WriteLine("6 - Видалити студента\n");
                Console.WriteLine("7 - Вiдредагувати данi викладача");
                Console.WriteLine("8 - Вiдредагувати данi студента\n");
                Console.WriteLine("9 - Вивести список студентiв в алфавiтному порядку\n");
                Console.WriteLine("10 - Запустити тестовий набiр даних\n");
                Console.WriteLine("11 - Вихiд");
                try
                {
                    userChoise = Convert.ToInt32(Console.ReadLine());
                    switch (userChoise)
                    {
                        case 1:
                            teacherAdder();
                            break;
                        case 2:
                            studentAdder();
                            break;
                        case 3:
                            teacherPrinter();
                            break;
                        case 4:
                            studentPrinter();
                            break;
                        case 5:
                            removeTeacher();
                            break;
                        case 6:
                            removeStudent();
                            break;
                        case 7:
                            editTeacher();
                            break;
                        case 8:
                            editStudent();
                            break;
                        case 9:
                            Student.studentSorter(students);
                            break;
                        case 10:
                            Console.Clear();
                            List<Student> testListOfStudents = new List<Student>() {
                                new Student("Владислав",    "Антонов", Person.Gender.Чоловiк, new DateTime(1998, 11, 26), 1337, 4, 75),     // 1
                                new Student("Ярослав",      "Гузій", Person.Gender.Чоловiк, new DateTime(1997, 11, 2), 1338, 4, 70),        // 2
                                new Student("Ірина",        "Калиняк", Person.Gender.Жiнка, new DateTime(1998, 6, 20), 1339, 4, 90),        // 3
                                new Student("Оксана",       "Дрипсяк", Person.Gender.Жiнка, new DateTime(1996, 3, 8), 1247, 5, 95),         // 4
                                new Student("Ігор",         "Гриців", Person.Gender.Чоловiк, new DateTime(1998, 4, 22), 1340, 4, 75),       // 5
                                new Student("Валерія",      "Студенець", Person.Gender.Жiнка, new DateTime(1994, 5, 20), 1156, 6, 90),      // 6
                                new Student("Анна",         "Баранець", Person.Gender.Жiнка, new DateTime(1998, 5, 13), 1341, 4, 80),       // 7
                                new Student("Олександр",    "Пустовалов", Person.Gender.Чоловiк, new DateTime(1997, 6, 13), 1336, 4, 85),   // 8
                                new Student("Олександр",    "Ковальський", Person.Gender.Чоловiк, new DateTime(1996, 7, 12), 1280, 5, 75),  // 9
                                new Student("Михайло",      "Яцюк", Person.Gender.Чоловiк, new DateTime(1998, 9, 1), 1350, 4, 75)           // 10
                            };

                            List<Teacher> testListOfTeachers = new List<Teacher>() {
                                new Teacher("Тарас", "Гайдар", Person.Gender.Чоловiк, new DateTime(1997, 9, 13), 7, new List<string>() { "Математика", "Алгебра", "Геометрія"}),
                                new Teacher("Марина", "Франко", Person.Gender.Жiнка, new DateTime(1995, 8, 20), 3, new List<string>() { "Економіка", "Менеджмент персоналу", "Туризм"}),
                                new Teacher("Богдан", "Кирилович", Person.Gender.Чоловiк, new DateTime(1997, 3, 31), 2, new List<string>() { "Фізичне виховання", "Воєнна підготовка"}),
                                new Teacher("Олег", "Романів", Person.Gender.Чоловiк, new DateTime(1996, 10, 8), 14, new List<string>() { "Ресторація", "Менеджмент персоналу", "Філософія"})
                            };

                            Console.WriteLine("Вiдсортований набiр студентiв:\n\n");
                            Student.studentSorter(testListOfStudents);
                            break;
                        case 11:
                            appIsRunning = false;
                            break;
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
    }
}
