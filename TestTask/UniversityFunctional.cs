using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TestTask.PersonFunctional;

namespace TestTask
{
    class UniversityFunctional : IFunctional
    {
        public static List<Schedule> schedules = new List<Schedule>(0);
        public static List<Group> groups = new List<Group>(0);

        // ADDER
        public void Add(object value)
        {
            Console.Clear();
            if (value.GetType() == typeof(Group))
            {

                groups.Add(value as Group);
            }
            else
                if (value.GetType() == typeof(Schedule))
            {
                schedules.Add(value as Schedule);
            }
            else
                throw new Exception("Непередбачена помилка");
        }

        // EDITOR
        public void Edit(int sender, int index)
        {
            if (sender == 7)
            {
                groups[index].groupEditor();
            }
            else
                if (sender == 8)
            {
                schedules[index].scheduleEditor();
            }
            else
                throw new Exception("Непередбачений збiй в виконаннi функцiї Edit");
        }

        // REMOVER
        public void Remove(int sender, int index)
        {
            if (sender == 5)
            {
                groups.RemoveAt(index);
            }
            else if (sender == 6) schedules.RemoveAt(index);
            else
                throw new Exception("Непередбачена помилка при здiйсненнi видалення");
        }

        // PRINTER
        public void Print(int sender)
        {
            Console.ForegroundColor = ConsoleColor.White;
            int step = 0;
            if (sender == 3)
            {
                foreach (Group g in groups)
                {
                    Console.WriteLine(step++ + g.ToString() + "\n");
                }
            }
            else
                if (sender == 4)
            {
                foreach (Schedule s in schedules)
                {
                    Console.WriteLine(step++ + s.ToString() + "\n");
                }
            }
            else
                throw new Exception("Помилка при виведеннi");

            Console.ReadKey();
        }

        // FIND
        public void FindByParams()
        {

        }

        public void FindByID(int id)
        {

        }
        
        // UNIVERSITY MENU
        public static void UniversityMenu(UniversityFunctional functional)
        {
            int userChoise = 0;
            bool menuIsRunning = true;
            while (menuIsRunning)
            {
                Console.Clear();
                Console.WriteLine("\t[ГРУПИ]\t\t\t\t[РОЗКЛАДИ]");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("1 - Додати нову групу\t\t");
                Console.Write("2 - Додати новий розклад\n");
                Console.Write("3 - Вивести всi групи\t\t");
                Console.Write("4 - Вивести всi розклади\n");
                Console.Write("5 - Видалити групу\t\t");
                Console.Write("6 - Видалити розклад\n");
                Console.Write("7 - Редагувати групу\t\t");
                Console.Write("8 - Редагувати розклад\n\n");
                Console.Write("9 - Вихiд з меню\n\n-> ");
                userChoise = Convert.ToInt32(Console.ReadLine());

                switch (userChoise)
                {
                    case 1:
                        Group newGroup = new Group();
                        newGroup.groupEditor();
                        functional.Add(newGroup);
                        break;
                    case 2:
                        Schedule newSchedule = new Schedule();
                        newSchedule.scheduleEditor();
                        functional.Add(newSchedule);
                        break;
                    case 3:
                        functional.Print(3);
                        break;
                    case 4:
                        functional.Print(4);
                        break;
                    case 5:
                        Console.Write("Введiть ID групи: ");
                        functional.Remove(5, Convert.ToInt32(Console.ReadLine()));
                        break;
                    case 6:
                        Console.Write("Введiть ID розкладу: ");
                        functional.Remove(6, Convert.ToInt32(Console.ReadLine()));
                        break;
                    case 7:
                        Console.Write("Введiть ID групи: ");
                        functional.Edit(7, Convert.ToInt32(Console.ReadLine()));
                        break;
                    case 8:
                        Console.Write("Введiть ID групи: ");
                        functional.Edit(8, Convert.ToInt32(Console.ReadLine()));
                        break;
                    case 9:
                        menuIsRunning = false;
                        break;
                }
            }
        }
    }
}
