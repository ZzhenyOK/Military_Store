using Store.BLL.DTO;
using Store.BLL.Services.Contracts;
using Store.DAL.Models;
using Store.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BLL.Services
{
    public class ProductService : IService<ProductDTO>
    {
        protected IGenericRepository<Product> _repository;

        public async Task AddAsync(ProductDTO t)
        {
            Product newProduct = new Product()
            {
                Id = t.Id,
                CategoryId = t.CategoryId,
                Title = t.Title,
                Price = t.Price,
                Rate = t.Rate,
                Desctiption = t.Description
            };
            await _repository.AddAsync(newProduct);
            await _repository.SaveAsync();
        }

        public async Task DeleteAsync(ProductDTO entity)
        {
            Product delProduct = await _repository.GetByIdAsync(entity.Id);
            if (delProduct != null)
            {
                await _repository.DeleteAsync(delProduct);
            }
            await _repository.SaveAsync();
        }

        public async Task<IEnumerable<ProductDTO>> GetAllAsync()
        {
            return (IEnumerable<ProductDTO>)await _repository.GetAllAsync();

        }

        public async Task<ProductDTO> GetByIdAsync(int id)
        {
            Product product = await _repository.GetByIdAsync(id);
            if (product != null)
            {
                return new ProductDTO
                {
                    Id = product.Id,
                    CategoryId = product.CategoryId,
                    Title = product.Title,
                    Price = product.Price,
                    Rate = product.Rate,
                    Description = product.Desctiption

                };
            }
            return null;
        }

        public async Task SaveAsync()
        {
            await _repository.SaveAsync();
        }

        public async Task<ProductDTO> UpdateAsync(ProductDTO model)
        {
            Product newProduct = await _repository.GetByIdAsync(model.Id);
            if (newProduct != null)
            {
                newProduct.Id = model.Id;
                newProduct.CategoryId = model.CategoryId;
                newProduct.Title = model.Title;
                newProduct.Price = model.Price;
                newProduct.Rate = model.Rate;
                newProduct.Desctiption = model.Description;
            }
            await _repository.SaveAsync();
            return model;
        }
    }
}
