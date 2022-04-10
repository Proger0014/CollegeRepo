using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringType.WinForms.Models
{
    public class Person
    {
        public Person(string firstName, string phone)
        {
            FirstName = firstName;
            Phone = phone;
        }

        public string FirstName { get; set; }
        public string Phone { get; set; }
    }
}
