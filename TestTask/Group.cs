using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TestTask.PersonFunctional;

namespace TestTask
{
    class Group
    {
        public String GroupName { get; set; }
        public Teacher Curator { get; private set; }

        public Group() { }

        public Group(String _groupName, Teacher _curator)
        {
            try
            {
                GroupName = _groupName;
                Curator = _curator;
            }

            catch (Exception ex)
            {
                Console.WriteLine("!!! Error: " + ex.Message);
            }
        }

        public void groupEditor()
        {
            if (teachers.Count == 0)
                throw new Exception("Спочатку створiть викладача!");
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Введiть назву групи: ");
            GroupName = Console.ReadLine();
            Console.Write("Введiть ID куратора: ");
            Curator = teachers[Convert.ToInt32(Console.ReadLine())];
        }

        public override string ToString()
        {
            String infoStr = ": " + GroupName + ", куратор: " + Curator.FirstName + " " + Curator.LastName;

            return infoStr;
        }
    }
}
