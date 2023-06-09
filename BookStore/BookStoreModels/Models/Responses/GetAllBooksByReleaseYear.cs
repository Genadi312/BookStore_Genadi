namespace BookStore.Models.Models.Responses
{
    public class GetAllBooksByReleaseYear
    {
        public IEnumerable<Book> Books { get; set; }
        public Author? Author { get; set; }
    }
}
