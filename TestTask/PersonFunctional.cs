using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    class Functional
    {
        // MAIN LISTS
        public static List<Teacher> teachers = new List<Teacher>(0);
        public static List<Student> students = new List<Student>(0);
        public static List<Schedule> schedules = new List<Schedule>(0);
        public static List<Group> groups = new List<Group>(0);

        // GENERIC ADDER
        public static void Add(object value)
        {
            if (value.GetType() == typeof(Teacher))
            {
                teachers.Add(value as Teacher);
            }
            else
                if (value.GetType() == typeof(Student))
            {
                students.Add(value as Student);
            }
            else
                throw new Exception("Недопустимий тип даних!");
        }

        // PRINTER
        public static void Print(int sender)
        {
            int step = 0;
            if (sender == 3)
            {
                foreach (Teacher t in teachers)
                {
                    Console.WriteLine(step++ + " " + t.ToString() + "\n");
                }
            }
            else
                if (sender == 4)
            {
                foreach (Student s in students)
                {
                    Console.WriteLine(step++ + " " + s.ToString() + "\n");
                }
            }
            else
                throw new Exception("Непередбачена помилка при виконаннi виведення");

            Console.ReadKey();
        }

        // REMOVE
        public static void Remove(int sender, int index)
        {
            if (sender == 5)
            {
                if (teachers[index].ScheduleID != null)
                {
                    teachers[index].ScheduleID.TeacherID = teachers[0];
                }
                teachers.RemoveAt(index);
            }
            else if (sender == 6) students.RemoveAt(index);
            else
                throw new Exception("Непередбачена помилка при здiйсненнi видалення");
        }

        // EDITOR
        public static void Edit(int index, int sender)
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

        // PERSON MENU
        public static void PersonMenu()
        {
            int userChoise = 0;
            bool menuIsRunning = true;
            while (menuIsRunning)
            {
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
                Console.Write("9 - Вивести список студентiв в алфавiтному порядку\n");
                Console.Write("10 - Запустити тестовий набiр даних\n");
                Console.Write("11 - Вихiд\n\n-> ");
                Console.ForegroundColor = ConsoleColor.White;

                userChoise = Convert.ToInt32(Console.ReadLine());
                switch (userChoise)
                {
                    case 1:
                        Teacher newTeacher = new Teacher();
                        newTeacher.teacherEditor();
                        Add(newTeacher);
                        break;
                    case 2:
                        Student newStudent = new Student();
                        newStudent.studentEditor();
                        Add(newStudent);
                        break;
                    case 3:
                        Print(3);
                        break;
                    case 4:
                        Print(4);
                        break;
                    case 5:
                        Console.Write("Вкажiть ID викладача: ");
                        Remove(5, Convert.ToInt32(Console.ReadLine()));
                        break;
                    case 6:
                        Console.Write("Вкажiть ID студента: ");
                        Remove(6, Convert.ToInt32(Console.ReadLine()));
                        break;
                    case 7:
                        Console.Write("Введiть ID викладача: ");
                        Edit(Convert.ToInt32(Console.ReadLine()), 7);
                        break;
                    case 8:
                        Console.Write("Введiть ID студента: ");
                        Edit(Convert.ToInt32(Console.ReadLine()), 8);
                        break;
                    case 9:
                        Student.studentSorter(students);
                        break;
                    case 10:
                        Console.Clear();
                        List<Student> testListOfStudents = new List<Student>() {
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
                        menuIsRunning = false;
                        break;
                }
            }
        }

        // UNIVERSITY MENU
        public static void UniversityMenu()
        {
            int userChoise = 0;
            bool menuIsRunning = true;
            while (menuIsRunning)
            {
                Console.Clear();
                Console.WriteLine("1 - Додати нову групу");
                Console.WriteLine("2 - Додати новий розклад");
                Console.WriteLine("3 - Вихiд з меню\n\n-> ");
                userChoise = Convert.ToInt32(Console.ReadLine());

                switch (userChoise)
                {
                    case 1:
                        Console.Clear();
                        Console.Write("Введiть назву групи: ");
                        string groupName = Console.ReadLine();
                        Console.Write("Введiть ID куратора: ");
                        Group group = new Group(groupName, teachers[Convert.ToInt32(Console.ReadLine())]);
                        groups.Add(group);
                        break;
                    case 2:
                        Console.Clear();
                        int groupID, teacherID, queueNum;
                        String lessonName;
                        Console.Write("Введiть ID групи: ");
                        groupID = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Введiть ID викладача: ");
                        teacherID = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Введiть назву предмета: ");
                        lessonName = Console.ReadLine();
                        Console.Write("Вкажiть номер пари: ");
                        queueNum = Convert.ToInt32(Console.ReadLine());
                        //Console.Write("Вкажiть день тижня: ");
                        Schedule schedule = new Schedule(groups[groupID], teachers[teacherID], lessonName, queueNum, DayOfWeek.Monday);
                        break;
                    case 3:
                        menuIsRunning = false;
                        break;
                }
            }
        }
    }
}
