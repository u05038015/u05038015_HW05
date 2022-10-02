using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace u05038015_HW05.Models
{
    public class Book
    {
        public int BookID { get; set; }
        public string Name { get; set; }
        public int PageCount { get; set; }
        public int Point { get; set; }
        public string Author { get; set; }
        public string Type { get; set; }
    }
}