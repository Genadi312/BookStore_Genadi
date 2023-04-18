namespace BookStore.Models.Models.Responses
{
    public class GetAllBooksByReleaseDate
    {
        public IEnumerable<Book> Books { get; set; }
        public Author? Author { get; set; }
    }
}
