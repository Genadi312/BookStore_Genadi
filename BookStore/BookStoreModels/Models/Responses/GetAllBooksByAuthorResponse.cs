namespace BookStore.Models.Models.Responses
{
    public class GetAllBooksByAuthorResponse
    {
        public Author Author { get; set; }

        public IEnumerable<Book> Books { get; set; }
    }
}
