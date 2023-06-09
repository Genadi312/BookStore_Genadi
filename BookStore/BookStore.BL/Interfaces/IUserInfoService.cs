using BookStore.Models.Models;
using BookStore.Models.Models.Requests.AddRequests;

namespace BookStore.BL.Interfaces
{
    public interface IUserInfoService
    {
        public Task<UserInfo?> GetUserInfoAsync(string userName, string password);

        public Task Add(AddUserInfoRequest userInfo);
    }
}
