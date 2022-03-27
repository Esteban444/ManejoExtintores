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
            var companies = _repositoryCompanies.GetAll();
            var companiesdt = _mapper.Map<IEnumerable<CompanyResponseDto>>(companies);
            return companiesdt;
        }

        public async Task<CompanyResponseDto> GetCompany(Guid companyId)  
        {
            var companybd = await _repositoryCompanies.FindBy(c => c.IdCompany == companyId).FirstOrDefaultAsync();
            if (companybd == null) throw new GlobalException("The company record does not exist in the database.", HttpStatusCode.NotFound);

            return _mapper.Map<CompanyResponseDto>(companybd);
        }

        public async Task<CompanyResponseDto> AddCompany(CompanyRequestDto companyRequest) 
        {
            var company = _mapper.Map<Companies>(companyRequest);
            await _repositoryCompanies.Add(company);
            var newcompany = _mapper.Map<CompanyResponseDto>(company);
            return newcompany;
        }

        public async Task<CompanyResponseDto> UpdateCompany(Guid companyId, CompanyRequestDto companyRequest)
        {
            var companybd = await _repositoryCompanies.FindBy(c => c.IdCompany == companyId).FirstOrDefaultAsync();
            if (companybd == null) throw new GlobalException("The company record you are trying to update does not exist in the database.", HttpStatusCode.NotFound);

            _mapper.Map(companyRequest, companybd);

            await _repositoryCompanies.Update(companybd);
            var response = _mapper.Map<CompanyResponseDto>(companybd);
            return response;
        }

        public async Task<CompanyResponseDto> UpdateCompanyField(Guid companyId, CompanyRequestUpdateFieldDto companyRequestUpdateField) 
        {
            var companybd = await _repositoryCompanies.FindBy(x => x.IdCompany == companyId).FirstOrDefaultAsync();
            if (companybd == null) throw new GlobalException("The company record you are trying to update does not exist in the database.", HttpStatusCode.NotFound);

            var properties = new UpdateMapperProperties<Companies, CompanyRequestUpdateFieldDto>();
            var updateCompany = await properties.MapperUpdate(companybd!, companyRequestUpdateField);
            await _repositoryCompanies.Update(updateCompany);
            var response = _mapper.Map<CompanyResponseDto>(updateCompany);
            return response;
        }

        public async Task<CompanyResponseDto> DeleteCompany(Guid companyId)  
        {
            var companybd = await _repositoryCompanies.FindBy(c => c.IdCompany == companyId).FirstOrDefaultAsync();
            if (companybd == null) throw new GlobalException("The company record you are trying to delete does not exist in the database.", HttpStatusCode.NotFound);
            await _repositoryCompanies.Delete(companybd);
            var companyDeleted = _mapper.Map<CompanyResponseDto>(companybd);
            return companyDeleted;

        }

    }
}
