using Application.ViewModels.Dashboard;
using Domain.Interfaces;

using Application.ViewModels.EmploymentAdvertisement;
using Domain.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Dashboard
{
    public class Dashboard : IDashboard
    {
        private readonly IDapper<DashboardViewModel> _dapper;
        private readonly IRepository<EmploymentAdvertisementEntity> _employment;

        public Dashboard(IDapper<DashboardViewModel> dapper, IRepository<EmploymentAdvertisementEntity> employment)
        {
            _dapper = dapper;
            _employment = employment;
        }

        public async Task<List<RequestEmployment>> GetLastResumes()
        {
            var query = await _employment.GetByQuery();
           var list=await query.Where(w=>w.IsDeleted==false && w.Active == true ).Include(i => i.Resumes).ToListAsync();

           List<RequestEmployment> employments = list.Adapt< List<RequestEmployment>>();
           return employments;
        }

        public async Task<DashboardViewModel> GetDashboardAsync()
        {
            var result = await _dapper.ExecuteSP("Dashboard");
            return result;
        }
    }
}
