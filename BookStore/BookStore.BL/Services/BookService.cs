using BookStore.BL.Interfaces;
using BookStore.DL.Interfaces;
using BookStore.Models.Models;

namespace BookStore.BL.Services
{
    public class BookService : IBookServices
    {
        public readonly IBookRepository _bookRepository;
        public readonly IAuthorServices _authorServices;


        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task Add(Book book)
        {
            book.Id = Guid.NewGuid();
            var author = _authorServices.GetById(book.AuthorId);

            if (author == null) return;

            var authorBooks = await _bookRepository.GetAllByAuthorId(book.AuthorId);

            var titleForAuthorExist = authorBooks.Any(b => b.Title == book.Title);

            if (titleForAuthorExist) return;

            await _bookRepository.Add(book);

        }

        public async Task<Book?> GetById(Guid id)
        {

            var result = await _bookRepository.GetById(id);

            if (result != null)
            {
                result.Title = $"!{result.Title}";
            }
            return result;
        }

        public async Task<IEnumerable<Book>> GetAll()
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
