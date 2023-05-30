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
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<Category>> CreateAsync(Category model, User user)
        {
            BaseResponse<Category> baseResponse = new BaseResponse<Category>();
            var entity = await _unitOfWork.Categories.GetAsync(obj => obj.Id == model.Id);

            if (entity is not null)
            {
                baseResponse.Error = new ErrorModel(400, "Category is exist");
                return baseResponse;
            }

            model.CreatedAt = DateTime.Now;
            model.CreatedUserId = user.Id;

            var result = await _unitOfWork.Categories.CreateAsync(model);
            await _unitOfWork.SaveChangesAsync();
            baseResponse.Data = result;
            return baseResponse;


            //await targetWindow._productService.CreateAsync(new Product { CategoryId = 1, Name = "Coca-Cola", IncomePrice = 10000, SellingPrice = 11000 }, new User { Id = 1, FirstName = "asadbek", LastName = "latipov" });
            //await targetWindow._productService.CreateAsync(new Product { CategoryId = 1, Name = "Fanta", IncomePrice = 10000, SellingPrice = 11000 }, new User { Id = 1, FirstName = "asadbek", LastName = "latipov" });
            //await targetWindow._productService.CreateAsync(new Product { CategoryId = 1, Name = "Gorilla", IncomePrice = 7000, SellingPrice = 8000 }, new User { Id = 1, FirstName = "asadbek", LastName = "latipov" });
            //await targetWindow._productService.CreateAsync(new Product { CategoryId = 1, Name = "Hydrolife", IncomePrice = 2000, SellingPrice = 3000 }, new User { Id = 1, FirstName = "asadbek", LastName = "latipov" });

            //await targetWindow._productService.CreateAsync(new Product { CategoryId = 2, Name = "ChocoPie", IncomePrice = 2000, SellingPrice = 3000 }, new User { Id = 1, FirstName = "asadbek", LastName = "latipov" });
            //await targetWindow._productService.CreateAsync(new Product { CategoryId = 2, Name = "Sneakers", IncomePrice = 4000, SellingPrice = 5000 }, new User { Id = 1, FirstName = "asadbek", LastName = "latipov" });
            //await targetWindow._productService.CreateAsync(new Product { CategoryId = 2, Name = "Alpen Gold", IncomePrice = 6000, SellingPrice = 7000 }, new User { Id = 1, FirstName = "asadbek", LastName = "latipov" });
            //await targetWindow._productService.CreateAsync(new Product { CategoryId = 2, Name = "Kinder", IncomePrice = 2000, SellingPrice = 3500 }, new User { Id = 1, FirstName = "asadbek", LastName = "latipov" });


            //await targetWindow._productService.CreateAsync(new Product { CategoryId = 4, Name = "Sabzi", IncomePrice = 1000, SellingPrice = 2000 }, new User { Id = 1, FirstName = "asadbek", LastName = "latipov" });
            //await targetWindow._productService.CreateAsync(new Product { CategoryId = 4, Name = "Kartoshka", IncomePrice = 2000, SellingPrice = 3500 }, new User { Id = 1, FirstName = "asadbek", LastName = "latipov" });
            //await targetWindow._productService.CreateAsync(new Product { CategoryId = 4, Name = "Karam", IncomePrice = 1000, SellingPrice = 2200 }, new User { Id = 1, FirstName = "asadbek", LastName = "latipov" });
            //await targetWindow._productService.CreateAsync(new Product { CategoryId = 4, Name = "Bodring", IncomePrice = 1000, SellingPrice = 3500 }, new User { Id = 1, FirstName = "asadbek", LastName = "latipov" });
            //await targetWindow._productService.CreateAsync(new Product { CategoryId = 4, Name = "Piyoz", IncomePrice = 1000, SellingPrice = 1300 }, new User { Id = 1, FirstName = "asadbek", LastName = "latipov" });


            //await targetWindow._productService.CreateAsync(new Product { CategoryId = 3, Name = "Olma", IncomePrice = 2000, SellingPrice = 2500 }, new User { Id = 1, FirstName = "asadbek", LastName = "latipov" });
            //await targetWindow._productService.CreateAsync(new Product { CategoryId = 3, Name = "Banan", IncomePrice = 17000, SellingPrice = 20000 }, new User { Id = 1, FirstName = "asadbek", LastName = "latipov" });
            //await targetWindow._productService.CreateAsync(new Product { CategoryId = 3, Name = "Uzum", IncomePrice = 8000, SellingPrice = 10000 }, new User { Id = 1, FirstName = "asadbek", LastName = "latipov" });
            //await targetWindow._productService.CreateAsync(new Product { CategoryId = 3, Name = "Shaftoli", IncomePrice = 12000, SellingPrice = 13000 }, new User { Id = 1, FirstName = "asadbek", LastName = "latipov" });
            //await targetWindow._productService.CreateAsync(new Product { CategoryId = 3, Name = "Qulupnay", IncomePrice = 15000, SellingPrice = 17000 }, new User { Id = 1, FirstName = "asadbek", LastName = "latipov" });
        }

        public async Task<BaseResponse<Category>> UpdateAsync(Category model, User user)
        {
            BaseResponse<Category> baseResponse = new BaseResponse<Category>();

            var entity = await _unitOfWork.Categories.GetAsync(obj => obj.Id == model.Id);
            if (entity is null)
            {
                baseResponse.Error = new ErrorModel(404, "Category not found");
                return baseResponse;
            }

            model.UpdatedAt= DateTime.Now;
            model.UpdatedUserId = user.Id;
            model.Status = Infrastructure.Enums.ItemState.Updated;

            var result = await _unitOfWork.Categories.UpdateAsync(model);
            await _unitOfWork.SaveChangesAsync();

            baseResponse.Data = result;
            return baseResponse;
        }

        public async Task<BaseResponse<Category>> GetAsync(Expression<Func<Category, bool>> expression)
        {
            BaseResponse<Category> baseResponse = new BaseResponse<Category>();

            var entity = await _unitOfWork.Categories.GetAsync(expression);
            if (entity is null)
            {
                baseResponse.Error = new ErrorModel(404, "Category not found");
                return baseResponse;
            }

            baseResponse.Data = entity;
            return baseResponse;
        }

        public async Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Category, bool>> expression)
        {
            BaseResponse<bool> baseResponse = new BaseResponse<bool>();
            var entity = await _unitOfWork.Categories.GetAsync(expression);

            if (entity is null)
            {
                baseResponse.Error = new ErrorModel(400, "Category not found");
                return baseResponse;
            }
            else
            {
                await _unitOfWork.Categories.DeleteAsync(expression);
            }

            await _unitOfWork.SaveChangesAsync();

            baseResponse.Data = true;
            return baseResponse;

        }

        public async Task<BaseResponse<IEnumerable<Category>>> GetAllAsync(Expression<Func<Category, bool>> expression = null)
        {
            List<Category> categories = new List<Category>();
            BaseResponse<IEnumerable<Category>> baseResponse = new BaseResponse<IEnumerable<Category>>();

            var entities = await _unitOfWork.Categories.GetAllAsync(expression);
            if (entities is null)
            {
                baseResponse.Error = new ErrorModel(400, "Categories not found");
                return baseResponse;
            }
            //categories.Add(new Category() { Id = 1, Name = "Ichimliklar", CategoryId = 1});
            //categories.Add(new Category() { Id = 2, Name = "Shirinliklar", CategoryId = 2 });
            //categories.Add(new Category() { Id = 3, Name = "Sabzavotlar" , CategoryId = 3 });
            //categories.Add(new Category() { Id = 4, Name = "Mevalar" , CategoryId = 4 });



            baseResponse.Data = entities.ToList();
            //baseResponse.Data = categories;


            return baseResponse;
        }

    }
}
