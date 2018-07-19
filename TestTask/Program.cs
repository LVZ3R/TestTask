using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*  Пофиксить индексы
 *  Дописать эдиты для преподователей и студентов
 *  Доделать удаление
*/
namespace TestTask
{
    public class Person
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public enum Gender
        {
            Чоловiк,
            Жiнка
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Teacher> teachers = new List<Teacher>(0);
            List<Student> students = new List<Student>(0);
            int teacherID = 0, studentID = 0;

            int userChoise;
            bool appIsRunning = true;

            while (appIsRunning)
            {
                Console.Clear();
                Console.WriteLine("1 - Додати нового викладача [DONE]");
                Console.WriteLine("2 - Додати нового студента [DONE]");
                Console.WriteLine("3 - Вивести всiх викладачiв [DONE]");
                Console.WriteLine("4 - Вивести всiх студентiв [DONE]");
                Console.WriteLine("5 - Видалити викладача [DONE]");
                Console.WriteLine("6 - Видалити студента [DONE]");
                Console.WriteLine("7 - Вiдредагувати данi викладача [WORKING ON]");
                Console.WriteLine("8 - Вiдредагувати данi студента [WORKING ON]");
                Console.WriteLine("9 - Вивести список студентiв в алфавiтному порядку [DONE]");
                Console.WriteLine("10 - Вихiд");
                try
                {
                    userChoise = Convert.ToInt32(Console.ReadLine());
                    switch (userChoise)
                    {
                        case 1:
                            Teacher newTeacher = new Teacher();
                            newTeacher.teacherEditor(teacherID);
                            teachers.Add(newTeacher);
                            teacherID++;
                            break;
                        case 2:
                            Student newStudent = new Student();
                            newStudent.studentEditor(studentID);
                            students.Add(newStudent);
                            studentID++;
                            break;
                        case 3:
                            for (int i = 0; i < teachers.Count; i++)
                            {
                                Console.WriteLine(i + " " + teachers[i].ToString() + "\n");
                            }
                            Console.ReadLine();
                            break;
                        case 4:
                            for (int i = 0; i < students.Count; i++)
                            {
                                Console.WriteLine(i + " " + students[i].ToString() + "\n");
                            }
                            Console.ReadLine();
                            break;
                        case 5:
                            Console.WriteLine("Введiть ID викладача:");
                            teachers.RemoveAt(Convert.ToInt32(Console.ReadLine()));
                            break;
                        case 6:
                            Console.WriteLine("Введiть ID студента:");
                            students.RemoveAt(Convert.ToInt32(Console.ReadLine()));
                            break;
                        case 7:
                            //TODO
                            break;
                        case 8:
                            //TODO
                            break;
                        case 9:
                            var sortedStudents = from s in students
                                                 orderby s.LastName ascending
                                                 select s;
                            foreach(Student s in sortedStudents)
                            {
                                Console.WriteLine(s.iD + " " + s.ToString() + "\n");
                            }
                            Console.ReadLine();
                            break;
                        case 10:
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
