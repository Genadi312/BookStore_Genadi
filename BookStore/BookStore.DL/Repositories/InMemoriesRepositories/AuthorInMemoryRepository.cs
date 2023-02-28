using BookStore.DL.Interfaces;
using BookStore.Models.Base;

namespace BookStore.DL.Repositories.InMemoriesRepositories
{
    public class AuthorInMemoryRepository : IAuthorRepository
    {
        void IAuthorRepository.Add(Author author)
        {
            InMemoryDb.InMemoryDb.Authors.Add(author);
        }

        IEnumerable<Author> IAuthorRepository.GetAll()
        {
            return InMemoryDb.InMemoryDb.Authors;
        }

        Author IAuthorRepository.GetById(int id)
        {
            return InMemoryDb.InMemoryDb.Authors.SingleOrDefault(x => x.Id == id);
        }
    }
}
