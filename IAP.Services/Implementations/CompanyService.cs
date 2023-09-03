using IAP.Infrustructure.Interfaces;
using IAP.Infrustructure.Models;
using IAP.Infrustructure.Responses;
using IAP.Services.Interfaces;

namespace IAP.Services.Implementations
{
    public class CompanyService : ICompanyService
    {
        private readonly IBasicRepository<CompanyModel> repository;

        public CompanyService(IBasicRepository<CompanyModel> repository)
        {
            this.repository = repository;
        }

        public async Task<CommonResponse<int>> CreateNewCompany(CompanyModel model)
        {
            await repository.Add(model);
            return new CommonResponse<int>
            {

            };
        }

        public Task<int> DeleteCompany(int companyId)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateNewCompany(int companyId)
        {
            throw new NotImplementedException();
        }
    }
}
