using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Models.Models;

namespace BookStore.DL.Interfaces
{
    public interface IBookRepository
    {
        Task <IEnumerable<Book>> GetAll();

        Task <Book?> GetById(Guid id);
        
        Task Add(Book book);

        Task Update(Book book);

        Task Delete(Guid id);

        Task <IEnumerable<Book>> GetAllByAuthorId(Guid authorId);

        //Task <IEnumerable<Book>> GetAllBooksByReleaseDate(int releaseDate);
    }
}
