using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using u05038015_HW05.Models;
using System.Data.SqlClient;
using System.EnterpriseServices;
using u05038015_HW05.ViewModels;

namespace u05038015_HW05.Controllers
{
    public class HomeController : Controller
    {
        DataService.DataServices dataObject = new DataService.DataServices();
        public static BookAuthorVM bookAuthor;
        public IActionResultController Index()
        {
            bookAuthor = new BookAuthorVM();
            bookAuthor.BookList = dataObject.getAllBooks();
            bookAuthor.AuthorList = dataObject.getAuthors();
            return View(bookAuthor);
        }

        public IActionResultController FuzzySearch(string searchText)
        {
            Book myBook;
            List<Book> books = new List<Book>();
            SqlCommand command;
            try
            {
                dataObject.openConnect();
                command = new SqlCommand("select bookid, books.name, au.surname as author, t.name as type, pagecount, point from books " +
                                     "inner join authors as au on au.authorId = books.authorId inner join types as t on t.typeId = books.typeId where books.name like '%" + searchText + "%' or " +
                                     "au.surname like '%" + searchText + "%' or t.name like '%" + searchText + "%'", dataObject.currConnect);
                using (SqlDataReader read = command.ExecuteReader())
                {
                    while (read.Read())
                    {
                        myBook = new Book();
                        myBook.BookID = (int)read["bookid"];
                        myBook.Name = (string)read["name"];
                        myBook.Author = (string)read["author"];
                        myBook.Type = (string)read["type"];
                        myBook.PageCount = (int)read["pagecount"];
                        myBook.Point = (int)read["point"];
                        books.Add(myBook);
                    }
                }
                dataObject.closeConnect();
            }
            catch
            {
                books.Clear();
            }
            finally
            {
                dataObject.closeConnect();
            }

            bookAuthor.BookList = books;
            return View("Index", bookAuthor);
        }
    }
}
