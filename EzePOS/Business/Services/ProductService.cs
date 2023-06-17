using EzePOS.Business.IServices;
using EzePOS.Business.Models;
using EzePOS.Infrastructure.Entities;
using EzePOS.Infrastructure.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace EzePOS.Business.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<Product>> CreateAsync(Product model, User user)
        {
            BaseResponse<Product> baseResponse = new BaseResponse<Product>();
            var entity = await _unitOfWork.Products.GetAsync(obj => obj.Id == model.Id);

            var temp = await _unitOfWork.Products.GetAsync(obj => obj.Name.ToLower() == model.Name.ToLower() || obj.Barcode.ToLower() == model.Barcode.ToLower());
            if (entity != null || temp != null)
            {
                baseResponse.Error = new ErrorModel(400, "Product is exist");
                return baseResponse;
            }

            model.CreatedUserId = user.Id;
            model.CreatedAt = DateTime.Now;

            var result = await _unitOfWork.Products.CreateAsync(model);
            await _unitOfWork.SaveChangesAsync();
            baseResponse.Data = result;
            return baseResponse;
        }

        public async Task<BaseResponse<Product>> UpdateAsync(Product model, User user)
        {
            BaseResponse<Product> baseResponse = new BaseResponse<Product>();

            var entity = await _unitOfWork.Products.GetAsync(obj => obj.Id == model.Id);
            if (entity is null)
            {
                baseResponse.Error = new ErrorModel(404, "Product not found");
                return baseResponse;
            }

            var temp = await _unitOfWork.Products.GetAllAsync(obj => obj.Name.ToLower() == model.Name.ToLower() || obj.Barcode.ToLower() == model.Barcode.ToLower());
            foreach(var item in temp)
            {
                if(item.Id != model.Id)
                {
                    baseResponse.Error = new ErrorModel(400, "This kind of Barcode or Name exist");
                    return baseResponse;
                }
            }
           

            model.UpdatedUserId = user.Id;
            model.UpdatedAt = DateTime.Now;
            model.Status = Infrastructure.Enums.ItemState.Updated;


            var result = await _unitOfWork.Products.UpdateAsync(model);
            await _unitOfWork.SaveChangesAsync();

            baseResponse.Data = result;
            return baseResponse;
        }

        public async Task<BaseResponse<Product>> GetAsync(Expression<Func<Product, bool>> expression)
        {
            BaseResponse<Product> baseResponse = new BaseResponse<Product>();

            var entity = await _unitOfWork.Products.GetAsync(expression);
            if (entity is null)
            {
                baseResponse.Error = new ErrorModel(404, "Product not found");
                return baseResponse;
            }
            //var entity = products.AsQueryable<Product>().Where(expression).FirstOrDefault();
            baseResponse.Data = entity;
            return baseResponse;
        }

        public async Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Product, bool>> expression)
        {
            BaseResponse<bool> baseResponse = new BaseResponse<bool>();
            var entity = await _unitOfWork.Products.GetAsync(expression);

            if (entity is null)
            {
                baseResponse.Error = new ErrorModel(400, "Product not found");
                return baseResponse;
            }
            else
            {
                await _unitOfWork.Products.DeleteAsync(expression);
            }
            
            await _unitOfWork.SaveChangesAsync();

            baseResponse.Data = true;
            return baseResponse;

        }

        public async Task<BaseResponse<IEnumerable<Product>>> GetAllAsync(Expression<Func<Product, bool>> expression = null)
        {

            BaseResponse<IEnumerable<Product>> baseResponse = new BaseResponse<IEnumerable<Product>>();

            var entities = await _unitOfWork.Products.GetAllAsync(expression);
            if (entities is null)
            {
                baseResponse.Error = new ErrorModel(400, "Products not found");
                return baseResponse;
            }
            //products = new List<Product>();
            //products.Add(new Product() { Id = 1, CategoryId = 1, Name = "Coca-Cola", Price = 11000});
            //products.Add(new Product() { Id = 2, CategoryId = 1, Name = "Fanta", Price = 10000 });
            //products.Add(new Product() { Id = 3, CategoryId = 1, Name = "Flash", Price = 7000 });
            //products.Add(new Product() { Id = 4, CategoryId = 1, Name = "Gorilla", Price = 8000 });
            //products.Add(new Product() { Id = 5, CategoryId = 1, Name = "Hydrolife", Price = 3000 });

            //products.Add(new Product() { Id = 6, CategoryId = 2, Name = "ChocoPie", Price = 20000});
            //products.Add(new Product() { Id = 7, CategoryId = 2, Name = "Sneakers", Price = 5000 });
            //products.Add(new Product() { Id = 8, CategoryId = 2, Name = "Alpen Gold", Price = 6000 });
            //products.Add(new Product() { Id = 9, CategoryId = 2, Name = "Kinder", Price = 4000 });
            //products.Add(new Product() { Id = 10, CategoryId = 2, Name = "Shirinlik", Price = 20000 });

            //products.Add(new Product() { Id = 11, CategoryId = 3, Name = "Sabzi", Price = 3000, Measure = Infrastructure.Enums.Measure.kg});
            //products.Add(new Product() { Id = 12, CategoryId = 3, Name = "Kartoshka", Price = 4500, Measure = Infrastructure.Enums.Measure.kg });
            //products.Add(new Product() { Id = 13, CategoryId = 3, Name = "Karam", Price = 4500, Measure = Infrastructure.Enums.Measure.kg });
            //products.Add(new Product() { Id = 14, CategoryId = 3, Name = "Bodring", Price = 7000 , Measure = Infrastructure.Enums.Measure.kg });
            //products.Add(new Product() { Id = 15, CategoryId = 3, Name = "Piyoz", Price = 2000 , Measure = Infrastructure.Enums.Measure.kg });

            //products.Add(new Product() { Id = 16, CategoryId = 4, Name = "Olma", Price = 6000, Measure = Infrastructure.Enums.Measure.kg });
            //products.Add(new Product() { Id = 17, CategoryId = 4, Name = "Banan", Price = 15000, Measure = Infrastructure.Enums.Measure.kg });
            //products.Add(new Product() { Id = 18, CategoryId = 4, Name = "Uzum", Price = 7000, Measure = Infrastructure.Enums.Measure.kg });
            //products.Add(new Product() { Id = 19, CategoryId = 4, Name = "Shaftoli", Price = 44000, Measure = Infrastructure.Enums.Measure.kg });
            //products.Add(new Product() { Id = 20, CategoryId = 4, Name = "Qulupnay", Price = 50000, Measure = Infrastructure.Enums.Measure.kg });

            baseResponse.Data = entities.ToList();
            //baseResponse.Data = products.AsQueryable<Product>().Where(expression);


            return baseResponse;
        }

    }
}
