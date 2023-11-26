using Application.ViewModels.Dashboard;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Dashboard
{
    public class Dashboard : IDashboard
    {
        private readonly IDapper<DashboardViewModel> _dapper;
        public Dashboard(IDapper<DashboardViewModel> dapper)
        {
            _dapper=dapper;
        }
        public async Task<DashboardViewModel> GetDashboardAsync()
        {
            var result = await _dapper.ExecuteSP("Dashboard");
            return result;
        }
    }
}
