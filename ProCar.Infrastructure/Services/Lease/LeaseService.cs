using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProCar.Core.Conestants;
using ProCar.Core.Dtos;
using ProCar.Core.Exceptions;
using ProCar.Core.ViewModels;
using ProCar.Data;
using ProCar.Data.Models;
using ProCar.Infrastructure.Services.Lease;
using ProCars.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCar.Infrastructure.Services.Lease
{
    public class LeaseService: ILeaseService
    {
        private readonly ProCarDbContext _db;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        private readonly IEmailService _emailService;


        public LeaseService(ProCarDbContext _db, IMapper _mapper, IFileService _fileService, IEmailService _emailService)
        {
            this._db = _db;
            this._emailService = _emailService;
            this._fileService = _fileService;
            this._mapper = _mapper;

        }

        public async Task<UpdateLeaseDto> Get(int id)
        {
            var lease = await _db.leases.Include(x => x.Car).Include(c => c.User).SingleOrDefaultAsync(x => x.Id == id && !x.IsDelete);
            if (lease == null)
            {
                throw new EntityNotFoundException();
            }
            return _mapper.Map<UpdateLeaseDto>(lease);
        }

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

        public async Task<ResponseDto> GetAll(Pagination pagination, Query query)
        {
            var queryString = _db.leases.Include(x => x.User).Include(x => x.Car).Where(x => !x.IsDelete).AsQueryable();
            var dataCount = queryString.Count();
            var skipValue = pagination.GetSkipValue();
            var dataList = await queryString.Skip(skipValue).Take(pagination.PerPage).ToListAsync();
            var Leases = _mapper.Map<List<LeaseViewModel>>(dataList);
            var pages = pagination.GetPages(dataCount);
            var result = new ResponseDto
            {
                data = Leases,
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

        public async Task<int> Create(CreateLeaseDto dto)
        {
            var lease = _mapper.Map<Leases>(dto);
            if (dto.LegaldocumentImeg != null)
            {
                lease.LegaldocumentImegUrl = await _fileService.SaveFile(dto.LegaldocumentImeg, FolderNames.ImagesFolder);
            }
            await _db.leases.AddAsync(lease);
            await _db.SaveChangesAsync();
            return lease.Id;

        }

        public async Task<int> Update(UpdateLeaseDto dto)
        {
            var lease =await _db.leases.Include(x => x.User).Include(x => x.Car).SingleOrDefaultAsync(x => x.Id == dto.Id && !x.IsDelete);
            if (lease == null)
            {
                throw new EntityNotFoundException();
            }
            var updatedlease = _mapper.Map(dto, lease);
            if (dto.LegaldocumentImeg != null)
            {
                updatedlease.LegaldocumentImegUrl= await _fileService.SaveFile(dto.LegaldocumentImeg, "Images");
            }
            _db.leases.Update(lease);
            await _db.SaveChangesAsync();
            return lease.Id;


        }




        public async Task<ResponseDto> GetCarLeases(int Id, Pagination pagination)
        {
            var Leases = _db.leases.Include(x => x.Car).Where(x => !x.IsDelete && x.CarId == Id).AsQueryable();

            var dataCount = Leases.Count();
            var skipValue = pagination.GetSkipValue();
            var dataList = await Leases.Skip(skipValue).Take(pagination.PerPage).ToListAsync();
            var leases = _mapper.Map<List<LeaseViewModel>>(dataList);
            var pages = pagination.GetPages(dataCount);
            var result = new ResponseDto
            {
                data = leases,
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




        public async Task<ResponseDto> GetUserLeases(string Id, Pagination pagination)
        {
            var Leases =  _db.leases.Include(x => x.User).Where(x => !x.IsDelete && x.UserId ==Id).AsQueryable();

            var dataCount = Leases.Count();
            var skipValue = pagination.GetSkipValue();
            var dataList = await Leases.Skip(skipValue).Take(pagination.PerPage).ToListAsync();
            var leases = _mapper.Map<List<LeaseViewModel>>(dataList);
            var pages = pagination.GetPages(dataCount);
            var result = new ResponseDto
            {
                data = leases,
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
    }
}
