using ProCar.Core.Dtos;
using ProCar.Core.ViewModels;
using ProCars.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCar.Infrastructure.Services.car
{
    public interface ICarService
    {
        Task<ResponseDto> GetAllCars(Pagination pagination, Query query);
        Task<int> Delete(int id);
        Task<int> Create(CreateCarDto dto);
        Task<List<CarViewModel>> GetbusyCars();
        Task<List<CarViewModel>> GetInServiceCars();
        Task<List<CarViewModel>> GetCarsList();
    }
}
