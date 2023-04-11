using BookStore.Models.Models;
using BookStore.Models.Models.Requests;

namespace BookStore.BL.Interfaces
{
    public interface IAuthorServices
    {
        Task <IEnumerable<Author>> GetAll();

        Task <Author> GetById(Guid id);

        Task Add(AddAuthorRequest author);

        Task Update(UpdateAuthorRequest author);

        Task Delete(Guid id);

    }
}
