using SampleTest3.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using System.Web.Mvc;

namespace SampleTest3.Models
{
    public class Book
    {
        public int Id { get; set; }

        // TEST NOTE: Add the remote attribute on the Title property to use the 'NoDigits' action
        [Remote("NoDigits", "Books", ErrorMessage = "Book title is not valid!")]
        public string Title { get; set; }
        
        [IsPositiveNumber]
        public double  Cost { get; set; }
        
        public Author Author { get; set; }
    }
}