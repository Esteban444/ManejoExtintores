using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.DTO.Request.Companies;
using HandlingExtinguishers.DTO.Response;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HandlingExtinguishers.WebApi.Controllers
{
    /// <summary>
    /// With this Api you will be able to manage companies.
    /// </summary>
    [Route("api/companies")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CompaniesController : ControllerBase
    {
        private readonly IServiceCompanies _serviceCompanies;

        /// <summary>
        /// Methodo constructor.
        /// </summary>
        /// <param name="serviceCompanies"></param>
        public CompaniesController(IServiceCompanies serviceCompanies) 
        {
            _serviceCompanies = serviceCompanies;

        }

        /// <summary>
        /// This endpoint returns all companies.
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-all-companies")]
        [ProducesResponseType(typeof(CompanyResponseDto), 200)]
        [ProducesResponseType(typeof(CompanyResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> ConsultCompanies() 
        {
            var companies = await _serviceCompanies.GetCompanies();
            return Ok(companies);
        }

        /// <summary>
        /// This endpoint returns a company by Id.
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [HttpGet("get-company-by/{companyId}")]
        [ProducesResponseType(typeof(CompanyResponseDto), 200)]
        [ProducesResponseType(typeof(CompanyResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> ConsultCompanyById(Guid companyId)
        {
            var company = await _serviceCompanies.GetCompany(companyId);
            return Ok(company);
        }

        /// <summary>
        /// This endpoint add a company.
        /// </summary>
        /// <param name="companyRequest"></param>
        /// <returns></returns>
        [HttpPost("company")]
        [ProducesResponseType(typeof(CompanyResponseDto), 200)]
        [ProducesResponseType(typeof(CompanyResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> AddAsync(CompanyRequestDto companyRequest)
        {
            var response = await _serviceCompanies.AddCompany(companyRequest);
            return Ok(response);
        }

        /// <summary>
        /// This endpoint update a company by Id.
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="companyRequest"></param>
        /// <returns></returns>
        [HttpPut("update-company/{companyId}")]
        [ProducesResponseType(typeof(CompanyResponseDto), 200)]
        [ProducesResponseType(typeof(CompanyResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> UpdateCompany(Guid companyId, CompanyRequestDto companyRequest)
        {
            var result = await _serviceCompanies.UpdateCompany(companyId, companyRequest);
            return Ok(result);

        }

        /// <summary>
        /// This endpoint update a company by Id.
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="companyRequestUpdateField"></param>
        /// <returns></returns>
        [HttpPatch("update-fields-company/{companyId}")]
        [ProducesResponseType(typeof(CompanyResponseDto), 200)]
        [ProducesResponseType(typeof(CompanyResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> UpdateCompanyField(Guid companyId, CompanyRequestUpdateFieldDto companyRequestUpdateField) 
        {
            var result = await _serviceCompanies.UpdateCompanyField(companyId, companyRequestUpdateField);
            return Ok(result);

        }

        /// <summary>
        /// This endpoint delete a price by Id.
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
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
