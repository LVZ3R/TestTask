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
            if (sender == 5) teachers.RemoveAt(index);
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
    }
}
