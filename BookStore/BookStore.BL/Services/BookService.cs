using BookStore.BL.Interfaces;
using BookStore.DL.Interfaces;
using BookStore.Models.Models;

namespace BookStore.BL.Services
{
    public class BookService : IBookServices
    {
        public readonly IBookRepository _bookRepository;


        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task Add(Book book)
        {
            book.Id = Guid.NewGuid();
            await _bookRepository.Add(book);
        }

        public async Task<Book?> GetById(Guid id)
        {
            return await _bookRepository.GetById(id);
        }

        public async Task <IEnumerable<Book>> GetAll()
        {
            return await _bookRepository.GetAll();
        }

        public async Task Update(Book book)
        {
            await _bookRepository.Update(book);
        }

        public async Task Delete(Guid id)
        {
            await _bookRepository.Delete(id);
        }
    }
}
