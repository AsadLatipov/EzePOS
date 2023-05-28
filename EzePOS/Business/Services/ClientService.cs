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
    
    public class ClientService : IClientService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClientService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<Client>> CreateAsync(Client model, User user)
        {
            BaseResponse<Client> baseResponse = new BaseResponse<Client>();
            var entity = await _unitOfWork.Clients.GetAsync(obj => obj.Id == model.Id);

            if (entity is not null)
            {
                baseResponse.Error = new ErrorModel(400, "Client is exist");
                return baseResponse;
            }

            model.CreatedAt = DateTime.Now;
            model.CreatedUserId = user.Id;

            var result = await _unitOfWork.Clients.CreateAsync(model);
            await _unitOfWork.SaveChangesAsync();
            baseResponse.Data = result;
            return baseResponse;
        }

        public async Task<BaseResponse<Client>> UpdateAsync(Client model, User user)
        {
            BaseResponse<Client> baseResponse = new BaseResponse<Client>();

            var entity = await _unitOfWork.Clients.GetAsync(obj => obj.Id == model.Id);
            if (entity is null)
            {
                baseResponse.Error = new ErrorModel(404, "Client not found");
                return baseResponse;
            }

            model.UpdatedAt = DateTime.Now;
            model.UpdatedUserId = user.Id;
            model.Status = Infrastructure.Enums.ItemState.Updated;

            var result = await _unitOfWork.Clients.UpdateAsync(model);
            await _unitOfWork.SaveChangesAsync();

            baseResponse.Data = result;
            return baseResponse;
        }

        public async Task<BaseResponse<Client>> GetAsync(Expression<Func<Client, bool>> expression)
        {
            BaseResponse<Client> baseResponse = new BaseResponse<Client>();

            var entity = await _unitOfWork.Clients.GetAsync(expression);
            if (entity is null)
            {
                baseResponse.Error = new ErrorModel(404, "Client not found");
                return baseResponse;
            }

            baseResponse.Data = entity;
            return baseResponse;
        }

        public async Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Client, bool>> expression)
        {
            BaseResponse<bool> baseResponse = new BaseResponse<bool>();
            var entity = await _unitOfWork.Clients.GetAsync(expression);

            if (entity is null)
            {
                baseResponse.Error = new ErrorModel(400, "Client not found");
                return baseResponse;
            }

            await _unitOfWork.SaveChangesAsync();

            baseResponse.Data = true;
            return baseResponse;

        }

        public async Task<BaseResponse<IEnumerable<Client>>> GetAllAsync(Expression<Func<Client, bool>> expression = null)
        {
            List<Client> categories = new List<Client>();
            BaseResponse<IEnumerable<Client>> baseResponse = new BaseResponse<IEnumerable<Client>>();

            var entities = await _unitOfWork.Clients.GetAllAsync(expression);
            if (entities is null)
            {
                baseResponse.Error = new ErrorModel(400, "Client not found");
                return baseResponse;
            }

            baseResponse.Data = entities.ToList();
            return baseResponse;
        }

    }
}
