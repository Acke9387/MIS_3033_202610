using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Intro_to_JSON
{
    public class Employee
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string gender { get; set; }
        public string ip_address { get; set; }
        public string city { get; set; }

        public Employee()
        {
            id = 0;
            first_name = string.Empty;
            last_name = string.Empty;
            email = string.Empty;
            gender = string.Empty;
            ip_address = string.Empty;
            city = string.Empty;
        }

    }
}
