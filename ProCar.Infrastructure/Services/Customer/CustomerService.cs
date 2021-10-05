using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProCar.Core.Dtos;
using ProCar.Core.Exceptions;
using ProCar.Core.ViewModels;
using ProCar.Data;
using ProCar.Data.Models;
using ProCars.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCar.Infrastructure.Services.Lease
{
    public class CustomerService: ICustomerService
    {
        private readonly ProCarDbContext _db;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        private readonly IEmailService _emailService;


        public CustomerService(ProCarDbContext _db, IMapper _mapper, IFileService _fileService, IEmailService _emailService)
        {
            this._db = _db;
            this._emailService = _emailService;
            this._fileService = _fileService;
            this._mapper = _mapper;

        }
        public async Task<ResponseDto> GetAll(Pagination pagination, Query query)
        {
            var queryString = _db.Customers.Include(x => x.lease).Where(x => !x.User.IsDelete).AsQueryable();

            var dataCount = queryString.Count();
            var skipValue = pagination.GetSkipValue();
            var dataList = await queryString.Skip(skipValue).Take(pagination.PerPage).ToListAsync();
            var Customers = _mapper.Map<List<CustomerViewModel>>(dataList);
            var pages = pagination.GetPages(dataCount);
            var result = new ResponseDto
            {
                data = Customers,
                meta = new Meta
                {
                    page = pagination.Page,
                    perpage = pagination.PerPage,
                    pages = pages,
                    total = dataCount,
                }
            };
            return result;
        }

        public async Task<int> Delete(int id)
        {
            var customers = await _db.Customers.SingleOrDefaultAsync(x => x.Id == id && !x.User.IsDelete);
            if (customers == null)
            {
                throw new EntityNotFoundException();
            }
            customers.User.IsDelete = true;
            _db.Users.Update(customers.User);
            await _db.SaveChangesAsync();
            return customers.Id;
        }
        public async Task<int> SingUp(CreateCustomerDto dto)
        {

            var imegeUrl = await _fileService.SaveFile(dto.LegaldocumentImeg, "Images");

            var customer = _mapper.Map<Customer>(dto);
            customer.LegaldocumentImegUrl = imegeUrl;

            await _db.Customers.AddAsync(customer);
            await _db.SaveChangesAsync();


            return customer.Id;
        }


    }
}
