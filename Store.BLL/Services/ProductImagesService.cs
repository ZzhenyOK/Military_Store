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
    public class ProductImagesService : IService<ProductImagesDTO>
    {
        protected IGenericRepository<ProductImages> _repository;

        public async Task AddAsync(ProductImagesDTO t)
        {
            ProductImages newProductImages = new ProductImages
            {
                Id = t.Id,
                ProductId = t.ProductId,
                Image = t.Image
            };
            await _repository.AddAsync(newProductImages);
            await _repository.SaveAsync();
        }

        public async Task DeleteAsync(ProductImagesDTO entity)
        {
            ProductImages delProductImages = await _repository.GetByIdAsync(entity.Id);
            if (delProductImages != null)
            {
                await _repository.DeleteAsync(delProductImages); 
                await _repository.SaveAsync();
            }
        }

        public async Task<IEnumerable<ProductImagesDTO>> GetAllAsync()
        {
            return (IEnumerable<ProductImagesDTO>) await _repository.GetAllAsync();
        }

        public async Task<ProductImagesDTO> GetByIdAsync(int id)
        {
            ProductImages productImages = await _repository.GetByIdAsync(id);
            if (productImages != null)
            {
                return new ProductImagesDTO
                {
                    Id = productImages.Id,
                    ProductId = productImages.ProductId,
                    Image = productImages.Image
                };
            }
            return null;
        }

        public async Task SaveAsync()
        {
            await _repository.SaveAsync();
        }

        public async Task<ProductImagesDTO> UpdateAsync(ProductImagesDTO model)
        {
            ProductImages newProductImages = await _repository.GetByIdAsync(model.Id);
            if (newProductImages != null)
            {
                newProductImages.Id = model.Id;
                newProductImages.ProductId = model.ProductId;
                newProductImages.Image = model.Image;
            }
            await _repository.SaveAsync();
            return model;
        }
    }
}
