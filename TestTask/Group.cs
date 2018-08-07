using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    class Group
    {
        public String GroupName { get; set; }
        public Teacher Curator { get; private set; }

        public Group(String _groupName, Teacher _curator)
        {
            GroupName = _groupName;
            Curator = _curator;
        }
    }
}
