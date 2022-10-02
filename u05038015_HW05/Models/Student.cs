using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace u05038015_HW05.Models
{
    public class Student
    {
        public int StudID { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Class { get; set; }
        public int Point { get; set; }
    }
}