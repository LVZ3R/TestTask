using System;
using System.Collections.Generic;
using System.Linq;
using static TestTask.PersonFunctional;
using static TestTask.UniversityFunctional;

namespace TestTask
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonFunctional pFunctional = new PersonFunctional();
            UniversityFunctional uFunctional = new UniversityFunctional();

            Console.ForegroundColor = ConsoleColor.White;
            int userChoise;
            bool appIsRunning = true;

            while (appIsRunning)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\t[ЛЮДИ]\t\t\t\t\t[УНIВЕРСИТЕТ]");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("1 - Меню для роботи з людьми\t\t");
                Console.Write("2 - Меню для роботи з предметами\n\n");
                Console.Write("3 - Вихiд\n\n-> ");
                Console.ForegroundColor = ConsoleColor.White;
                try
                {
                    userChoise = Convert.ToInt32(Console.ReadLine());
                    switch (userChoise)
                    {
                        case 1:
                            PersonMenu(pFunctional);
                            break;
                        case 2:
                            UniversityMenu(uFunctional);
                            break;
                        case 3:
                            appIsRunning = false;
                            break;
                    }
                }

                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
    }
}
