using MongoDB.Bson.Serialization.Attributes;

namespace BookStore.Models.Models
{
    public class Book
    {
        [BsonId]
        [BsonElement("_id")]
        public Guid Id { get; set; }

        public string Title { get; set; }

        public Guid AuthorId { get; set; }

        //public int ReleaseDate { get; set; }
    }
}
