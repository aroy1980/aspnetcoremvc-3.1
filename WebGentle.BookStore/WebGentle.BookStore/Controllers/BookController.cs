using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGentle.BookStore.Models;
using WebGentle.BookStore.Repository;

namespace WebGentle.BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository;

        public BookController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;

        }
        public ViewResult GetAllBook()
        {
            var data = _bookRepository.GetAllBooks();
            return View(data);
        }
        public ViewResult GetBook(int id)
        {
            var data = _bookRepository.GetBookByID(id);
            return View(data);

        }
         public ViewResult SearchBook(string title, string authorName)
        {
            var data = _bookRepository.SearchBook(title, authorName);
            return View();
        }
        public ViewResult AddNewBook(bool isSuccess = false, int bookId=0)
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View();
        }
        [HttpPost]
        public IActionResult AddNewBook(BookModel bookModel)
        {
            int id=_bookRepository.AddNewBook(bookModel);
            if(id>0)
            {
                return RedirectToAction(nameof(AddNewBook),new { isSuccess=true ,bookId=id});
            }
            return View(); 
        }
    }
}
