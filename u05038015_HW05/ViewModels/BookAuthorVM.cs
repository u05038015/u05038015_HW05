using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using u05038015_HW05.Models;
using System.Web.Services.Description;

namespace u05038015_HW05.ViewModels
{
    public class BookAuthorVM
    {
        public List<Book> BookList { get; set; }
        public List<Author> AuthorList { get; set; }
        public List<types> TypeList { get; set; }
    }
}