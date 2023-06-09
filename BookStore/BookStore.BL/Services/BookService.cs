using AutoMapper;
using BookStore.BL.Interfaces;
using BookStore.DL.Interfaces;
using BookStore.Models.Models;

namespace BookStore.BL.Services
{
    public class BookService : IBookServices
    {
        public readonly IBookRepository _bookRepository;
        public readonly IAuthorServices _authorServices;
        private readonly IMapper _mapper;


        public BookService(IAuthorServices authorServices, IBookRepository bookRepository, IMapper mapper)
        {
            _authorServices = authorServices;
            _bookRepository = bookRepository;
            _mapper = mapper;

        }

        public async Task Add(Book books)
        {
            var book = _mapper.Map<Book>(books);
            book.Id = Guid.NewGuid();
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
