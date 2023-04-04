using BookStore.Models.Models;

namespace BookStore.DL.Interfaces
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAll();

        Task <Author> GetById(int id);

        Task Add(Author author);

        Task Update(Author author);

        Task Delete(int id);

    }
}
