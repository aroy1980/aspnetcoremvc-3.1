﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGentle.BookStore.Models;

namespace WebGentle.BookStore.Repository
{
    public class BookRepository
    {
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
                 new BookModel() { Id = 1, Title = "MVC", Author = "Nitish" },
                 new BookModel() { Id = 2, Title = "C#", Author = "Monika" },
                 new BookModel() { Id = 3, Title = "Java", Author = "Tajul" },
                 new BookModel() { Id = 4, Title = "Php", Author = "Jashim" },
                 new BookModel() { Id = 5, Title = "Core", Author = "Nitish" },
            };

       
        }
    }
}
