using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGentle.BookStore.Data;
using WebGentle.BookStore.Models;

namespace WebGentle.BookStore.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _context;

        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }
        public int AddNewBook(BookModel model)
        {
            var newBook = new Books
            {
                Author = model.Author,
                Description = model.Description,
               // Category = model.Category,
                 CreatedOn=DateTime.UtcNow,
                   Title=model.Title,
                  //  Language=model.Language,
                     TotalPages = model.TotalPages,
                     UpdatedOn=DateTime.UtcNow
                
            };
            _context.Books.Add(newBook);
            _context.SaveChanges();
            return newBook.Id;
        }
        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }
        public BookModel GetBookByID(int id)
        {
            return DataSource().Where(x => x.Id == id).FirstOrDefault();
        }

        public List<BookModel> SearchBook(string title,string authorName)
        {
            return DataSource().Where(x => x.Title.Contains(title) || x.Author.Contains(authorName)).ToList();
        }
        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                 new BookModel() { Id = 1, Title = "MVC", Author = "Nitish", Description="This is a Very good book of MVC", Category="Programming",Language="English",TotalPages=458 },
                 new BookModel() { Id = 2, Title = "C#", Author = "Monika" , Description="This is a Very good book of MVC", Category="Programming",Language="English",TotalPages=4589},
                 new BookModel() { Id = 3, Title = "Java", Author = "Tajul" , Description="This is a Very good book of MVC", Category="Programming",Language="English",TotalPages=847},
                 new BookModel() { Id = 4, Title = "Php", Author = "Jashim" , Description="This is a Very good book of MVC", Category="Programming",Language="English",TotalPages=544},
                 new BookModel() { Id = 5, Title = "Core", Author = "Nitish" , Description="This is a Very good book of MVC", Category="Programming",Language="English",TotalPages=966},
                  new BookModel() { Id = 6, Title = "Azure DevOps", Author = "Avijit" , Description="This is a Very good book of Azure DevOps", Category="Programming",Language="English",TotalPages=1025},
            };

       
        }
    }
}
