using ProCar.Core.Dtos;
using ProCar.Core.ViewModels;
using ProCars.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCar.Infrastructure.Services.Users
{
    public interface IUserService
    {
        Task<string> Delete(string Id);
        Task<ResponseDto> GetAll(Pagination pagination, Query query);
        Task<UpdateUserDto> Get(string Id);
        Task<string> Create(CreateUserDto dto);
        Task<string> Update(UpdateUserDto dto);
        Task<List<UserViewModel>> GetUsersList();
        UserViewModel GetUserByUsername(string username);
    }
}
