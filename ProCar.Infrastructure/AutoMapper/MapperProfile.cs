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

            CreateMap<User, UserViewModel>().ForMember(x => x.CreatedAt, x => x.ToString()).ForMember(x => x.lease, x => x.Ignore()).ForMember(x => x.Type, x => x.MapFrom(x => x.Type.ToString()));
            CreateMap<CreateUserDto, User>().ForMember(x => x.ImageUrl, x => x.Ignore());
            CreateMap<UpdateUserDto, User>().ForMember(x => x.ImageUrl, x => x.Ignore()); 
            CreateMap<User, UpdateUserDto>().ForMember(x => x.Imege, x => x.Ignore());

            CreateMap<Car, CarViewModel>().ForMember(x => x.MakerName, x => x.MapFrom(x => x.MakerName.ToString())).ForMember(x => x.ColorId, x => x.MapFrom(x => x.ColorId.ToString()));
            CreateMap<CreateCarDto, Car>().ForMember(x => x.ImegUrl, x => x.Ignore());


            CreateMap<Leases, LeaseViewModel>().ForMember(x => x.leasestatus, x => x.ToString()).ForMember(x => x.Approval, x => x.ToString()).ForMember(x => x.LegaldocumentImegUrl, x => x.Ignore()).ForMember(x => x.StartRent, x => x.MapFrom(x => x.StartRent.ToString("yyyy:MM:dd"))).ForMember(x => x.EndRent, x => x.MapFrom(x => x.EndRent.ToString("yyyy:MM:dd")));
            CreateMap<CreateLeaseDto, Leases>().ForMember(x => x.leasestatus, x => x.Ignore()).ForMember(x => x.LegaldocumentImegUrl, x => x.Ignore()).ForMember(x => x.TotalPrice, x => x.Ignore());
            CreateMap<UpdateLeaseDto, Leases>().ForMember(x => x.LegaldocumentImegUrl, x => x.Ignore());
            CreateMap<Leases, UpdateLeaseDto>().ForMember(x => x.LegaldocumentImeg, x => x.Ignore());

        }



}
}
