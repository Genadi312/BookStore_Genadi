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

        Task <Book> GetById(int id);
        
        Task Add(Book book);

        Task Update(Book book);

        Task Delete(int id);

        Task <IEnumerable<Book>> GetAllByAuthorId(int authorId);

        Task <IEnumerable<Book>> GetAllBooksByReleaseDate(int releaseDate);
    }
}
