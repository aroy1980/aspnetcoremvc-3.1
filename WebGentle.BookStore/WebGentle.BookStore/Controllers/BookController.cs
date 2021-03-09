using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebGentle.BookStore.Models;
using WebGentle.BookStore.Repository;

namespace WebGentle.BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly  BookRepository _bookRepository;
        private readonly LanguageRepository _languageRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BookController(BookRepository bookRepository,LanguageRepository languageRepository, IWebHostEnvironment webHostEnvironment)
        {
            _bookRepository = bookRepository;
            _languageRepository = languageRepository;
            _webHostEnvironment = webHostEnvironment;

        }
        public async Task<ViewResult> GetAllBook()
        {
            var data = await _bookRepository.GetAllBooks();
            return View(data);
        }
        public async Task<ViewResult> GetBook(int id)
        {
            var data = await _bookRepository.GetBookByID(id);
            return View(data);

        }
        // public ViewResult SearchBook(string title, string authorName)
        //{
        //    var data = _bookRepository.SearchBook(title, authorName);
        //    return View();
        //}
        public async Task<ViewResult> AddNewBook(bool isSuccess = false, int bookId=0)
        {
            var book = new BookModel()
            { //Language = "Hindi" 
            };
            //ViewBag.Language = GetLanuage().Select(x => new SelectListItem()
            //{
            //    Text = x.Text,
            //    Value = x.Id.ToString()
            //}).ToList();
            //var group1 = new SelectListGroup() { Name = "Group 1" };
            //var group2 = new SelectListGroup() { Name = "Group 2" };
            //var group3= new SelectListGroup() { Name = "Group 3" };

            //ViewBag.Language = new List<SelectListItem>()
            //{
            //    new SelectListItem(){Text="Hindi",Value="1",Group=group1},
            //    new SelectListItem(){Text="English",Value="2",Group=group1},
            //    new SelectListItem(){Text="Dutch",Value="3",Group=group2,Disabled=true},
            //     new SelectListItem(){Text="Bangla",Value="4",Group=group2 },
            //      new SelectListItem(){Text="Tamil",Value="5",Group=group3},
            //       new SelectListItem(){Text="Urdu",Value="6",Group=group3},

            //};
            //ViewBag.Language = new SelectList(GetLanuage(), "Id", "Text", 2);
            ViewBag.language = new SelectList( await _languageRepository.GetAllLanguage(),"Id","Name");
            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View(book);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookModel)
        {
            if (ModelState.IsValid)
            {
                if(bookModel.CoverPhoto!=null)
                {
                    string folder = "Books/Cover/";
                    folder += Guid.NewGuid().ToString()+"_"+bookModel.CoverPhoto.FileName ;
                    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath,folder);
                   await bookModel.CoverPhoto.CopyToAsync(new FileStream(serverFolder, FileMode.Create)); 
                }
                int id = await _bookRepository.AddNewBook(bookModel);
                if (id > 0)
                    
                    return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, bookId = id });
                }
              
            
            ViewBag.language = new SelectList(await _languageRepository.GetAllLanguage(), "Id", "Name");

            //ViewBag.Language = GetLanuage().Select(x => new SelectListItem()
            //{
            //    Text = x.Text,
            //    Value = x.Id.ToString()
            //}).ToList();
            return View();
        }
        private List<LanguageModel> GetLanuage()
        {
            return new List<LanguageModel>()
            {
                //new LanguageModel(){Id=1, Text="Hindi is one of the sweetest Language"},
                //new LanguageModel(){Id=2, Text="Englist is the global Language"},
                //new LanguageModel(){Id=3,Text="Dutch is hard to learn"}
            };
        }
    }
}
