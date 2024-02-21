
using Application.DataTransferObjects.Company;
using Application.ViewModels.Company;
using Application.ViewModels.Main;

namespace Application.Services.Company
{
    public interface ICompany
    {
        Task<ListGenerics<CompanyViewModel>> GetCompaniesAsync(int page, int pageSize, string search = "");
        Task<ListGenerics<CompanyViewModel>> GetTrashCompaniesAsync(int page, int pageSize, string search = "");

        Task AddCompany(AddCompanyDto model);
        Task UpdateCompany(UpdateCompanyDto model);
        Task<UpdateCompanyDto> GetCompanyById(string id);
        Task<bool> DeleteCompanyById(string id);
        Task<bool> BackCompanyById(string id);
        Task<bool> RemoveCompanyById(string id);

        Task<List<CompanyViewModel>> GetAllAsync();
    }
}
