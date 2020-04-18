﻿using System;
using Business.Abstract;
using DataAccess.Abstract;
using Entitites.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class BookManager : IBookService
    {
        private IBookDal _bookDal;

        public BookManager(IBookDal bookDal)
        {
            _bookDal = bookDal;
        }
        public void Add(Book book)
        {
            if (_bookDal.Get(b=>b.Name==book.Name)==null)
            {
                _bookDal.Add(book);

            }
            else
            {
                throw new Exception("Bu isimde bir kitap zaten var.");

            }
        }

        public void Delete(Book book)
        {
            _bookDal.Delete(book);
        }

        public List<Book> GetAll()
        {
            return _bookDal.GetList().ToList();
        }

        public List<Book> GetByAuthorId(int id)
        {
            return _bookDal.GetList(b => b.AuthorId == id).ToList();
        }

        public Book GetById(int id)
        {
            return _bookDal.Get(b => b.Id == id);
        }

        public void Update(Book book)
        {
           _bookDal.Update(book);
        }
    }
}
