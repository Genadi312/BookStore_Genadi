using BookStore.Models.Base;

namespace BookStore.BL.Interfaces
{
    public interface IAuthorServices
    {
        IEnumerable<Author> GetAll();

        Author GetById(int id);

        void Add(Author author);
    }
}
