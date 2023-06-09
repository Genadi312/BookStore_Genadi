using BookStore.DL.Interfaces;
using BookStore.Models.Configurations;
using BookStore.Models.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BookStore.DL.Repositories.MongoDb
{
    public class AuthorMongoRepository : IAuthorRepository
    {

        private readonly IMongoCollection<Author> _authors;

        public AuthorMongoRepository(IOptionsMonitor<MongoDbConfiguration> mongoConfig)
        {
            var client = new MongoClient(mongoConfig.CurrentValue.ConnectionString);
            var database = client.GetDatabase(mongoConfig.CurrentValue.DatabaseName);
            var collectionSettings = new MongoCollectionSettings
            {
                GuidRepresentation = GuidRepresentation.Standard
            };

            _authors = database.GetCollection<Author>(nameof(Author), collectionSettings);
        }


        public async Task Add(Author author)
        {
            await _authors.InsertOneAsync(author);
        }

        public Task Delete(Guid id)
        {
            return _authors.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Author>> GetAll()
        {
            return await _authors.Find(author => true).ToListAsync();
        }

        public async Task<Author> GetById(Guid id)
        {
            var item = await _authors
                .Find(Builders<Author>.Filter.Eq("_id", id))
                .FirstOrDefaultAsync();
            return item;
        }

        public async Task Update(Author author)
        {
            var filter = Builders<Author>.Filter.Eq(s=>s.Id, author.Id);
            var update = Builders<Author>.Update.Set(s => s.Bio, author.Bio);
            await _authors.UpdateOneAsync(filter, update);
        }
    }
}
