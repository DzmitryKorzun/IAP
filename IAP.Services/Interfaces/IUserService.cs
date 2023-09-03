using IAP.Infrustructure.Models;
using IAP.Infrustructure.Responses;
using Microsoft.Extensions.Configuration;

namespace IAP.Services.Interfaces
{
    public interface IUserService
    {
        public Task<CommonResponse<bool>> UserAuthorization(string email, string password);
        public Task<CommonResponse<int>> RegisterNewUser(UserModel newUser);
        public Task<CommonResponse<UserModel>> GetUserById(int id);
        public Task<CommonResponse<int>> GetCountOfUser();
        public Task<CommonResponse<bool>> IsLogging(UserLoggingModel user);
        public Task<CommonResponse<bool>> Logout(UserLoggingModel user);
        public Task<CommonResponse<bool>> UpdateUserInformation(UserModel user);
        public string GenerateJwtToken(string email, IConfiguration configuration);
        public Task<CommonResponse<string>> GetUserDetails();
    }
}
