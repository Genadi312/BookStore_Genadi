using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.DL.Interfaces;
using BookStore.Models.Configurations;
using BookStore.Models.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BookStore.DL.Repositories.MongoDb
{
    public class BookMongoRepository : IBookRepository
    {
        private readonly IMongoCollection<Book> _books;

        public BookMongoRepository(IOptionsMonitor<MongoDbConfiguration> mongoConfig)
        {
            var client = new MongoClient(mongoConfig.CurrentValue.ConnectionString);
            var database = client.GetDatabase(mongoConfig.CurrentValue.DatabaseName);

            _books = database.GetCollection<Book>(nameof(Book));
        }

        public async Task Add(Book book)
        {
            await _books.InsertOneAsync(book);
        }

        public Task Delete(int id)
        {
            return _books.DeleteManyAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _books.Find(book => true).ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetAllBooksByReleaseDate(int releaseDate)
        {
            return (IEnumerable<Book>)await _books.Find(x => x.ReleaseDate == releaseDate).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Book>> GetAllByAuthorId(Guid authorId)
        {
            return (IEnumerable<Book>) await _books.Find(x => x.AuthorId == authorId).FirstOrDefaultAsync();
        }

        public async Task<Book?> GetById(int id)
        {
            return await _books.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task Update(Book book)
        {
            var filter = Builders<Book>.Filter.Eq(s => s.Id, book.Id);
            var update = Builders<Book>.Update.Set(s => s.Name, book.Name);
            await _books.UpdateOneAsync(filter, update);
        }


    }
}
