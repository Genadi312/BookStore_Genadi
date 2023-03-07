using BookStore.DL.Interfaces;
using BookStore.Models.Models;

namespace BookStore.DL.Repositories.InMemoriesRepositories
{
    public class AuthorInMemoryRepository : IAuthorRepository
    {
        void IAuthorRepository.Add(Author author)
        {
            InMemoryDb.InMemoryDb.Authors.Add(author);
        }

        void IAuthorRepository.Delete(int id)
        {
            var author = InMemoryDb.InMemoryDb.Authors.FirstOrDefault(x => x.Id == id);

            if(author != null)
            {
            InMemoryDb.InMemoryDb.Authors.Remove(author);
            }
        }

        IEnumerable<Author> IAuthorRepository.GetAll()
        {
            return InMemoryDb.InMemoryDb.Authors;
        }

        Author IAuthorRepository.GetById(int id)
        {
            return InMemoryDb.InMemoryDb.Authors.SingleOrDefault(x => x.Id == id);
        }

        void IAuthorRepository.Update(Author author)
        {
            var authorForUpdate = InMemoryDb.InMemoryDb.Authors.FirstOrDefault(x => x.Id == author.Id);

            if (authorForUpdate != null)
            {
                authorForUpdate.Name = author.Name;
            }
        }
    }
}
