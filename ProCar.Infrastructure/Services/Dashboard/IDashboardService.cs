using ProCar.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCar.Infrastructure.Services.Dashboard
{
    public interface IDashboardService
    {
        Task<List<PieChartViewModel>> GetContentByMonthChart();
        Task<DashboardViewModel> GetData();

    }
}
