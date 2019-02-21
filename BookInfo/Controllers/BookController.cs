using System;
using Microsoft.AspNetCore.Mvc;
using BookInfo.Data;
using BookInfo.Models;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace BookInfo.Controllers
{
    // This class will be instantiated by the MVC framework or by a unit test
    [Route("api/[Controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private IBookRepository bookRepo;

        public BookController(IBookRepository bookRepo)
        {
            this.bookRepo = bookRepo;
        }

        /* Action Methods that get info from the database */

        [HttpGet]
        public ActionResult<IEnumerable<BookViewModel>> GetBooks()
        {
            var books = bookRepo.GetAllBooks();
            return books;
        }
        
        /* Action methods that modify the database */
   
        public ViewResult Add()
        {
            return View();
        }

        [HttpPost]
        public RedirectToActionResult Add(string title, string date, string author, string birthdate)
        {
            Book book = new Book { Title = title, Date = DateTime.Parse(date) };
            /* TODO: Fix the author stuff
            if (author != null)
            {
                book.Authors.Add(new Author { Name = author, Birthday = DateTime.Parse(birthdate)});
            }
            */

            bookRepo.AddBook(book);

            return RedirectToAction("Index");
        }

        [HttpPatch]
        public ViewResult Edit (int id)
        {
            return View(bookRepo.GetBookById(id));
        }

        [HttpPost]
        public RedirectToActionResult Edit(Book book)
        {
            bookRepo.Edit(book);
            return RedirectToAction("Index");                
        }

        public RedirectToActionResult Delete(int id)
        {
            bookRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
