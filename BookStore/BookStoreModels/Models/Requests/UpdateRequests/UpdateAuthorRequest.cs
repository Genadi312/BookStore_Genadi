namespace BookStore.Models.Models.Requests.UpdateRequests
{
    public class UpdateAuthorRequest
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Bio { get; set; }
    }
}
