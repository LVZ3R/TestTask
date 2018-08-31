using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    class PersonFunctional : IFunctional
    {
        // MAIN LISTS
        public static List<Teacher> teachers = new List<Teacher>(0);
        public static List<Student> students = new List<Student>(0);

        // ADDER
        public void Add<T> (T value, List<T> listToAdd)
        {
            Console.Clear();
            try
            {
                listToAdd.Add(value);
            }

            catch (Exception ex)
            {
                Console.WriteLine("Непередбачена помилка при створеннi об'єкта: " + ex.Message);
            }
        }

        // PRINTER
        public void Print<T>(List<T> listToPrint)
        {
            int step = 0;
            foreach (T obj in listToPrint)
            {
                Console.WriteLine(step++ + " " + obj.ToString() + "\n");
            }
            Console.ReadKey();
        }

        // REMOVE
        public void Remove<T> (List<T> listToRemove, int index)
        {
            listToRemove.RemoveAt(index);
        }

        // EDITOR
        public void Edit(int index, int sender)
        {
            if (sender == 7)
            {
                teachers[index].teacherEditor();
            }
            else
                if (sender == 8)
            {
                students[index].studentEditor();
            }
            else
                throw new Exception("Непередбачений збiй в виконаннi функцiї Edit");
        }

        // FIND MENU
        public void FindByParams()
        {
            byte userChoise = 0;
            bool menuIsRunning = true;

            while (menuIsRunning)
            {
                Console.Clear();
                Console.Write("\t[ПОШУК]\n");
                Console.Write("1 - Пошук викладача та студента по ID\n");
                Console.Write("2 - Пошук викладачiв по прiзвищах\n");
                Console.Write("3 - Пошук викладачiв по iменах\n");
                Console.Write("4 - Пошук студентiв по прiзвищах\n");
                Console.Write("5 - Пошук студентiв по iменах\n");
                Console.Write("6 - Пошук студентiв по курсу\n\n");
                Console.Write("7 - Вихiд з меню\n\n-> ");

                userChoise = Convert.ToByte(Console.ReadLine());
                switch (userChoise)
                {
                    case 1:
                        Console.Write("Введiть ID: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        FindByID(id);
                        break;
                    case 2:
                        FindByName(true, teachers);
                        break;
                    case 3:
                        FindByName(false, teachers);
                        break;
                    case 4:
                        FindByName(true, students);
                        break;
                    case 5:
                        FindByName(false, students);
                        break;
                    case 6:
                        FindByCourse();
                        break;
                    case 7:
                        menuIsRunning = false;
                        break;
                }
            }
        }

        // пошук прізвищ та імен в списках викладачів і студентів
        public void FindByName<T>(bool isLastName, List<T> toCompare) where T : Person
        {
            Console.Write("Введiть пошуковий запит: ");
            String targetString = "";
            targetString = Console.ReadLine();
            if (targetString.Length < 2)
                throw new Exception("Довжина запиту не може бути коротше двох символiв!");

            List<T> partialSimilarity = new List<T>();
            int step = 0;

            Console.Clear();
            Console.WriteLine("\tАбсолютна збiжнiсть: \n");
            foreach (T t in toCompare)
            {
                if (isLastName)
                {
                    if (t.LastName == targetString)
                        Console.WriteLine(step++ + ": " + t.ToString() + "\n");
                    else
                        if (t.LastName.Contains(targetString))
                        partialSimilarity.Add(t);
                }
                else
                {
                    if (t.FirstName == targetString)
                        Console.WriteLine(step++ + ": " + t.ToString() + "\n");
                    else
                        if (t.FirstName.Contains(targetString))
                        partialSimilarity.Add(t);
                }
            }

            Console.WriteLine("<-- Кiнець списку -->");

            ShowPartialSimilarity(partialSimilarity);

            Console.ReadKey();
        }

        // відображення знайдених збіжностей
        private void ShowPartialSimilarity<T> (List<T> toPrint)
        {
            if (toPrint.Count != 0)
            {
                Console.Write("Бажаєте переглянути список схожих результатiв? (y/n) ");
                char answer = Convert.ToChar(Console.ReadLine());
                if (answer == 'y')
                {
                    Console.Clear();
                    int step = 0;
                    foreach (T t in toPrint)
                    {
                        Console.WriteLine(step++ + ": " + t.ToString() + "\n");
                    }
                }
            }
        }

        // пошук по ID студента і викладача
        public void FindByID(int id)
        {
            Console.WriteLine("Викладач" + teachers[id].ToString());
            Console.WriteLine("Студент" + students[id].ToString());

            Console.ReadKey();
        }

        // пошук студентів по курсу
        public void FindByCourse()
        {
            int step = 0;
            Console.Write("Введiть номер курсу: ");
            int course = Convert.ToInt32(Console.ReadLine());
            foreach(Student s in students)
            {
                if (s.Course == course)
                    Console.WriteLine(step++ + " " + s.ToString() + "\n");
            }

            Console.ReadKey();
        }

        // PERSON MENU
        public static void PersonMenu(PersonFunctional functional)
        {
            int userChoise = 0;
            bool menuIsRunning = true;
            while (menuIsRunning)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                Console.WriteLine("\t[ВИКЛАДАЧI]\t\t\t\t[СТУДЕНТИ]");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("1 - Додати нового викладача\t\t");
                Console.Write("2 - Додати нового студента\n");
                Console.Write("3 - Вивести всiх викладачiв\t\t");
                Console.Write("4 - Вивести всiх студентiв\n");
                Console.Write("5 - Видалити викладача\t\t\t");
                Console.Write("6 - Видалити студента\n");
                Console.Write("7 - Вiдредагувати данi викладача\t");
                Console.Write("8 - Вiдредагувати данi студента\n\n");
                Console.Write("9 - Пошук\n\n");
                Console.Write("10 - Вивести список студентiв в алфавiтному порядку\n");
                Console.Write("11 - Запустити тестовий набiр даних\n");
                Console.Write("12 - Вихiд\n\n-> ");
                Console.ForegroundColor = ConsoleColor.White;

                userChoise = Convert.ToInt32(Console.ReadLine());
                switch (userChoise)
                {
                    case 1:
                        Teacher newTeacher = new Teacher();
                        newTeacher.teacherEditor();
                        functional.Add(newTeacher, teachers);
                        break;
                    case 2:
                        Student newStudent = new Student();
                        newStudent.studentEditor();
                        functional.Add(newStudent, students);
                        break;
                    case 3:
                        functional.Print(teachers);
                        break;
                    case 4:
                        functional.Print(students);
                        break;
                    case 5:
                        Console.Write("Вкажiть ID викладача: ");
                        functional.Remove(teachers, Convert.ToInt32(Console.ReadLine()));
                        break;
                    case 6:
                        Console.Write("Вкажiть ID студента: ");
                        functional.Remove(students, Convert.ToInt32(Console.ReadLine()));
                        break;
                    case 7:
                        Console.Write("Введiть ID викладача: ");
                        functional.Edit(Convert.ToInt32(Console.ReadLine()), 7);
                        break;
                    case 8:
                        Console.Write("Введiть ID студента: ");
                        functional.Edit(Convert.ToInt32(Console.ReadLine()), 8);
                        break;
                    case 9:
                        functional.FindByParams();
                        break;
                    case 10:
                        Student.studentSorter(students);
                        break;
                    case 11:
                        Console.Clear();
                        students = new List<Student>() {
                                new Student("Владислав",    "Антонов", Person.Gender.Чоловiк, new DateTime(1998, 11, 26), 1337, 4, 75),     // 1
                                new Student("Борис",        "Керницький", Person.Gender.Чоловiк, new DateTime(1997, 11, 2), 1338, 4, 70),   // 2
                                new Student("Владислав",    "Андрейченко", Person.Gender.Чоловiк, new DateTime(1998, 6, 20), 1339, 4, 90),    // 3
                                new Student("Оксана",       "Дрипсяк", Person.Gender.Жiнка, new DateTime(1996, 3, 8), 1247, 5, 95),         // 4
                                new Student("Ігор",         "Гриців", Person.Gender.Чоловiк, new DateTime(1998, 4, 22), 1340, 4, 75),       // 5
                                new Student("Валерія",      "Студенець", Person.Gender.Жiнка, new DateTime(1994, 5, 20), 1156, 6, 90),      // 6
                                new Student("Анна",         "Баранець", Person.Gender.Жiнка, new DateTime(1998, 5, 13), 1341, 4, 80),       // 7
                                new Student("Олександр",    "Пустовалов", Person.Gender.Чоловiк, new DateTime(1997, 6, 13), 1336, 4, 85),   // 8
                                new Student("Олександр",    "Ковальський", Person.Gender.Чоловiк, new DateTime(1996, 7, 12), 1280, 5, 75),  // 9
                                new Student("Михайло",      "Яцюк", Person.Gender.Чоловiк, new DateTime(1998, 9, 1), 1350, 4, 75)           // 10
                            };

                        teachers = new List<Teacher>() {
                                new Teacher("Тарас", "Гайдар", Person.Gender.Чоловiк, new DateTime(1997, 9, 13), 7, new List<string>() { "Математика", "Алгебра", "Геометрія"}),
                                new Teacher("Марина", "Франко", Person.Gender.Жiнка, new DateTime(1995, 8, 20), 3, new List<string>() { "Економіка", "Менеджмент персоналу", "Туризм"}),
                                new Teacher("Богдан", "Кирилович", Person.Gender.Чоловiк, new DateTime(1997, 3, 31), 2, new List<string>() { "Фізичне виховання", "Воєнна підготовка"}),
                                new Teacher("Олег", "Романів", Person.Gender.Чоловiк, new DateTime(1996, 10, 8), 14, new List<string>() { "Ресторація", "Менеджмент персоналу", "Філософія"})
                            };

                        Console.WriteLine("Вiдсортований набiр студентiв:\n\n");
                        Student.studentSorter(students);
                        break;
                    case 12:
                        menuIsRunning = false;
                        break;
                }
            }
        }
    }
}
