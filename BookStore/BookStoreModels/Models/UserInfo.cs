using System.Diagnostics;

namespace BookStore.Models.Models
{
    public class UserInfo
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
