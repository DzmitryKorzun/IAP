using IAP.Infrustructure.Enums;
using IAP.Infrustructure.Interfaces;
using IAP.Infrustructure.Models;
using Microsoft.EntityFrameworkCore;

namespace IAP.Infrustructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;
        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> ActivateUser(int id)
        {
            var user = await GetUserById(id);
            if (user == null)
            {
                return 0;
            }
            user.Status = (int)UserStatusEnum.Active;
            context.Update(user);
            return context.SaveChanges();
        }

        public async Task<int> DisableUser(int id)
        {
            var user = await GetUserById(id);
            if (user == null)
            {
                return 0;
            }
            user.Status = (int)UserStatusEnum.Disabled;
            context.Update(user);
            return context.SaveChanges();
        }

        public async Task<int> GetCountOfUser()
        {
            return await context.Users.CountAsync();
        }

        public async Task<UserModel> GetUserByEmail(string userEmail)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.Email == userEmail);
        }

        public async Task<UserModel> GetUserById(int id)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<int> RegisterNewUser(UserModel newUser)
        {
            context.Users.Add(newUser);
            return await context.SaveChangesAsync();
        }
    }
}
