using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProCar.Core.Conestants;
using ProCar.Core.Dtos;
using ProCar.Core.Exceptions;
using ProCar.Data;
using ProCar.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCar.Infrastructure.Services.Users
{
    public class UserServices
    {
        private readonly ProCarDbContext _db;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IFileService _fileService;

        public UserServices(ProCarDbContext db, IMapper mapper, UserManager<User> userManager, IFileService fileService)
        {
            _db = db;
            _mapper = mapper;
            _userManager = userManager;
            _fileService = fileService;
        }







        //        public async Task<int> Delete(int id)
        //                {
        //                    var customers = await _db.Customers.SingleOrDefaultAsync(x => x.Id == id && !x.IsDelete);
        //                    if (customers == null)
        //                    {
        //                        throw new EntityNotFoundException();
        //                    }
        //                    customers.IsDelete = true;
        //                    _db.Customers.Update(customers);
        //                    await _db.SaveChangesAsync();
        //                    return customers.Id;
        //                }

        //                private string GenratePassword()
        //                {
        //                    return Guid.NewGuid().ToString().Substring(1, 8);
        //                }

        //            }


    }
}
