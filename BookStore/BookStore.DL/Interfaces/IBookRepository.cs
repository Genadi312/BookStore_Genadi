using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Models.Base;

namespace BookStore.DL.Interfaces
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAll();

        Book GetById(int id);
        
        void Add(Book book);

        void Update(Book book);

        void Delete(int id);
    }
}
