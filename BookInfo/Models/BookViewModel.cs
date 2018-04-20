using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookInfo.Models
{
    public class BookViewModel
    {
        public Book TheBook { get; set; }
        public Author TheAuthor { get; set; }
    }
}
