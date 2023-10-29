using Application.ConfigMapster.CompanyMap;
using Application.Core;
using Application.DataTransferObjects.Company;
using Application.ViewModels.ScopeWork;
using Application.ViewModels.Company;
using Application.ViewModels.Main;
using Domain.Entities;
using Domain.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Http;

namespace Application.Services.Company
{
    public class Company : ICompany
    {
        private readonly IRepository<CompanyEntity> _repository;
        private readonly IDapper<CompanyEntity> _dapper;
      

        public Company(IRepository<CompanyEntity> repository, IDapper<CompanyEntity> dapper)
        {
            _repository = repository;
            _dapper = dapper;
          
        }
       

        public async Task<ListGenerics<CompanyViewModel>> GetCompaniesAsync(int page, int pageSize, string search = "")
        {
            var companies = await _dapper
                .GetListAsync(false, "[dbo].[SP_GetCompanies]", page, pageSize, search);
            if (!companies.Any())
            {

            }
            List<CompanyViewModel> listCompany = companies.Adapt<List<CompanyViewModel>>(CompanyMapster.MapCompanyToViewModel());
            var count = await _repository.GetCount();
            count = count.PageCount(pageSize);
            ListGenerics<CompanyViewModel> result = new();
            result.List = listCompany;
            result.Count = count;
            result.CurrentPage = page;
            result.SearchKeyword = search;
            if (count > 1 && listCompany.Count < 10 && !string.IsNullOrEmpty(search) && page == 1)
            {
                result.Pagination = false;
            }

            return result;
        }

        public async Task<ListGenerics<CompanyViewModel>> GetTrashCompaniesAsync(int page, int pageSize, string search = "")
        {
            var companies = await _dapper
                .GetListAsync(true, "[dbo].[SP_GetCompanies]", page, pageSize, search);
            if (!companies.Any())
            {

            }
            List<CompanyViewModel> listCompany = companies.Adapt<List<CompanyViewModel>>(CompanyMapster.MapCompanyToViewModel());
            var count = await _repository.GetTrashCount();
            count = count.PageCount(pageSize);
            ListGenerics<CompanyViewModel> result = new();
            result.List = listCompany;
            result.Count = count;
            result.CurrentPage = page;
            result.SearchKeyword = search;
            if (count > 1 && listCompany.Count < 10 && !string.IsNullOrEmpty(search) && page == 1)
            {
                result.Pagination = false;
            }

            return result;
        }

        public async Task AddCompany(AddCompanyDto model)
        {
            CompanyEntity company = new();
            company = model.Adapt<CompanyEntity>(CompanyMapster.MapCompanyToAddCompanyDto());
            await _repository.Insert(company);
        }

        public async Task UpdateCompany(UpdateCompanyDto? model)
        {
            if (model == null)
            {

            }
            var company =await _repository.GetByIdAsync(model.Id);
            if (company == null)
            {

            }

            company = model.Adapt<CompanyEntity>(CompanyMapster.MapCompanyToUpdateCompanyDto());
            company.LogoPath = FileProcessing.FileUpload(model.LogoFile, model.Path, "Company");
            company.UpdateTime=DateTimeOffset.Now;
            await _repository.Update(company);
        }

        public async Task<UpdateCompanyDto> GetCompanyById(string id)
        {
           var company=await _repository.GetByIdAsync(id);
           if (company == null) { }


           UpdateCompanyDto companyDto = company.Adapt<UpdateCompanyDto>(CompanyMapster.MapCompanyToUpdateCompanyDto());
               return companyDto;
           
        }

        public async Task<bool> DeleteCompanyById(string id)
        {
            bool result = false;
            if (string.IsNullOrEmpty(id))
            {
                result = false;
            }
            var company = await _repository.GetByIdAsync(id);
            if (company != null)
            {
                company.IsDeleted = true;
                try
                {

                    await _repository.Update(company);
                    result = true;
                }
                catch (Exception e)
                {
                    result = false;
                }
            }
            return result;
        }

        public async Task<bool> BackCompanyById(string id)
        {
            bool result = false;
            if (string.IsNullOrEmpty(id))
            {
                result = false;
            }
            var company = await _repository.GetDeletedByIdAsync(id);
            if (company != null)
            {
                company.IsDeleted = false;
                try
                {

                    await _repository.Update(company);
                    result = true;
                }
                catch (Exception e)
                {
                    result = false;
                }
            }
            return result;
        }

        public async Task<bool> RemoveCompanyById(string id)
        {
            bool result = false;
            if (string.IsNullOrEmpty(id))
            {
                result = false;
            }
            var company = await _repository.GetDeletedByIdAsync(id);
            if (company != null)
            {
               
                try
                {
                    if (company.LogoPath != null) FileProcessing.RemoveFile(company.LogoPath, "Company");
                    await _repository.Delete(company);
                    result = true;
                }
                catch (Exception e)
                {
                    result = false;
                }
            }
            return result;
        }
    }
}
