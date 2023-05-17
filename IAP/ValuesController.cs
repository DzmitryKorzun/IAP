using IAP.Infrustructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace IAP.Web
{
    [Route("/[controller]")]
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
    }
}
