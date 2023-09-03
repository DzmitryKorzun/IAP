using IAP.Services;
using IAP.Services.Implementations;
using IAP.Services.Interfaces;

namespace AIP.Tests.UsersTest
{
    public class UserServiceTests
    {
        MocksRepositories mocksRepositories = new MocksRepositories();

        [Test]
        public void CheckPasswordTest()
        {
            var pass = "1234";
            var expectHash = "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4";
            var actualHash = HashPasswordHelper.GetPasswordHash(pass);

            Assert.That(actualHash, Is.EqualTo(expectHash));
        }

        [Test]
        public void GetCountOfUsers()
        {
            IUserService userService = new UserService(mocksRepositories.usersMocks.Object);

            Assert.That(1, Is.EqualTo(userService.GetCountOfUser().Result));
        }
    }
}
