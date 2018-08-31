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
        public void Remove<T> (List<T> listToRemove, int index)
        {
            listToRemove.RemoveAt(index);
        }

        // PRINTER
        public void Print<T>(List<T> listToPrint)
        {
            Console.ForegroundColor = ConsoleColor.White;
            int step = 0;
            foreach (T obj in listToPrint)
            {
                Console.WriteLine(step++ + obj.ToString() + "\n");
            }
            Console.ReadKey();
        }

        // FIND
        public void FindByParams()
        {
            Console.Clear();
            Console.Write("\t[ПОШУК]\n");
            Console.Write("1 - Пошук групи i розкладу по ID\n");
            Console.Write("2 - Пошук групи по назвi\n");
            Console.Write("3 - Пошук розкладiв по дню тижня\n");
            Console.Write("4 - Пошук розкладiв по викладачу\n");
            Console.Write("5 - Пошук розкладiв по предмету\n");

        }

        public void FindByID(int id)
        {
            Console.WriteLine("Розклад: " + schedules[id].ToString());
            Console.WriteLine("Група: " + groups[id].ToString());
            Console.ReadKey();
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
                        functional.Add(newGroup, groups);
                        break;
                    case 2:
                        Schedule newSchedule = new Schedule();
                        newSchedule.scheduleEditor();
                        functional.Add(newSchedule, schedules);
                        break;
                    case 3:
                        functional.Print(groups);
                        break;
                    case 4:
                        functional.Print(schedules);
                        break;
                    case 5:
                        Console.Write("Введiть ID групи: ");
                        functional.Remove(groups, Convert.ToInt32(Console.ReadLine()));
                        break;
                    case 6:
                        Console.Write("Введiть ID розкладу: ");
                        functional.Remove(schedules, Convert.ToInt32(Console.ReadLine()));
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
