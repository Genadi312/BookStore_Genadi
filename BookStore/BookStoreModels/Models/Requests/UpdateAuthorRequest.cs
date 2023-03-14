namespace BookStore.Models.Models.Requests
{
    public class UpdateAuthorRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Bio { get; set; }
    }
}
