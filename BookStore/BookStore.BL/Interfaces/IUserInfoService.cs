using BookStore.Models.Models;

namespace BookStore.BL.Interfaces
{
    public interface IUserInfoService
    {
        public Task<UserInfo?> GetUserInfoAsync(string userName, string password);
    }
}
