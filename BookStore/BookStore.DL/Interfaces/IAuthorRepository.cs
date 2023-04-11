using BookStore.Models.Models;

namespace BookStore.DL.Interfaces
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAll();

        Task <Author> GetById(Guid id);

        Task Add(Author author);

        Task Update(Author author);

        Task Delete(Guid id);

    }
}
