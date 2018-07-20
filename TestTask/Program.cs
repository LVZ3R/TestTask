using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Teacher> teachers = new List<Teacher>(0);
            List<Student> students = new List<Student>(0);

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
                Console.WriteLine("10 - Вихiд");
                try
                {
                    userChoise = Convert.ToInt32(Console.ReadLine());
                    switch (userChoise)
                    {
                        case 1:
                            Teacher newTeacher = new Teacher();
                            newTeacher.teacherEditor();
                            teachers.Add(newTeacher);
                            break;
                        case 2:
                            Student newStudent = new Student();
                            newStudent.studentEditor();
                            students.Add(newStudent);
                            break;
                        case 3:
                            Console.Clear();
                            for (int i = 0; i < teachers.Count; i++)
                            {
                                Console.WriteLine(i + " " + teachers[i].ToString() + "\n");
                            }
                            Console.ReadLine();
                            break;
                        case 4:
                            Console.Clear();
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
                            Console.WriteLine("Введiть ID викладача:");
                            teachers[Convert.ToInt32(Console.ReadLine())].teacherEditor();
                            break;
                        case 8:
                            Console.WriteLine("Введiть ID студента:");
                            students[Convert.ToInt32(Console.ReadLine())].studentEditor();
                            break;
                        case 9:
                            var sortedStudents = from s in students
                                                 orderby s.LastName ascending
                                                 select s;
                            int sID = 0;
                            foreach(Student s in sortedStudents)
                            {
                                Console.WriteLine(sID + s.ToString() + "\n");
                                sID++;
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
