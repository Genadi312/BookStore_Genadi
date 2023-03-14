using BookStore.BL.Interfaces;
using BookStore.DL.Interfaces;
using BookStore.Models.Models;
using BookStore.Models.Models.Responses;

namespace BookStore.BL.Services
{
    public class LibraryServices : ILibraryServices
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;

        public LibraryServices(IAuthorRepository authorRepository, IBookRepository bookRepository)
        {
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
        }
        public GetAllBooksByAuthorResponse GetAllBooksByAuthorId(int authorId)
        {
            var author = _authorRepository.GetById(authorId);
            var books = Enumerable.Empty<Book>();

            if (author != null)
            {
                books = _bookRepository.GetAllByAuthorId(authorId);
            }
            return new GetAllBooksByAuthorResponse()
            {
                Author = author,
                Books = books
            };
        }



        public GetAllBooksByReleaseDate GetAllBooksByReleaseDate(int releaseDate, int authorId)
        {
            var author = _authorRepository.GetById(authorId);
            var books = Enumerable.Empty<Book>();
            if (releaseDate != null)
            {
                books = _bookRepository.GetAllBooksByReleaseDate(releaseDate);
            }
            return new GetAllBooksByReleaseDate()
            {
                Author = author,
                Books = books
            };
        }
    }
}
