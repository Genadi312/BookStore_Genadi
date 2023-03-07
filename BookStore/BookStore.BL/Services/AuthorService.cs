using BookStore.BL.Interfaces;
using BookStore.DL.Interfaces;
using BookStore.Models.Models;
using BookStore.Models.Models.Requests;

namespace BookStore.BL.Services
{
    public class AuthorService : IAuthorServices
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository= authorRepository;
        }

        public void Add(AddAuthorRequest authorRequest)
        {
            _authorRepository.Add(new Author()
            {
                Name= authorRequest.Name,
                Bio = authorRequest.Bio,
            });
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

        public void Update(Author author)
        {
            _authorRepository.Update(author);
        }
    }
}
