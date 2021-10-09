using ProCar.Core.Dtos;
using ProCars.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCar.Infrastructure.Services.Lease
{
    public interface ILeaseService
    {

        Task<UpdateLeaseDto> Get(int id);
        Task<int> Delete(int id);

        Task<ResponseDto> GetAll(Pagination pagination, Query query);
        Task<int> Create(CreateLeaseDto dto);
        Task<int> Update(UpdateLeaseDto dto);
        Task<ResponseDto> GetCarLeases(int Id, Pagination pagination);
        Task<ResponseDto> GetUserLeases(string Id, Pagination pagination);


    }
}
