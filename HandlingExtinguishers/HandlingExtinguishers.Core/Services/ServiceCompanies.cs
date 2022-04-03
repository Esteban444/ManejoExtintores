using AutoMapper;
using HandlingExtinguishers.Contracts.Interfaces.Repositorios;
using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.Core.Helpers;
using HandlingExtinguishers.DTO.Models;
using HandlingExtinguishers.DTO.Request;
using HandlingExtinguishers.DTO.Response;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace HandlingExtinguishers.Core.Services
{
    public class ServiceCompanies : IServiceCompanies 
    {
        private readonly IRepositoryCompanies _repositoryCompanies;
        private readonly IMapper _mapper;

        public ServiceCompanies(IRepositoryCompanies repositoryCompanies, IMapper mapper) 
        {
            _repositoryCompanies = repositoryCompanies;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CompanyResponseDto>> GetCompanies()
        {
            var companies = await _repositoryCompanies.GetAll().ToListAsync();
            var companiesdt = _mapper.Map<IEnumerable<CompanyResponseDto>>(companies);
            return companiesdt;
        }

        public async Task<CompanyResponseDto> GetCompany(Guid companyId)  
        {
            var companyBd = await _repositoryCompanies.FindBy(c => c.Id == companyId).FirstOrDefaultAsync();
            if (companyBd == null) throw new GlobalException("The company record does not exist in the database.", HttpStatusCode.NotFound);

            return _mapper.Map<CompanyResponseDto>(companyBd);
        }

        public async Task<CompanyResponseDto> AddCompany(CompanyRequestDto companyRequest) 
        {
            if(companyRequest.Active == null) { companyRequest.Active = true; }
            var company = _mapper.Map<Company>(companyRequest);
            await _repositoryCompanies.Add(company);
            var newcompany = _mapper.Map<CompanyResponseDto>(company);
            return newcompany;
        }

        public async Task<CompanyResponseDto> UpdateCompany(Guid companyId, CompanyRequestDto companyRequestUpdate)
        {
            if (companyRequestUpdate.Active == null) { companyRequestUpdate.Active = true; }
            var companyBd = await _repositoryCompanies.FindBy(c => c.Id == companyId).FirstOrDefaultAsync();
            if (companyBd == null) throw new GlobalException("The company record you are trying to update does not exist in the database.", HttpStatusCode.NotFound);

            _mapper.Map(companyRequestUpdate, companyBd);

            await _repositoryCompanies.Update(companyBd);
            var response = _mapper.Map<CompanyResponseDto>(companyBd);
            return response;
        }

        public async Task<CompanyResponseDto> UpdateCompanyField(Guid companyId, CompanyRequestUpdateFieldDto companyRequestUpdateField) 
        {
            var companyBd = await _repositoryCompanies.FindBy(x => x.Id == companyId).FirstOrDefaultAsync();
            if (companyBd == null) throw new GlobalException("The company record you are trying to update does not exist in the database.", HttpStatusCode.NotFound);

            var properties = new UpdateMapperProperties<Company, CompanyRequestUpdateFieldDto>();
            var updateCompany = await properties.MapperUpdate(companyBd!, companyRequestUpdateField);
            await _repositoryCompanies.Update(updateCompany);
            var response = _mapper.Map<CompanyResponseDto>(updateCompany);
            return response;
        }

        public async Task<CompanyResponseDto> DeleteCompany(Guid companyId)  
        {
            var companyBd = await _repositoryCompanies.FindBy(c => c.Id == companyId).FirstOrDefaultAsync();
            if (companyBd == null) throw new GlobalException("The company record you are trying to delete does not exist in the database.", HttpStatusCode.NotFound);
            await _repositoryCompanies.Delete(companyBd);
            var companyDeleted = _mapper.Map<CompanyResponseDto>(companyBd);
            return companyDeleted;

        }

    }
}
