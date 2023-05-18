using IAP.Infrustructure.Interfaces;
using IAP.Infrustructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAP.Infrustructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;
        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> GetCountOfUser()
        {
            var x = await context.Users.ToArrayAsync();
            return x.Length;
        }

        public async Task<UserModel> GetUserByEmail(string userEmail)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.Email == userEmail);
        }

        public async Task<int> RegisterNewUser(UserModel newUser)
        {
            context.Users.Add(newUser);
            return await context.SaveChangesAsync();
        }
    }
}
