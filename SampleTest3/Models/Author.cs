using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleTest3.Models
{
    public class Author
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public IEnumerable<Book> Books { get; set; }
    }
}