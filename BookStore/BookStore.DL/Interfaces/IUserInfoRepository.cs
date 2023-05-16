using BookStore.Models.Models;
using BookStore.Models.Models.Requests;

namespace BookStore.DL.Interfaces
{
    public interface IUserInfoRepository
    {
        public Task<UserInfo?> GetUserInfoAsync(string userName, string password);

        public Task Add(UserInfo user);
    }
}
