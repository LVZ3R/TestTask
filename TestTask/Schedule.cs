using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    class Schedule
    {
        public Group GroupID { get; set; }
        public Teacher TeacherID { get; set; }
        public String LessonName { get; set; }
        public int QueueNumber { get; set; }
        public DayOfWeek DayOfTheWeek { get; set; } 

        public Schedule(Group _gID, Teacher _tID, String _lName, int _qNum, DayOfWeek day)
        {
            GroupID = _gID;
            TeacherID = _tID;
            _tID.ScheduleID = this;
            LessonName = _lName;
            QueueNumber = _qNum;
            DayOfTheWeek = day;
        }

        public void setNewTeacher(Teacher newTeacher)
        {
            TeacherID = newTeacher;
        }
    }
}
