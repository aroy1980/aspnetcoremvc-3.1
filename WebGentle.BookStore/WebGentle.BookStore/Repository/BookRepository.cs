using Microsoft.EntityFrameworkCore;
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
        public async Task<int> AddNewBook(BookModel model)
        {
            var newBook = new Books
            {
                Author = model.Author,
                Description = model.Description,
             // Category = model.Category,
                CreatedOn=DateTime.UtcNow,
                Title=model.Title,
                LanguageId=model.LanguageId,

                TotalPages = model.TotalPages.HasValue?model.TotalPages.Value:0,
                UpdatedOn=DateTime.UtcNow,
                CoverImagePath = model.CoverImagePath,
                BookPdfUrl = model.BookPdfUrl
                
            };
            newBook.BookGallery = new List<BookGallery>();
            foreach (var file in model.Gallery)
            {

                newBook.BookGallery.Add(new BookGallery()
                {
                    Name=file.Name,
                    URL = file.URL
                });
            }

            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();
            return newBook.Id;
            
        }
        public async Task<List<BookModel>> GetAllBooks()
        {
            var books = new List<BookModel>();
            
            var allBooks =await _context.Books.ToListAsync();
            if (allBooks.Any() == true)
            {
                foreach (var book in allBooks)
                {
                    books.Add(new BookModel()
                    {
                        Author = book.Author,
                        Category = book.Category,
                        Id=book.Id,
                        Description=book.Description,
                        Title=book.Title,
                        LanguageId=book.LanguageId,
                   //     Language = book.Language.Name,
                        TotalPages=book.TotalPages,
                        CoverImagePath = book.CoverImagePath,

                    });

                }
            }

            return books;
        }
        public async Task<BookModel> GetBookByID(int id)
        {
            return await _context.Books.Where(x => x.Id == id).Select(book => new BookModel()
            {
                Author = book.Author,
                Category = book.Category,
                Id = book.Id,
                Description = book.Description,
                Title = book.Title,
                LanguageId = book.LanguageId,
                Language = book.Language.Name,
                TotalPages = book.TotalPages,
                CoverImagePath = book.CoverImagePath,
                Gallery = book.BookGallery.Select(g=> new GalleryModel() 
                {
                    Id=g.Id,
                    Name=g.Name,
                    URL=g.URL
                }).ToList(),
                BookPdfUrl = book.BookPdfUrl
            }).FirstOrDefaultAsync();
          
            }
            // var book= _context.Books.Where(x => x.Id == id).FirstOrDefault();
          
        }

        //public List<BookModel> SearchBook(string title,string authorName)
        //{
        //    return null;// DataSource().Where(x => x.Title.Contains(title) || x.Author.Contains(authorName)).ToList();
        //}
        //private List<BookModel> DataSource()
        //{
        //    return new List<BookModel>()
        //    {
        //         //new BookModel() { Id = 1, Title = "MVC", Author = "Nitish", Description="This is a Very good book of MVC", Category="Programming",Language="English",TotalPages=458 },
        //         //new BookModel() { Id = 2, Title = "C#", Author = "Monika" , Description="This is a Very good book of MVC", Category="Programming",Language="English",TotalPages=4589},
        //         //new BookModel() { Id = 3, Title = "Java", Author = "Tajul" , Description="This is a Very good book of MVC", Category="Programming",Language="English",TotalPages=847},
        //         //new BookModel() { Id = 4, Title = "Php", Author = "Jashim" , Description="This is a Very good book of MVC", Category="Programming",Language="English",TotalPages=544},
        //         //new BookModel() { Id = 5, Title = "Core", Author = "Nitish" , Description="This is a Very good book of MVC", Category="Programming",Language="English",TotalPages=966},
        //         // new BookModel() { Id = 6, Title = "Azure DevOps", Author = "Avijit" , Description="This is a Very good book of Azure DevOps", Category="Programming",Language="English",TotalPages=1025},
        //    };

       
        }
    

