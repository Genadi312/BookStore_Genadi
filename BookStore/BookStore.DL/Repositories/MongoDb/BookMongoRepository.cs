using BookStore.DL.Interfaces;
using BookStore.Models.Configurations;
using BookStore.Models.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
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

            var collectionSettings = new MongoCollectionSettings
            {
                GuidRepresentation = GuidRepresentation.Standard
            };

            _books = database.GetCollection<Book>(nameof(Book), collectionSettings);
        }

        public async Task Add(Book book)
        {
            await _books.InsertOneAsync(book);
        }

        public Task Delete(Guid id)
        {
            return _books.DeleteManyAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _books.Find(book => true).ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetAllBooksByReleaseYear(int releaseYear)
        {
            return await _books.Find(x => x.ReleaseYear == releaseYear).ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetAllByAuthorId(Guid authorId)
        {
            return await _books.Find(x => x.AuthorId == authorId).ToListAsync();
        }

        public async Task<Book?> GetById(Guid id)
        {
            var item = await _books
                .Find(Builders<Book>.Filter.Eq("_id", id))
                .FirstOrDefaultAsync();
            return item;
        }

        public async Task Update(Book book)
        {
            var filter = Builders<Book>.Filter.Eq(s => s.Id, book.Id);
            var update = Builders<Book>.Update.Set(s => s.Title, book.Title);
            await _books.UpdateOneAsync(filter, update);
        }

    }
}
