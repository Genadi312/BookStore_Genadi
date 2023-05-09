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
        Task <IEnumerable<Book>> GetAll();

        Task <Book?> GetById(Guid id);

        Task <Book?>Add(Book author);

        Task Update(Book book);

        Task Delete(Guid id);

    }
}
