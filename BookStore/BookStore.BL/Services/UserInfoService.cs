using BookStore.BL.Interfaces;
using BookStore.DL.Interfaces;
using BookStore.Models.Models;

namespace BookStore.BL.Services
{
    public class UserInfoService : IUserInfoService
    {
        private readonly IUserInfoRepository _userInfoRepository;

        public UserInfoService(IUserInfoRepository userInfoRepository)
        {
            _userInfoRepository = userInfoRepository;
        }


        public Task<UserInfo?> GetUserInfoAsync(string userName, string password)
        {
            return _userInfoRepository.GetUserInfoAsync(userName, password);
        }


    }
}
