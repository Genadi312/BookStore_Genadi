using BookStore.Models.Models;

namespace BookStore.DL.Interfaces
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> GetAll();

        Author GetById(int id);

        void Add(Author author);

        void Update(Author author);

        void Delete(int id);

    }
}
