using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProCar.Core.Conestants;
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


namespace ProCar.Infrastructure.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ProCarDbContext _db;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        private readonly IEmailService _emailService;
        private readonly UserManager<User> _userManager;

        public EmployeeService(UserManager<User> _userManager, ProCarDbContext _db, IMapper _mapper, IFileService _fileService, IEmailService _emailService)
        {
            this._db = _db;
            this._emailService = _emailService;
            this._fileService = _fileService;
            this._mapper = _mapper;
            this._userManager = _userManager;
        }

        public async Task<ResponseDto> GetAll(Pagination pagination, Query query)
        {
            var queryString = _db.Employees.Include(x=>x.User).Where(x => !x.User.IsDelete && (x.Name.Contains(query.GeneralSearch) || string.IsNullOrWhiteSpace(query.GeneralSearch) || x.User.Email.Contains(query.GeneralSearch) || x.User.PhoneNumber.Contains(query.GeneralSearch))).AsQueryable();

            var dataCount = queryString.Count();
            var skipValue = pagination.GetSkipValue();
            var dataList = await queryString.Skip(skipValue).Take(pagination.PerPage).ToListAsync();
            var users = _mapper.Map<List<EmployeeViewModel>>(dataList);
            var pages = pagination.GetPages(dataCount);
            var result = new ResponseDto
            {
                data = users,
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


        public async Task<int> Create(CreateEmployeeDto dto)
        {
            var emailOrPhoneIsExist = _db.Employees.Any(x => !x.User.IsDelete && (x.User.Email == dto.Email || x.User.PhoneNumber == dto.PhoneNumber));

            if (emailOrPhoneIsExist)
            {
                throw new DuplicateEmailOrPhoneException();
            }

            var user = _mapper.Map<Employee>(dto);
            user.User.UserName = dto.Email;
            user.User.Email = dto.Email;
            user.User.PhoneNumber = dto.PhoneNumber;

            if (dto.Image != null)
            {
                user.ImageUrl = await _fileService.SaveFile(dto.Image, FolderNames.ImagesFolder);
            }

            var password = GenratePassword();

            try
            {
                var result = await _userManager.CreateAsync(user.User, password);

                if (!result.Succeeded)
                {
                    throw new OperationFailedException();
                }

            }
            catch (Exception e)
            {

            }


            await _emailService.Send(user.User.Email, "New Account !", $"Username is : {user.User.Email} and Password is { password }");

            return user.Id;
        }

        public async Task<int> Update(UpdateEmployeeDto dto)
        {
            var emailOrPhoneIsExist = _db.Employees.Any(x => !x.User.IsDelete && (x.User.Email == dto.Email || x.User.PhoneNumber == dto.PhoneNumber) && x.Id != dto.Id);
            if (emailOrPhoneIsExist)
            {
                throw new DuplicateEmailOrPhoneException();
            }
            var user = await _db.Employees.FindAsync(dto.Id);
            var updatedUser = _mapper.Map<UpdateEmployeeDto, Employee>(dto, user);
            updatedUser.User.Email = dto.Email;
            updatedUser.User.PhoneNumber = dto.PhoneNumber;
            if (dto.Image != null)
            {
                updatedUser.ImageUrl = await _fileService.SaveFile(dto.Image, FolderNames.ImagesFolder);
            }
            _db.Employees.Update(updatedUser);
            await _db.SaveChangesAsync();
            return user.Id;
        }

        public async Task<int> Delete(int Id)
        {
            var user = await _db.Employees.SingleOrDefaultAsync(x => x.Id == Id && !x.User.IsDelete);
            if (user == null)
            {
                throw new EntityNotFoundException();
            }
            user.User.IsDelete = true;
            _db.Users.Update(user.User);
            await _db.SaveChangesAsync();
            return user.Id;
        }


        public async Task<UpdateEmployeeDto> Get(int Id)
        {
            var user = await _db.Employees.SingleOrDefaultAsync(x => x.Id == Id && !x.User.IsDelete);
            if (user == null)
            {
                throw new EntityNotFoundException();
            }
            var result= _mapper.Map<UpdateEmployeeDto>(user);
            result.PhoneNumber = user.User.PhoneNumber;
            result.Email = user.User.Email;
            return result;
        }



        private string GenratePassword()
        {
            return Guid.NewGuid().ToString().Substring(1, 8);
        }










    }
}
