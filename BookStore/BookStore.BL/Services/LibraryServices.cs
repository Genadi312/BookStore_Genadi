using BookStore.BL.Interfaces;
using BookStore.DL.Interfaces;
using BookStore.Models.Models;
using BookStore.Models.Models.Responses;
using Microsoft.Extensions.Logging;

namespace BookStore.BL.Services
{
    public class LibraryServices : ILibraryServices
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;
        private readonly ILogger<LibraryServices> _logger;

        public LibraryServices(IAuthorRepository authorRepository, IBookRepository bookRepository, ILogger<LibraryServices> logger)
        {
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
            _logger = logger;
        }
        public GetAllBooksByAuthorResponse GetAllBooksByAuthorId(int authorId)
        {
            var author = _authorRepository.GetById(authorId);
            var books = Enumerable.Empty<Book>();

            if (author != null)
            {
                _logger.LogError($"GetAllByAuthorId error");
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
