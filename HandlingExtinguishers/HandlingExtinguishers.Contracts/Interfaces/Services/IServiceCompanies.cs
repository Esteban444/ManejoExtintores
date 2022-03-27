using HandlingExtinguishers.DTO.Request;
using HandlingExtinguishers.DTO.Response;



namespace HandlingExtinguishers.Contracts.Interfaces.Services
{
    public interface IServiceCompanies 
    {
        Task<IEnumerable<CompanyResponseDto>> GetCompanies();  
        Task<CompanyResponseDto> GetCompany(Guid companyId); 
        Task<CompanyResponseDto> AddCompany(CompanyRequestDto companyRequest);
        Task<CompanyResponseDto> UpdateCompany(Guid companyId, CompanyRequestDto companyRequest);
        Task<CompanyResponseDto> UpdateCompanyField(Guid companyId, CompanyRequestUpdateFieldDto companyRequestUpdateField);
        Task<CompanyResponseDto> DeleteCompany(Guid companyId); 
    }
}
