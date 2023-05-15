using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Store.DAL.Models;
using Store.BLL.Services.Contracts;
using Store.DAL.Repositories.Contracts;
using Store.BLL.DTO;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.EntityFrameworkCore;

namespace Store.BLL.Services
{
    public class CategoryService : IService<CategoryDTO>
    {
        protected IGenericRepository<Category> _repository;

        public CategoryService(IGenericRepository<Category> repository)
        {
            _repository= repository;
        }

        public async Task AddAsync(CategoryDTO t)
        {
            Category newCategory = new Category()
            {
                Id = t.Id,
                CategoryName = t.CategoryName
            };
            await _repository.AddAsync(newCategory);
            await _repository.SaveAsync();
        }

        public async Task DeleteAsync(CategoryDTO entity)
        {
            Category delCategory = await _repository.GetByIdAsync(entity.Id);
            if (delCategory != null)
            {
                await _repository.DeleteAsync(delCategory);
                await _repository.SaveAsync();
            }
        }

        //public IEnumerable<CategoryDTO> GetAll()
        //{
        //    return _repository.GetAll()
        //        .Select(x => new CategoryDTO
        //        {
        //            Id = x.Id,
        //            CategoryName = x.CategoryName
        //        });
        //}

        public async Task<IEnumerable<CategoryDTO>> GetAllAsync()
        {
            return (IEnumerable<CategoryDTO>)await _repository.GetAllAsync();
        }

        public async Task<CategoryDTO> GetByIdAsync(int id)
        {
            Category category = await _repository.GetByIdAsync(id);
            if (category != null)
            {
                CategoryDTO categoryDTO = new CategoryDTO
                {
                    Id = category.Id,
                    CategoryName = category.CategoryName
                };
                return categoryDTO;
            }
            return null;
        }

        public async Task SaveAsync()
        {
            await _repository.SaveAsync();
        }

        //public void Update(CategoryDTO category)
        //{
        //    Category newCategory = _repository.GetById(category.Id);
        //    if (newCategory != null)
        //    {
        //        newCategory.Id = category.Id;
        //        newCategory.CategoryName = category.CategoryName;
        //    }
        //    _repository.Save();
        //}

        public async Task<CategoryDTO> UpdateAsync(CategoryDTO model)
        {
            Category newCategory = await _repository.GetByIdAsync(model.Id);
            if (newCategory != null)
            {
                newCategory.Id = model.Id;
                newCategory.CategoryName = model.CategoryName;
            }
            await _repository.SaveAsync();
            return model;
        }
    }
}
