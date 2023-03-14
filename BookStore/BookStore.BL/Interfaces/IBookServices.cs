using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Models.Models;

namespace BookStore.BL.Interfaces
{
    public interface IBookServices
    {
        IEnumerable<Book> GetAll();

        Book GetById(int id);

        void Add(Book book);

        void Update(Book book);

        void Delete(int id);

    }
}
