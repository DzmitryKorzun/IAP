using IAP.Infrustructure.Interfaces;
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
    }
}
