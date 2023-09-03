using IAP.Infrustructure.Models;
using IAP.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IAP.Web.Controllers
{
    [ApiController]
    [Route("/[controller]/[action]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService companyService;
        public CompanyController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewCompany([FromBody] CompanyModel company)
        {
            var result = await companyService.CreateNewCompany(company);

            if (result.Status == Infrustructure.Enums.ResponseStatus.OK)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCompany()
        {
            var result = await companyService.CreateNewCompany();

            if (result.Status == Infrustructure.Enums.ResponseStatus.OK)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}
