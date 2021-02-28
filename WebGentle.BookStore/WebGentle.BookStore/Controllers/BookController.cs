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
        private readonly BookRepository _bookRepository=null;

        public BookController()
        {
            _bookRepository = new BookRepository();
        }
        public ViewResult GetAllBook()
        {
            var data = _bookRepository.GetAllBooks();
            return View();
        }
        public ViewResult GetBook(int id)
        {
            var data = _bookRepository.GetBookByID(id);
            return View();

        }
         public ViewResult SearchBook(string title, string authorName)
        {
            var data = _bookRepository.SearchBook(title, authorName);
            return View();
        }
    }
}
