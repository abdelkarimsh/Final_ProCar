using ProCar.Core.Dtos;
using ProCars.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCar.Infrastructure.Services.Lease
{
    public interface ICustomerService
    {
        Task<ResponseDto> GetAll(Pagination pagination, Query query);
        Task<int> Delete(int id);
        Task<int> SingUp(CreateCustomerDto dto);
    }
}
