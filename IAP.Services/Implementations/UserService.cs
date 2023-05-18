using IAP.Infrustructure.Interfaces;
using IAP.Infrustructure.Models;
using IAP.Services.Interfaces;

namespace IAP.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<bool> UserAuthorization(string email, string password)
        {
            var user = await userRepository.GetUserByEmail(email);

            if (user == null) return false;

            if (HashPasswordHelper.PasswordComparingWithHash(user.PasswordHash, password))
            {
                return true;
            }
            return false;
        }
        
        public async Task<int> RegisterNewUser(UserModel newUser)
        {
            return await userRepository.RegisterNewUser(newUser);
        }
    }
}