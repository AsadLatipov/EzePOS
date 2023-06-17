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
    public class ShopService : IShopService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ShopService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<Shop>> CreateAsync(Shop model, User user)
        {
            BaseResponse<Shop> baseResponse = new BaseResponse<Shop>();
            var entity = await _unitOfWork.Shops.GetAsync(obj => obj.Id == model.Id);

            if (entity is not null)
            {
                baseResponse.Error = new ErrorModel(400, "Shop is exist");
                return baseResponse;
            }

            model.CreatedAt = DateTime.Now;
            model.CreatedUserId = user.Id;

            var result = await _unitOfWork.Shops.CreateAsync(model);
            await _unitOfWork.SaveChangesAsync();
            baseResponse.Data = result;
            return baseResponse;
        }

        public async Task<BaseResponse<Shop>> UpdateAsync(Shop model, User user)
        {
            BaseResponse<Shop> baseResponse = new BaseResponse<Shop>();

            var entity = await _unitOfWork.Shops.GetAsync(obj => obj.Id == model.Id);
            if (entity is null)
            {
                baseResponse.Error = new ErrorModel(404, "Shop not found");
                return baseResponse;
            }

            model.UpdatedAt = DateTime.Now;
            model.UpdatedUserId = user.Id;
            model.Status = Infrastructure.Enums.ItemState.Updated;

            var result = await _unitOfWork.Shops.UpdateAsync(model);
            await _unitOfWork.SaveChangesAsync();

            baseResponse.Data = result;
            return baseResponse;
        }

        public async Task<BaseResponse<Shop>> GetAsync(Expression<Func<Shop, bool>> expression)
        {
            BaseResponse<Shop> baseResponse = new BaseResponse<Shop>();

            var entity = await _unitOfWork.Shops.GetAsync(expression);
            if (entity is null)
            {
                baseResponse.Error = new ErrorModel(404, "Shop not found");
                return baseResponse;
            }

            baseResponse.Data = entity;
            return baseResponse;
        }

        public async Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Shop, bool>> expression)
        {
            BaseResponse<bool> baseResponse = new BaseResponse<bool>();
            var entity = await _unitOfWork.Shops.GetAsync(expression);

            if (entity is null)
            {
                baseResponse.Error = new ErrorModel(400, "Shop not found");
                return baseResponse;
            }
            else
            {
                await _unitOfWork.Shops.DeleteAsync(expression);
            }

            await _unitOfWork.SaveChangesAsync();

            baseResponse.Data = true;
            return baseResponse;

        }

        public async Task<BaseResponse<IEnumerable<Shop>>> GetAllAsync(Expression<Func<Shop, bool>> expression = null)
        {
            List<Shop> categories = new List<Shop>();
            BaseResponse<IEnumerable<Shop>> baseResponse = new BaseResponse<IEnumerable<Shop>>();

            var entities = await _unitOfWork.Shops.GetAllAsync(expression);
            if (entities is null)
            {
                baseResponse.Error = new ErrorModel(400, "Shop not found");
                return baseResponse;
            }

            baseResponse.Data = entities.ToList();
            return baseResponse;
        }
    }
}
