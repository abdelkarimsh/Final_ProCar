using AutoMapper;
using ProCar.Core.Dtos;
using ProCar.Core.ViewModels;
using ProCar.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCar.Infrastructure.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {

            CreateMap<Employee, EmployeeViewModel>().ForMember(x => x.UserType, x => x.MapFrom(x => x.UserType.ToString())); ;
            CreateMap<CreateEmployeeDto, Employee>().ForMember(x => x.ImageUrl, x => x.Ignore());
            CreateMap<UpdateEmployeeDto, Employee>().ForMember(x => x.ImageUrl, x => x.Ignore());
            CreateMap<Employee, UpdateEmployeeDto>().ForMember(x => x.Image, x => x.Ignore());


            CreateMap<Car, CarViewModel>();
            CreateMap<CreateCarDto, Car>().ForMember(x => x.ImegUrl, x => x.Ignore());

            //CreateMap<Customer, CustomerViewModel>();
            CreateMap<CreateCustomerDto, Customer>();


        }



}
}
