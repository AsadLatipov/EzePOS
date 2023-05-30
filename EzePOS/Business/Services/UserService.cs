using EzePOS.Business.IServices;
using EzePOS.Business.Models;
using EzePOS.Infrastructure.Entities;
using EzePOS.Infrastructure.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EzePOS.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<User>> CreateAsync(User user)
        {
            BaseResponse<User> baseResponse = new BaseResponse<User>();
            var entity = await _unitOfWork.Users.GetAsync(obj => obj.Id == user.Id);

            if (entity is not null)
            {
                baseResponse.Error = new ErrorModel(400, "User is exist");
                return baseResponse;
            }


            var result = await _unitOfWork.Users.CreateAsync(user);
            await _unitOfWork.SaveChangesAsync();
            baseResponse.Data = result;
            return baseResponse;
        }

        public async Task<BaseResponse<User>> UpdateAsync(User user)
        {
            BaseResponse<User> baseResponse = new BaseResponse<User>();

            var entity = await _unitOfWork.Users.GetAsync(obj => obj.Id == user.Id);
            if (entity is null)
            {
                baseResponse.Error = new ErrorModel(404, "Customer not found");
                return baseResponse;
            }

            var result = await _unitOfWork.Users.UpdateAsync(user);
            await _unitOfWork.SaveChangesAsync();

            baseResponse.Data = result;
            return baseResponse;
        }

        public async Task<BaseResponse<User>> GetAsync(Expression<Func<User, bool>> expression)
        {
            BaseResponse<User> baseResponse = new BaseResponse<User>();

            var entity = await _unitOfWork.Users.GetAsync(expression);
            if (entity is null)
            {
                baseResponse.Error = new ErrorModel(404, "Customer not found");
                return baseResponse;
            }

            baseResponse.Data = entity;
            return baseResponse;
        }

        public async Task<BaseResponse<bool>> DeleteAsync(Expression<Func<User, bool>> expression)
        {
            BaseResponse<bool> baseResponse = new BaseResponse<bool>();
            var entity = await _unitOfWork.Users.GetAsync(expression);

            if (entity is null)
            {
                baseResponse.Error = new ErrorModel(400, "User not found");
                return baseResponse;
            }
            else
            {
                await _unitOfWork.Users.DeleteAsync(expression);
            }

            await _unitOfWork.SaveChangesAsync();

            baseResponse.Data = true;
            return baseResponse;

        }

        public async Task<BaseResponse<IEnumerable<User>>> GetAllAsync(Expression<Func<User, bool>> expression = null)
        {
            BaseResponse<IEnumerable<User>> baseResponse = new BaseResponse<IEnumerable<User>>();

            var entities = await _unitOfWork.Users.GetAllAsync(expression);
            if (entities is null)
            {
                baseResponse.Error = new ErrorModel(400, "Users not found");
                return baseResponse;
            }

            baseResponse.Data = entities.ToList();

            return baseResponse;
        }

    }
}
