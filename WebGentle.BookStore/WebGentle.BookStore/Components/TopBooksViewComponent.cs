using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGentle.BookStore.Repository;

namespace WebGentle.BookStore.Components
{
    public class TopBooksViewComponent : ViewComponent
    {
        private readonly IBookRepository _bookRepository;

        public TopBooksViewComponent(IBookRepository BookRepository)
        {
            _bookRepository = BookRepository; 
        }
        //Async Version sample
        public async Task<IViewComponentResult> InvokeAsync(int count)
        {
            var book = await _bookRepository.GetTopBooksAsync(count);
            return View(book);
        }

        //sync Version sample
        //public IViewComponentResult Invoke()
        //{
        //    return View();
        //}
    }
}
