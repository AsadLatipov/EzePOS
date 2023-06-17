using EzePOS.Business.IServices;
using EzePOS.Business.Models;
using EzePOS.Infrastructure.Entities;
using EzePOS.Infrastructure.Entities.Base;
using EzePOS.Infrastructure.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EzePOS.Business.Services
{
    public class ShopItemService : IShopItemService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ShopItemService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<ShopItem>> CreateAsync(ShopItem model, User user)
        {
            BaseResponse<ShopItem> baseResponse = new BaseResponse<ShopItem>();
            var entity = await _unitOfWork.ShopItems.GetAsync(obj => obj.Id == model.Id);

            if (entity is not null)
            {
                baseResponse.Error = new ErrorModel(400, "ShopItem is exist");
                return baseResponse;
            }

            model.CreatedAt = DateTime.Now;
            model.CreatedUserId = user.Id;

            var result = await _unitOfWork.ShopItems.CreateAsync(model);
            await _unitOfWork.SaveChangesAsync();
            baseResponse.Data = result;
            return baseResponse;
        }

        public async Task<BaseResponse<ShopItem>> UpdateAsync(ShopItem model, User user)
        {
            BaseResponse<ShopItem> baseResponse = new BaseResponse<ShopItem>();

            var entity = await _unitOfWork.ShopItems.GetAsync(obj => obj.Id == model.Id);
            if (entity is null)
            {
                baseResponse.Error = new ErrorModel(404, "ShopItem not found");
                return baseResponse;
            }

            model.UpdatedAt = DateTime.Now;
            model.UpdatedUserId = user.Id;
            model.Status = Infrastructure.Enums.ItemState.Updated;

            var result = await _unitOfWork.ShopItems.UpdateAsync(model);
            await _unitOfWork.SaveChangesAsync();

            baseResponse.Data = result;
            return baseResponse;
        }

        public async Task<BaseResponse<ShopItem>> GetAsync(Expression<Func<ShopItem, bool>> expression)
        {
            BaseResponse<ShopItem> baseResponse = new BaseResponse<ShopItem>();

            var entity = await _unitOfWork.ShopItems.GetAsync(expression);
            if (entity is null)
            {
                baseResponse.Error = new ErrorModel(404, "ShopItem not found");
                return baseResponse;
            }

            baseResponse.Data = entity;
            return baseResponse;
        }

        public async Task<BaseResponse<bool>> DeleteAsync(Expression<Func<ShopItem, bool>> expression)
        {
            BaseResponse<bool> baseResponse = new BaseResponse<bool>();
            var entity = await _unitOfWork.ShopItems.GetAsync(expression);

            if (entity is null)
            {
                baseResponse.Error = new ErrorModel(400, "ShopItem not found");
                return baseResponse;
            }
            else
            {
                await _unitOfWork.ShopItems.DeleteAsync(expression);
            }

            await _unitOfWork.SaveChangesAsync();

            baseResponse.Data = true;
            return baseResponse;

        }

        public async Task<BaseResponse<IEnumerable<ShopItem>>> GetAllAsync(Expression<Func<ShopItem, bool>> expression = null)
        {
            List<ShopItem> categories = new List<ShopItem>();
            BaseResponse<IEnumerable<ShopItem>> baseResponse = new BaseResponse<IEnumerable<ShopItem>>();

            var entities = await _unitOfWork.ShopItems.GetAllAsync(expression);
            if (entities is null)
            {
                baseResponse.Error = new ErrorModel(400, "ShopItem not found");
                return baseResponse;
            }

            baseResponse.Data = entities.ToList();
            return baseResponse;
        }
    }
}
