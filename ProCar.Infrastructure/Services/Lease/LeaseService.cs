using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProCar.Core.Dtos;
using ProCar.Core.Exceptions;
using ProCar.Core.ViewModels;
using ProCar.Data;
using ProCar.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCar.Infrastructure.Services.Lease
{
    public class LeaseService
    {
        private readonly ProCarDbContext _db;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        private readonly IEmailService _emailService;
 

        public LeaseService( ProCarDbContext _db, IMapper _mapper, IFileService _fileService, IEmailService _emailService)
        {
            this._db = _db;
            this._emailService = _emailService;
            this._fileService = _fileService;
            this._mapper = _mapper;
            
        }

        //public async Task<UpdateLeaseDto> Get(int id)
        //{
        //    var lease = await _db.leases.SingleOrDefaultAsync(x => x.Id == id && !x.IsDelete);
        //    if (lease == null)
        //    {
        //        throw new EntityNotFoundException();
        //    }
        //    return _mapper.Map<UpdateLeaseDto>(lease);
        //}

        public async Task<int> Delete(int id)
        {
            var lease = await _db.leases.SingleOrDefaultAsync(x => x.Id == id && !x.IsDelete);
            if (lease == null)
            {
                throw new EntityNotFoundException();
            }
            lease.IsDelete = true;
            _db.leases.Update(lease);
            await _db.SaveChangesAsync();
            return lease.Id;
        }

        /// ليش استخدمنا update
        public async Task<UpdateLeaseDto>Get(int id)
        {
            var dto = _db.leases.SingleOrDefault(x => x.Id == id);
            if (dto == null)
            {
                throw new EntityNotFoundException();
            }
            return _mapper.Map<UpdateLeaseDto>(dto);
        }
        //inclode 
        public async Task<List<LeaseViewModel>> GetCustomerLeases(Customer customer)
        {
            var Leases =await _db.leases.Include(x => x.Customer).Where(x => !x.IsDelete && x.CustomerId == customer.Id).ToListAsync();
            var result = _mapper.Map<List<LeaseViewModel>>(Leases);
            return result;
        }
        //التأكيد 
        public async Task<List<LeaseViewModel>> GetCarLeases(Car car)
        {
            var Leases = await _db.leases.Include(x => x.Car).Where(x => !x.IsDelete && x.CarId == car.Id).ToListAsync();
            var result = _mapper.Map<List<LeaseViewModel>>(Leases);
            return result;
        }
        //public async Task<AccountantViewModel> GetAccountStatement()
        //{
          
        //}




    }
}
