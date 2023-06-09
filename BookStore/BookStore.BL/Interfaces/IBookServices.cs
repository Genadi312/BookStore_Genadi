using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Models.Models;
using BookStore.Models.Models.Requests.AddRequests;

namespace BookStore.BL.Interfaces
{
    public interface IBookServices
    {
        Task <IEnumerable<Book>> GetAll();

        Task <Book?> GetById(Guid id);

        Task Add(Book book);

        Task Update(Book book);

        Task Delete(Guid id);

    }
}
