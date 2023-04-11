using System;
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

        public async Task Add(AddAuthorRequest authorRequest)
        {
            var author = _mapper.Map<Author>(authorRequest);
            author.Id = Guid.NewGuid();
            await _authorRepository.Add(author);

            
        }

        public async Task Delete(Guid id)
        {
            await _authorRepository.Delete(id);
        }

        public async Task <IEnumerable<Author>> GetAll()
        {
            return await _authorRepository.GetAll();
        }

        public async Task<Author> GetById(Guid id)
        {
            return await _authorRepository.GetById(id);
        }

        public async Task Update(UpdateAuthorRequest authorRequest)
        {
            var author = _mapper.Map<Author>(authorRequest);

            await _authorRepository.Update(author);
        }
    }
}
