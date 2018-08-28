using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TestTask.PersonFunctional;
using static TestTask.UniversityFunctional;

namespace TestTask
{
    class Schedule
    {
        public Group GroupID { get; set; }
        public Teacher TeacherID { get; set; }
        public String LessonName { get; set; }
        public int QueueNumber { get; set; }
        public DayOfWeek DayOfTheWeek { get; set; }

        public Schedule() { }

        public Schedule(Group _gID, Teacher _tID, String _lName, int _qNum, DayOfWeek day)
        {
            try
            {
                GroupID = _gID;
                TeacherID = _tID;
                _tID.ScheduleID = this;
                LessonName = _lName;
                QueueNumber = _qNum;
                DayOfTheWeek = day;
            }

            catch (Exception ex)
            {
                Console.WriteLine("!!! Error: " + ex.Message);
            }
        }

        public void scheduleEditor()
        {
            if (groups.Count == 0)
                throw new Exception("Спочатку створiть групу!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Введiть ID групи: ");
            GroupID = groups[Convert.ToInt32(Console.ReadLine())];
            Console.Write("Введiть ID викладача: ");
            TeacherID = teachers[Convert.ToInt32(Console.ReadLine())];
            Console.Write("Введiть назву предмета: ");
            LessonName = Console.ReadLine();
            Console.Write("Вкажiть номер пари: ");
            QueueNumber = Convert.ToInt32(Console.ReadLine());
            
            // ТУТ ОДНОЗНАНО МОЖНА ЗРОБИТИ ПРОСТІШЕ
            // ПОДУМАЙ
            // ПОДУМАЙ
            // ПОДУМАЙ
            Console.Write("Вкажiть день тижня (1-5): ");
            int dayReference = Convert.ToInt32(Console.ReadLine());
            switch (dayReference)
            {
                case 1:
                    DayOfTheWeek = DayOfWeek.Monday;
                    break;
                case 2:
                    DayOfTheWeek = DayOfWeek.Tuesday;
                    break;
                case 3:
                    DayOfTheWeek = DayOfWeek.Thursday;
                    break;
                case 4:
                    DayOfTheWeek = DayOfWeek.Thursday;
                    break;
                case 5:
                    DayOfTheWeek = DayOfWeek.Friday;
                    break;
                default:
                    throw new Exception("Неможливе значення дня тижня");
            }
            // ПОДУМАЙ
            // ПОДУМАЙ
            // ПОДУМАЙ
        }

        public void setNewTeacher(Teacher newTeacher)
        {
            TeacherID = newTeacher;
        }

        public override string ToString()
        {
            String infoStr = ": " + DayOfTheWeek + ", " + LessonName + ", " + QueueNumber + " пара\n" +
                "Викладач: " + TeacherID.FirstName + " " + TeacherID.LastName + "\n" +
                "Група: " + GroupID.GroupName;

            return infoStr;
        }
    }
}
