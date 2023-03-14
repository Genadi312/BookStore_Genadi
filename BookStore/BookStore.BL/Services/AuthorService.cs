using AutoMapper;
using BookStore.BL.Interfaces;
using BookStore.DL.Interfaces;
using BookStore.Models.Models;
using BookStore.Models.Models.Requests;

namespace BookStore.BL.Services
{
    public class AuthorService : IAuthorServices
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public void Add(AddAuthorRequest authorRequest)
        {
            var author = _mapper.Map<Author>(authorRequest);
            _authorRepository.Add(author);
            
        }

        public void Delete(int id)
        {
            _authorRepository.Delete(id);
        }

        public IEnumerable<Author> GetAll()
        {
            return _authorRepository.GetAll();
        }

        public Author GetById(int id)
        {
            return _authorRepository.GetById(id);
        }

        public void Update(UpdateAuthorRequest authorRequest)
        {
            var author = _mapper.Map<Author>(authorRequest);
            _authorRepository.Update(author);
        }
    }
}
