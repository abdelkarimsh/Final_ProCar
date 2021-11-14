using Microsoft.EntityFrameworkCore;
using ProCar.Core.Enums;
using ProCar.Core.ViewModels;
using ProCar.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCar.Infrastructure.Services.Dashboard
{
    public class DashboardService: IDashboardService
    {
        private readonly ProCarDbContext _db;

        public DashboardService(ProCarDbContext db)
        {
            _db = db;
        }

        public async Task<DashboardViewModel> GetData()
        {
            var data = new DashboardViewModel();
            data.NumberOfUsers = await _db.Users.CountAsync(x => !x.IsDelete);
            data.NumberOfCars = await _db.Cars.CountAsync(x => !x.IsDelete);
            data.NumberOflease = await _db.leases.CountAsync(x => !x.IsDelete);
            return data;
        }

        public async Task<List<PieChartViewModel>> GetContentByMonthChart()
        {

            var data = new List<PieChartViewModel>();
            data.Add(new PieChartViewModel()
            {
                Key = "Jan",
                Value = _db.leases.Where(x => !x.IsDelete && x.StartRent.Date.Month == 1).Count(),
                color = GenrateColor()
            });
            data.Add(new PieChartViewModel()
            {
                Key = "Feb",
                Value = _db.leases.Where(x => !x.IsDelete && x.StartRent.Date.Month == 2).Count(),
                color = GenrateColor()
            });
            data.Add(new PieChartViewModel()
            {
                Key = "Mar",
                Value = _db.leases.Where(x => !x.IsDelete && x.StartRent.Date.Month == 3).Count(),
                color = GenrateColor()
            });
            data.Add(new PieChartViewModel()
            {
                Key = "Apr",
                Value = _db.leases.Where(x => !x.IsDelete && x.StartRent.Date.Month == 4).Count(),
                color = GenrateColor()
            });
            data.Add(new PieChartViewModel()
            {
                Key = "May",
                Value = _db.leases.Where(x => !x.IsDelete && x.StartRent.Date.Month == 5).Count(),
                color = GenrateColor()
            });
            data.Add(new PieChartViewModel()
            {
                Key = "Jun",
                Value = _db.leases.Where(x => !x.IsDelete && x.StartRent.Date.Month == 6).Count(),
                color = GenrateColor()
            });
            data.Add(new PieChartViewModel()
            {
                Key = "Jul",
                Value = _db.leases.Where(x => !x.IsDelete && x.StartRent.Date.Month == 7).Count(),
                color = GenrateColor()
            });
            data.Add(new PieChartViewModel()
            {
                Key = "Aug",
                Value = _db.leases.Where(x => !x.IsDelete && x.StartRent.Date.Month == 8).Count(),
                color = GenrateColor()
            });
            data.Add(new PieChartViewModel()
            {
                Key = "Sep",
                Value = _db.leases.Where(x => !x.IsDelete && x.StartRent.Date.Month == 9).Count(),
                color = GenrateColor()
            });
            data.Add(new PieChartViewModel()
            {
                Key = "Oct",
                Value = _db.leases.Where(x => !x.IsDelete && x.StartRent.Date.Month == 10).Count(),
                color = GenrateColor()
            });
            data.Add(new PieChartViewModel()
            {
                Key = "Nov",
                Value = _db.leases.Where(x => !x.IsDelete && x.StartRent.Date.Month == 11).Count(),
                color = GenrateColor()
            });
            data.Add(new PieChartViewModel()
            {
                Key = "Dec",
                Value = _db.leases.Where(x => !x.IsDelete && x.StartRent.Date.Month == 12).Count(),
                color = GenrateColor()
            });

            return data;
        }

        private string GenrateColor()
        {
            var random = new Random();
            return String.Format("#{0:X6}", random.Next(0x1000000));
        }

        public async Task<List<PieChartViewModel>> GetCarsTypeChartData()
        {

            var data = new List<PieChartViewModel>();
            data.Add(new PieChartViewModel()
            {
                Key = "Golf",
                Value = await _db.Cars.Where(x => x.MakerName == MakerName.Golf).CountAsync(x => !x.IsDelete),
                color = GenrateColor()
            });
            data.Add(new PieChartViewModel()
            {
                Key = "Honda",
                Value = await _db.Cars.Where(x => x.MakerName == MakerName.Honda).CountAsync(x => !x.IsDelete),
                color = GenrateColor()
            });
            data.Add(new PieChartViewModel()
            {
                Key = "Mazda",
                Value = await _db.Cars.Where(x => x.MakerName == MakerName.Mazda).CountAsync(x => !x.IsDelete),
                color = GenrateColor()
            });
            data.Add(new PieChartViewModel()
            {
                Key = "Mitsubishi",
                Value = await _db.Cars.Where(x => x.MakerName == MakerName.Mitsubishi).CountAsync(x => !x.IsDelete),
                color = GenrateColor()
            });
            data.Add(new PieChartViewModel()
            {
                Key = "Nissan",
                Value = await _db.Cars.Where(x => x.MakerName == MakerName.Nissan).CountAsync(x => !x.IsDelete),
                color = GenrateColor()
            });
            data.Add(new PieChartViewModel()
            {
                Key = "Skoda",
                Value = await _db.Cars.Where(x => x.MakerName == MakerName.Skoda).CountAsync(x => !x.IsDelete),
                color = GenrateColor()
            });
            data.Add(new PieChartViewModel()
            {
                Key = "Toyota",
                Value = await _db.Cars.Where(x => x.MakerName == MakerName.Toyota).CountAsync(x => !x.IsDelete),
                color = GenrateColor()
            });


            return data;
        }





    }




}
