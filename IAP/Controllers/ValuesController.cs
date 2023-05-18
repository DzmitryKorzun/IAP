using IAP.Infrustructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace IAP.Web.Controllers
{
    [Route("/[controller]/[action]")]
    [ApiController]
    public class VController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public VController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<int> Num()
        {
            return await _userRepository.GetCountOfUser();
        }
        [HttpGet]
        public string? GetCurrentUser()
        {
            return User?.Identity?.Name;
        }
    }
}
