using IAP.Infrustructure.Models;
using IAP.Infrustructure.Repositories;

namespace IAP.Infrustructure.Interfaces
{    
    public interface IUserRepository
    {
        public Task<int> GetCountOfUser();
        public Task<UserModel> GetUserByEmail(string userEmail);
        public Task<int> RegisterNewUser(UserModel newUser);
        public Task<UserModel> GetUserById(int id);
        public Task<int> DisableUser(int id);
        public Task<int> ActivateUser(int id);
    }
}
