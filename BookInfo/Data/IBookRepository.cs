﻿using BookInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace BookInfo.Data
{
    public interface IBookRepository
    {
        List<BookViewModel> GetAllBooks();
        Book GetBookByTitle(string title);
        Book GetBookById(int id);
        List<Book> GetBooksByAuthor(Author author);
        List<Author> GetAuthorsByBook(Book book);
        int AddBook(Book book);
        int Edit(Book book);
        int Delete(int id);
    }
}
