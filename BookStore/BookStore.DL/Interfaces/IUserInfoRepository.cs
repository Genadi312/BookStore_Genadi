using BookStore.Models.Models;

namespace BookStore.DL.Interfaces
{
    public interface IUserInfoRepository
    {
        public Task<UserInfo?> GetUserInfoAsync(string userName, string password);
    }
}
