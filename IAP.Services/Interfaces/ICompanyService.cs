using IAP.Infrustructure.Models;
using IAP.Infrustructure.Responses;

namespace IAP.Services.Interfaces
{
    public interface ICompanyService
    {
        public Task<CommonResponse<int>> CreateNewCompany(CompanyModel model);
        public Task<int> UpdateNewCompany(int companyId);
        public Task<int> DeleteCompany(int companyId);
    }
}
