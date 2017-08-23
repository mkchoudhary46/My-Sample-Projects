using System;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using CRUD_AngularJs_ASPNET_MVC.Models;

namespace CRUD_AngularJs_ASPNET_MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new BaseModel
            {
                Environment = ConfigurationManager.AppSettings["Environment"],
                Version = ConfigurationManager.AppSettings["AppVersion"],
                EnableMinified = ConfigurationManager.AppSettings["EnableMinified"],
                SessionId = Session.SessionID,
                GaKey = ConfigurationManager.AppSettings["GaKey"],
                ScriptPath = ConfigurationManager.AppSettings["JobsScriptPath"],
                TemplatePath = ConfigurationManager.AppSettings["TemplatePath"]
            };

            if (!string.IsNullOrEmpty(model.Environment))
                model.CacheBuster = "?v=" + DateTime.Now.TimeOfDay;
            else
                model.CacheBuster = "?v=" + model.Version;
            return View(model);
        }

        [HttpGet]
        public JsonResult GetAllBooks()
        {
            using (BookDbContext contextObj = new BookDbContext())
            {
                var bookList = contextObj.Book.ToList();
                return Json(bookList, JsonRequestBehavior.AllowGet);
            }
        }
        //GET: Book by Id
        public JsonResult GetBookById(string id)
        {
            using (BookDbContext contextObj = new BookDbContext())
            {
                var bookId = Convert.ToInt32(id);
                var getBookById = contextObj.Book.Find(bookId);
                return Json(getBookById, JsonRequestBehavior.AllowGet);
            }
        }
        //Update Book
        public string UpdateBook(Book book)
        {
            if (book != null)
            {
                using (BookDbContext contextObj = new BookDbContext())
                {
                    int bookId = Convert.ToInt32(book.Id);
                    Book _book = contextObj.Book.FirstOrDefault(b => b.Id == bookId);
                    _book.Title = book.Title;
                    _book.Author = book.Author;
                    _book.Publisher = book.Publisher;
                    _book.Isbn = book.Isbn;
                    contextObj.SaveChanges();
                    return "Book record updated successfully";
                }
            }
            else
            {
                return "Invalid book record";
            }
        }
        // Add book
        public string AddBook(Book book)
        {
            if (book != null)
            {
                using (BookDbContext contextObj = new BookDbContext())
                {
                    contextObj.Book.Add(book);
                    contextObj.SaveChanges();
                    return "Book record added successfully";
                }
            }
            else
            {
                return "Invalid book record";
            }
        }
        // Delete book
        public string DeleteBook(string bookId)
        {

            if (!String.IsNullOrEmpty(bookId))
            {
                try
                {
                    int _bookId = Int32.Parse(bookId);
                    using (BookDbContext contextObj = new BookDbContext())
                    {
                        var _book = contextObj.Book.Find(_bookId);
                        contextObj.Book.Remove(_book);
                        contextObj.SaveChanges();
                        return "Selected book record deleted sucessfully";
                    }
                }
                catch (Exception)
                {
                    return "Book details not found";
                }
            }
            else
            {
                return "Invalid operation";
            }
        }

        public ActionResult Spicy()
        {
            return View();
        }
    }
}