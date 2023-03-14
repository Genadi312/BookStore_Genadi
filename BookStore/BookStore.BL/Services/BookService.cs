using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.BL.Interfaces;
using BookStore.DL.Interfaces;
using BookStore.Models.Models;

namespace BookStore.BL.Services
{
    public class BookService : IBookServices
    {
        public readonly IBookRepository _bookRepository;


        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public void Add(Book book)
        {
            _bookRepository.Add(book);
        }

        public Book GetById(int id)
        {
            return _bookRepository.GetById(id);
        }

        public IEnumerable<Book> GetAll()
        {
            return _bookRepository.GetAll();
        }

        public void Update(Book book)
        {
            _bookRepository.Update(book);
        }

        public void Delete(int id)
        {
            _bookRepository.Delete(id);
        }
    }
}
