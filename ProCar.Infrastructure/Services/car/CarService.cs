using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProCar.Core.Dtos;
using ProCar.Core.Dtos.Helpers;
using ProCar.Core.Exceptions;
using ProCar.Core.ViewModels;
using ProCar.Data;
using ProCar.Data.Models;
using ProCar.Infrastructure.Services.car;
using ProCars.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCar.Infrastructure.Services
{
    public class CarService: ICarService
    {

        private readonly ProCarDbContext _db;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        private readonly IEmailService _emailService;


        public CarService( ProCarDbContext _db, IMapper _mapper, IFileService _fileService, IEmailService _emailService)
        {
            this._db = _db;
            this._emailService = _emailService;
            this._fileService = _fileService;
            this._mapper = _mapper;
         
        }
        public  async Task<ResponseDto> GetAllCars(Pagination pagination, Query query)
        {
            var carObject = _db.Cars.Include(x => x.lease).Where(x => !x.IsDelete).AsQueryable();
            var dataCount = carObject.Count();
            var skipValue = pagination.GetSkipValue();
            var dataList = await carObject.Skip(skipValue).Take(pagination.PerPage).ToListAsync();
            var cars = _mapper.Map<List<CarViewModel>>(dataList);
            var pages = pagination.GetPages(dataCount);
            var result = new ResponseDto
            {
                data = cars,
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
            var car = await _db.Cars.SingleOrDefaultAsync(x => x.Id == id && !x.IsDelete);
            if (car == null)
            {
                throw new EntityNotFoundException();
            }
            car.IsDelete = true;
            _db.Cars.Update(car);
            await _db.SaveChangesAsync();
            return car.Id;
        }
        public async Task<UpdateCarDto> Get(int id)
        {
            var car = await _db.Cars.SingleOrDefaultAsync(x => x.Id == id && !x.IsDelete);
            if (car == null)
            {
                throw new EntityNotFoundException();
            }
            return _mapper.Map<UpdateCarDto>(car);
        }
        public async Task<int> Create(CreateCarDto dto)
        {
            var imegeUrl = await _fileService.SaveFile(dto.Imeg, "Images");
            var car = _mapper.Map<Car>(dto);
            car.ImegUrl = imegeUrl;


            await _db.Cars.AddAsync(car);
            await _db.SaveChangesAsync();
            return car.Id;
        }


        public async Task<List<CarViewModel>> GetbusyCars()
        {
            var carbusy = await _db.Cars.Where(x => x.CarStatus == ProCars.Core.Enums.CarStatus.Busy && !x.IsDelete).ToListAsync();
            if (carbusy == null)
            {
                throw new CarBusyNotFoundException();
            }
            return _mapper.Map<List<CarViewModel>>(carbusy);
        }
        public async Task<List<CarViewModel>> GetInServiceCars()
        {
            var carbusy = await _db.Cars.Where(x => x.CarStatus == ProCars.Core.Enums.CarStatus.InService && !x.IsDelete).ToListAsync();
            if (carbusy == null)
            {
                throw new CarInServiceNotFoundException();
            }
            return _mapper.Map<List<CarViewModel>>(carbusy);
        }


        //اضافة حالة السيارة 

        public async Task<List<CarViewModel>> GetCarsList()
        {
            var cars = await _db.Cars.Where(x => !x.IsDelete).ToListAsync();
            return _mapper.Map<List<CarViewModel>>(cars);
        }






    }
}
