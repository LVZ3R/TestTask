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

        // ADDERS
        public static void teacherAdder()
        {
            Teacher newTeacher = new Teacher();
            newTeacher.teacherEditor();
            teachers.Add(newTeacher);
        }
        public static void studentAdder()
        {
            Student newStudent = new Student();
            newStudent.studentEditor();
            students.Add(newStudent);
        }

        // PRINTERS
        public static void teacherPrinter()
        {
            Console.Clear();
            for (int i = 0; i < teachers.Count; i++)
            {
                Console.WriteLine(i + " " + teachers[i].ToString() + "\n");
            }
            Console.ReadLine();
        }
        public static void studentPrinter()
        {
            Console.Clear();
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine(i + " " + students[i].ToString() + "\n");
            }
            Console.ReadLine();
        }

        // REMOVE
        public static void removeTeacher()
        {
            Console.WriteLine("Введiть ID викладача:");
            teachers.RemoveAt(Convert.ToInt32(Console.ReadLine()));
        }
        public static void removeStudent()
        {
            Console.WriteLine("Введiть ID студента:");
            students.RemoveAt(Convert.ToInt32(Console.ReadLine()));
        }

        // EDITORS
        public static void editTeacher()
        {
            Console.WriteLine("Введiть ID викладача:");
            teachers[Convert.ToInt32(Console.ReadLine())].teacherEditor();
        }
        public static void editStudent()
        {
            Console.WriteLine("Введiть ID студента:");
            students[Convert.ToInt32(Console.ReadLine())].studentEditor();
        }
    }
}
