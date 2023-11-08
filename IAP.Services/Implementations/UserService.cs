using IAP.Infrustructure.Interfaces;
using IAP.Infrustructure.Models;
using IAP.Infrustructure.Responses;
using IAP.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IAP.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IConfiguration configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserService(IUserRepository userRepository, IConfiguration configuration,
            IHttpContextAccessor _httpContextAccessor)
        {
            this.userRepository = userRepository;
            this.configuration = configuration;
            this._httpContextAccessor = _httpContextAccessor;
        }

        public async Task<CommonResponse<bool>> UserAuthorization(string email, string password)
        {
            var user = await userRepository.GetUserByEmail(email);

            if (user == null) return new CommonResponse<bool>
            {
                Status = Infrustructure.Enums.ResponseStatus.NoData,
                Data = false, 
            };

            if (HashPasswordHelper.PasswordComparingWithHash(user.PasswordHash, password))
            {
                return new CommonResponse<bool>
                {

                };
            }
            return new CommonResponse<bool>
            {

            };
        }

        public async Task<CommonResponse<int>> RegisterNewUser(UserModel newUser)
        {
            var findedUser = await userRepository.GetUserByEmail(newUser.Email);
            if (findedUser == null)
            {
                var resultNewUserRegistration = await userRepository.RegisterNewUser(newUser);
                if (resultNewUserRegistration == 1)
                {
                    return new CommonResponse<int>
                    {
                        Data = resultNewUserRegistration,
                        Status = Infrustructure.Enums.ResponseStatus.OK
                    };
                }
                return new CommonResponse<int>
                {
                    Data = resultNewUserRegistration,
                    Status = Infrustructure.Enums.ResponseStatus.InternalError,
                    Message = "Unknown error during registration"
                };            
            }
            return new CommonResponse<int>
            {
                Data = 0,
                Status = Infrustructure.Enums.ResponseStatus.UserAlreadyExists,
                Message = "A user with this email address already exists"
            };
        }

        public async Task<CommonResponse<UserModel>> GetUserById(int id)
        {
            var data = await userRepository.GetUserById(id);
            return new CommonResponse<UserModel> 
            {
                Data = data,
            };
        }

        public async Task<CommonResponse<int>> GetCountOfUser()
        {
            var data = await userRepository.GetCountOfUser();
            return new CommonResponse<int>
            {
                Data = data,
            };
        }

        public async Task<CommonResponse<bool>> IsLogging(UserLoggingModel loggingData)
        {
            var user = await userRepository.GetUserByEmail(loggingData.Email);
            if (user != null)
            {
                if (HashPasswordHelper.PasswordComparingWithHash(user.PasswordHash, loggingData.Password))
                {
                    return new CommonResponse<bool>
                    {
                        Data = true,
                    };
                        
                }
            }
            return new CommonResponse<bool>
            {
                Data = false,
            };
        }

        public Task<CommonResponse<bool>> Logout(UserLoggingModel user)
        {
            throw new NotImplementedException();
        }

        public Task<CommonResponse<bool>> UpdateUserInformation(UserModel user)
        {
            throw new NotImplementedException();
        }

        public string GenerateJwtToken(string email, IConfiguration configuration)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration["Jwt:key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", email) }),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = configuration["Jwt:Issuer"],
                Audience = configuration["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        
        public async Task<CommonResponse<string>> GetUserDetails()
        {
            return new CommonResponse<string>
            {
                Data = _httpContextAccessor.HttpContext.User.Identity.Name
            };
        }
    }
}