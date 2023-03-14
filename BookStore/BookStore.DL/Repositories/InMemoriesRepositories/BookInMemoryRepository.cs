using BookStore.DL.Interfaces;
using BookStore.Models.Models;

namespace BookStore.DL.Repositories.InMemoriesRepositories
{
    public class BookInMemoryRepository : IBookRepository
    {
        
        void IBookRepository.Add(Book book)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Book> IBookRepository.GetAll()
        {
            return InMemoryDb.InMemoryDb.Books;
        }
        Book IBookRepository.GetById(int id)
        {
            return InMemoryDb.InMemoryDb.Books.SingleOrDefault(x => x.Id == id);
        }
        void IBookRepository.Delete(int id)
        {
            var book = InMemoryDb.InMemoryDb.Books.FirstOrDefault(x => x.Id == id);

            if (book != null)
            {
                InMemoryDb.InMemoryDb.Books.Remove(book);
            }
        }

        void IBookRepository.Update(Book book)
        {
            var bookForUpdate = InMemoryDb.InMemoryDb.Authors.FirstOrDefault(x => x.Id == book.Id);

            if (bookForUpdate != null)
            {
                bookForUpdate.Name = book.Name;
            }
        }
    }
}
