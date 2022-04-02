using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.DTO.Request;
using HandlingExtinguishers.DTO.Response;
using Microsoft.AspNetCore.Mvc;

namespace HandlingExtinguishers.WebApi.Controllers
{
    [Route("api/companies")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IServiceCompanies _serviceCompanies;


        public CompaniesController(IServiceCompanies serviceCompanies) 
        {
            _serviceCompanies = serviceCompanies;

        }

        [HttpGet("get-all-companies")]
        [ProducesResponseType(typeof(CompanyResponseDto), 200)]
        [ProducesResponseType(typeof(CompanyResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> ConsultCompanies() 
        {
            var companies = await _serviceCompanies.GetCompanies();
            return Ok(companies);
        }

        [HttpGet("get-company-by/{companyId}")]
        [ProducesResponseType(typeof(CompanyResponseDto), 200)]
        [ProducesResponseType(typeof(CompanyResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> ConsultCompanyById(Guid companyId)
        {
            var company = await _serviceCompanies.GetCompany(companyId);
            return Ok(company);
        }

        [HttpPost("company")]
        [ProducesResponseType(typeof(CompanyResponseDto), 200)]
        [ProducesResponseType(typeof(CompanyResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> AddAsync(CompanyRequestDto companyRequest)
        {
            var response = await _serviceCompanies.AddCompany(companyRequest);
            return Ok(response);
        }

        [HttpPut("update-company/{companyId}")]
        [ProducesResponseType(typeof(CompanyResponseDto), 200)]
        [ProducesResponseType(typeof(CompanyResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> UpdateCompany(Guid companyId, CompanyRequestDto companyRequest)
        {
            var result = await _serviceCompanies.UpdateCompany(companyId, companyRequest);
            return Ok(result);

        }

        [HttpPatch("update-fields-company/{companyId}")]
        [ProducesResponseType(typeof(CompanyResponseDto), 200)]
        [ProducesResponseType(typeof(CompanyResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> UpdateCompanyField(Guid companyId, CompanyRequestUpdateFieldDto companyRequestUpdateField) 
        {
            var result = await _serviceCompanies.UpdateCompanyField(companyId, companyRequestUpdateField);
            return Ok(result);

        }

        [HttpDelete("delete-company/{companyId}")]
        [ProducesResponseType(typeof(CompanyResponseDto), 200)]
        [ProducesResponseType(typeof(CompanyResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> DeleteCompany(Guid companyId) 
        {
            var result = await _serviceCompanies.DeleteCompany(companyId);
            return Ok(result);
        }
    }
}
