using BookStore.Models.Base;

namespace BookStore.DL.Interfaces
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> GetAll();

        Author GetById(int id);

        void Add(Author author);
    }
}
