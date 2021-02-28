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
        public List<BookModel> GetAllBook()
        {
            return _bookRepository.GetAllBooks();
        }
        public BookModel GetBook(int id)
        {
            return _bookRepository.GetBookByID(id);

        }
         public List<BookModel> SearchBook(string title, string authorName)
        {
            return _bookRepository.SearchBook(title, authorName);
        }
    }
}
