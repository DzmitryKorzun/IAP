using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAP.Services.Interfaces
{
    public interface IUserService
    {
        public Task<bool> UserAuthorization(string email, string password)
    }
}
