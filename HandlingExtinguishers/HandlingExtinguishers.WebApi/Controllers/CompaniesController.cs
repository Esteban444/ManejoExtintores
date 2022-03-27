using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.DTO.Request;
using HandlingExtinguishers.DTO.Response;
using Microsoft.AspNetCore.Mvc;

namespace HandlingExtinguishers.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IServiceCompanies _serviceCompanies;


        public CompaniesController(IServiceCompanies serviceCompanies) 
        {
            _serviceCompanies = serviceCompanies;

        }

        [HttpGet]
        [ProducesResponseType(typeof(CompanyResponseDto), 200)]
        [ProducesResponseType(typeof(CompanyResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> ConsultCompanies() 
        {
            var companies = await _serviceCompanies.GetCompanies();
            return Ok(companies);
        }

        [HttpGet("{companyId}")]
        [ProducesResponseType(typeof(CompanyResponseDto), 200)]
        [ProducesResponseType(typeof(CompanyResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> ConsultCompanyById(Guid companyId)
        {
            var company = await _serviceCompanies.GetCompany(companyId);
            return Ok(company);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CompanyResponseDto), 200)]
        [ProducesResponseType(typeof(CompanyResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> AddAsync(CompanyRequestDto companyRequest)
        {
            var response = await _serviceCompanies.AddCompany(companyRequest);
            return Ok(response);
        }

        [HttpPut("{companyId}")]
        [ProducesResponseType(typeof(CompanyResponseDto), 200)]
        [ProducesResponseType(typeof(CompanyResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> UpdateCompany(Guid companyId, CompanyRequestDto companyRequest)
        {
            var result = await _serviceCompanies.UpdateCompany(companyId, companyRequest);
            return Ok(result);

        }

        [HttpPatch("{companyId}")]
        [ProducesResponseType(typeof(CompanyResponseDto), 200)]
        [ProducesResponseType(typeof(CompanyResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> UpdateCompanyField(Guid companyId, CompanyRequestUpdateFieldDto companyRequestUpdateField) 
        {
            var result = await _serviceCompanies.UpdateCompanyField(companyId, companyRequestUpdateField);
            return Ok(result);

        }

        [HttpDelete("{companyId}")]
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
