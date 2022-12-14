using SampleTest3.Interfaces;
using SampleTest3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleTest3.Services
{
    public class BookService : IBookService
    {
        private ApplicationDbContext context;

        public BookService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Book GetBookById(int id)
        {
            return context.Books.Find(id);
        }

        public IEnumerable<Book> GetBooks()
        {
            return context.Books;
        }
    }
}