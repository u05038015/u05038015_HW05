using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace u05038015_HW05.Models
{
    public class Borrow
    {
        public int BorrowID { get; set; }
        public int StudentID { get; set; }
        public int BookID { get; set; }
        public DateTime TakenDate { get; set; }
        public DateTime BroughtDate { get; set; }
    }
}