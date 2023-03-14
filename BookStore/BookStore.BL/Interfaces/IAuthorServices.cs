using BookStore.Models.Models;
using BookStore.Models.Models.Requests;

namespace BookStore.BL.Interfaces
{
    public interface IAuthorServices
    {
        IEnumerable<Author> GetAll();

        Author GetById(int id);

        void Add(AddAuthorRequest author);

        void Update(UpdateAuthorRequest author);

        void Delete(int id);

    }
}
