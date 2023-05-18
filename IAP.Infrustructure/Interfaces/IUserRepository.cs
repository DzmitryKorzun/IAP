using IAP.Infrustructure.Models;

namespace IAP.Infrustructure.Interfaces
{    
    public interface IUserRepository
    {
        public Task<int> GetCountOfUser();
        public Task<UserModel> GetUserByEmail(string userEmail);
        public Task<int> RegisterNewUser(UserModel newUser);
    }
}
