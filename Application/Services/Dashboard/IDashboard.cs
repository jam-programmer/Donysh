using Application.ViewModels.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Dashboard
{
    public interface IDashboard
    {
        Task<DashboardViewModel> GetDashboardAsync();
    }
}
