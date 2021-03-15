using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGentle.BookStore.Data;
using WebGentle.BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace WebGentle.BookStore.Repository
{
    public class LanguageRepository : ILanguageRepository
    {
        private BookStoreContext _context;

        public LanguageRepository(BookStoreContext context)
        {
            _context = context;
        }
        public async Task<List<LanguageModel>> GetAllLanguage()
        {
            return await _context.Language.Select(x => new LanguageModel()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description

            }).ToListAsync();

        }
    }
}
