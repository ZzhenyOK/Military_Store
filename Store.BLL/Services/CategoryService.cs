using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Store.DAL.Models;
using Store.BLL.Services.Contracts;
using Store.DAL.Repositories.Contracts;
using Store.BLL.DTO;

namespace Store.BLL.Services
{
    public class CategoryService : IService<CategoryDTO>
    {
        protected IGenericRepository<Category> _repository;

        public CategoryService(IGenericRepository<Category> repository)
        {
            _repository= repository;
        }

        public void Add(CategoryDTO category)
        {
            Category newCategory = new Category()
            {
                Id = category.Id,
                CategoryName = category.CategoryName
            };
            _repository.Add(newCategory);
            _repository.Save();
        }

        public void Delete(CategoryDTO category)
        {
            Category delCategory = _repository.GetById(category.Id);
            _repository.Delete(delCategory);
            _repository.Save();
        }

        public CategoryDTO Get(int id)
        {
            Category category = _repository.GetById(id);
            CategoryDTO categoryDTO = new CategoryDTO
            {
                Id = category.Id,
                CategoryName = category.CategoryName
            };
            return categoryDTO;
        }

        public IEnumerable<CategoryDTO> GetAll()
        {
            return _repository.GetAll()
                .Select(x => new CategoryDTO
                {
                    Id = x.Id,
                    CategoryName = x.CategoryName
                });
        }

        public void Save()
        {
            _repository.Save();
        }

        public void Update(CategoryDTO category)
        {
            Category newCategory = _repository.GetById(category.Id);
            if (newCategory != null)
            {
                newCategory.Id = category.Id;
                newCategory.CategoryName = category.CategoryName;
            }
            _repository.Save();
        }
    }
}
