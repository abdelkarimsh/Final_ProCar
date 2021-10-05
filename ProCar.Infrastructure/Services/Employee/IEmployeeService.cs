using ProCar.Core.Dtos;
using ProCars.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCar.Infrastructure.Services
{
    public interface IEmployeeService
    {
        Task<ResponseDto> GetAll(Pagination pagination, Query query);
        Task<int> Create(CreateEmployeeDto dto);
        Task<int> Update(UpdateEmployeeDto dto);
        Task<int> Delete(int Id);
        Task<UpdateEmployeeDto> Get(int Id);
    }
}
