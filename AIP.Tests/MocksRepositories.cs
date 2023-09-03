using IAP.Infrustructure.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIP.Tests
{
    internal class MocksRepositories
    {
        public Mock<IUserRepository> usersMocks = new Mock<IUserRepository>();

        public MocksRepositories()
        {
            usersMocks.Setup(u => u.GetCountOfUser().Result).Returns(1);
        }
    }
}
