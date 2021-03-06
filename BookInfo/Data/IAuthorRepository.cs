﻿using BookInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookInfo.Data
{
    public interface IAuthorRepository
    {
        List<Author> GetAuthorsByBook(Book book);
        List<Author> GetAllAuthors();
        Author GetAuthorByName(string name);
        Author GetAuthorById(int id);
        int Add(Author author);
        int Edit(Author author);
        int Delete(int id);

    }
}
