using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading.Tasks;
using u05038015_HW05.Models;

namespace u05038015_HW05.DataService
{
    public class DataServices
    {
        private static DataServices instance;
        private SqlConnectionStringBuilder stringBuilder;
        public SqlConnection currConnect;
        public string getConnectionString()
        {
            stringBuilder = new SqlConnectionStringBuilder();
            stringBuilder["Data Source"] = "DESKTOP - SQ47H7K\\SQLEXPRESS";
            stringBuilder["Initial Catalog"] = "Library";
            stringBuilder["Integrated Security"] = "True";
            return stringBuilder.ToString();
        }

        public bool openConnect()
        {
            bool status = true;
            try
            {
                currConnect = new SqlConnection(getConnectionString());
                currConnect.Open();
            }
            catch { status = false; }

            return status;
        }
        public bool closeConnect()
        {
            bool status = true;
            try
            {
                if (openConnect() == true)
                {
                    currConnect.Close();
                }
            }
            catch { status = false; }

            return status;
        }

        public List<Book> getAllBooks()
        {
            List<Book> books = new List<Book>();
            SqlCommand command;
            try
            {
                openConnect();
                command = new SqlCommand("select bookid, books.name, au.surname as author, t.name as type, pagecount, point from books " +
                                     "inner join authors as au on au.authorId = books.authorId inner join types as t on t.typeId = books.typeId", currConnect);
                using (SqlDataReader read = command.ExecuteReader())
                {
                    while (read.Read())
                    {
                        Book myBook = new Book();
                        myBook.BookID = (int)read["bookid"];
                        myBook.Name = (string)read["name"];
                        myBook.Author = (string)read["author"];
                        myBook.Type = (string)read["type"];
                        myBook.PageCount = (int)read["pagecount"];
                        myBook.Point = (int)read["point"];
                        books.Add(myBook);
                    }
                }
                closeConnect();
            }
            catch { books.Clear(); }

            finally { closeConnect(); }

            return books;
        }

        public List<types> getTypes()
        {
            List<types> types = new List<types>();
            SqlCommand command;
            try
            {
                openConnect();

                command = new SqlCommand("select name from types", currConnect);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        types myTypes = new types();
                        myTypes.Name = (string)reader["name"];

                        types.Add(myTypes);
                    }
                }
                closeConnect();
            }
            catch
            {
                types.Clear();
            }

            finally
            {
                closeConnect();
            }
            return types;
        }

        public List<Author> getAuthors()
        {
            List<Author> authors = new List<Author>();
            SqlCommand command;
            try
            {
                openConnect();

                command = new SqlCommand("select authorid, name, surname from authors", currConnect);

                using (SqlDataReader reading = command.ExecuteReader())
                {
                    while (reading.Read())
                    {
                        Author myAuthor = new Author();
                        myAuthor.AuthorID = (int)reading["authorid"];
                        myAuthor.Name = (string)reading["name"];
                        myAuthor.Surname = (string)reading["surname"];
                        authors.Add(myAuthor);
                    }
                }
                closeConnect();
            }
            catch
            {
                authors.Clear();
            }

            finally
            {
                closeConnect();
            }

            return authors;
        }


        public List<Student> getStudents()
        {
            List<Student> StudentList = new List<Student>();

            SqlCommand command;

            try
            {
                openConnect();

                command = new SqlCommand("select studentId, name, surname , birthdate, gender, class, point from students", currConnect);

                using (SqlDataReader read = command.ExecuteReader())
                {
                    while (read.Read())
                    {
                        Student myStudents = new Student();

                        myStudents.StudID = (int)read["studentId"];
                        myStudents.Name = (string)read["name"];
                        myStudents.Surname = (string)read["surname"];
                        myStudents.BirthDate = (DateTime)read["birthdate"];
                        myStudents.Gender = (string)read["gender"];
                        myStudents.Class = (string)read["class"];
                        myStudents.Point = (int)read["point"];

                        StudentList.Add(myStudents);
                    }
                }
                closeConnect();
            }
            catch
            {
                StudentList.Clear();
            }

            finally
            {
                closeConnect();
            }

            return StudentList;
        }

        public List<Borrow> getBorrowBooks()
        {
            List<Borrow> BorrowList = new List<Borrow>();

            SqlCommand command;

            try
            {
                openConnect();

                command = new SqlCommand("select borrowId, takenDate, broughtDate from borrows", currConnect);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Borrow borrowedBooks = new Borrow();

                        borrowedBooks.BorrowID = (int)reader["borrowId"];
                        borrowedBooks.TakenDate = (DateTime)reader["takenDate"];
                        borrowedBooks.BroughtDate = (DateTime)reader["broughtDate"];

                        BorrowList.Add(borrowedBooks);
                    }
                }
                closeConnect();
            }
            catch
            {
                BorrowList.Clear();
            }

            finally
            {
                closeConnect();
            }
            return BorrowList;
        }

        public List<Student> getClass()
        {
            List<Student> classesList = new List<Student>();
            SqlCommand command;
            try
            {
                openConnect();
                command = new SqlCommand("select class from students", currConnect);

                using (SqlDataReader reading = command.ExecuteReader())
                {
                    while (reading.Read())
                    {
                        Student myClass = new Student();
                        myClass.Class = (string)reading["class"];

                        classesList.Add(myClass);
                    }
                }
                closeConnect();
            }
            catch
            {
                classesList.Clear();
            }

            finally
            {
                closeConnect();
            }
            return classesList;
        }
    }
}