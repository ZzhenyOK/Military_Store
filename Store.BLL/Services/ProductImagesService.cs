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
        public void Add(ProductImagesDTO productImages)
        {
            ProductImages newProductImages = new ProductImages
            {
                Id = productImages.Id,
                ProductId = productImages.ProductId,
                Image = productImages.Image
            };
            _repository.Add(newProductImages);
            _repository.Save();
        }

        public void Delete(ProductImagesDTO entity)
        {
            ProductImages delProductImages = _repository.GetById(entity.Id);
            if (delProductImages != null)
            {
                _repository.Delete(delProductImages);
            }
            _repository.Save();
        }

        public ProductImagesDTO Get(int id)
        {
            ProductImages productImages = _repository.GetById(id);
            return new ProductImagesDTO
            {
                Id = productImages.Id,
                ProductId = productImages.ProductId,
                Image = productImages.Image
            };
        }

        public IEnumerable<ProductImagesDTO> GetAll()
        {
            return _repository.GetAll().Select(x => new ProductImagesDTO
            {
                Id = x.Id,
                ProductId = x.ProductId,
                Image = x.Image
            });
        }

        public void Save()
        {
            _repository.Save();
        }

        public void Update(ProductImagesDTO productImages)
        {
            ProductImages newProductImages = _repository.GetById(productImages.Id);
            if(newProductImages != null)
            {
                newProductImages.Id = productImages.Id;
                newProductImages.ProductId = productImages.ProductId;
                newProductImages.Image = productImages.Image;
            }
            _repository.Save();
        }
    }
}
