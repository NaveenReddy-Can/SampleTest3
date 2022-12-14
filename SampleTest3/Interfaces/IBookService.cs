using SampleTest3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleTest3.Interfaces
{
    internal interface IBookService
    {
        Book GetBookById(int id);

        IEnumerable<Book> GetBooks();
    }
}
