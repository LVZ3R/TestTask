using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace TestTask
{
    class Person
    {
        private String firstName;
        private String lastName;

        public String FirstName
        {
            get
            {
                return firstName;
            }

            set
            {
                firstName = value;
            }
        }

        public String LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }

        public DateTime DateOfBirth { get; set; }
        public enum Gender
        {
            Чоловiк,
            Жiнка
        }
    }
}
