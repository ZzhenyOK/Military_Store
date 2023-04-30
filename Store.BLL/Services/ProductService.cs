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
        public void Add(ProductDTO product)
        {
            Product newProduct = new Product()
            {
                Id = product.Id,
                CategoryId = product.CategoryId,
                Title = product.Title,
                Price = product.Price,
                Rate = product.Rate,
                Desctiption = product.Description
            };
            _repository.Add(newProduct);
            _repository.Save();
        }

        public void Delete(ProductDTO entity)
        {
            Product delProduct = _repository.GetById(entity.Id);
            if (delProduct != null)
            {
                _repository.Delete(delProduct);
            }
            _repository.Save();
        }

        public ProductDTO Get(int id)
        {
            Product product = _repository.GetById(id);
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

        public IEnumerable<ProductDTO> GetAll()
        {
            return _repository.GetAll().Select(x => new ProductDTO
            {
                Id = x.Id,
                CategoryId = x.CategoryId,
                Title = x.Title,
                Price = x.Price,
                Rate = x.Rate,
                Description = x.Desctiption
            });
        }

        public void Save()
        {
            _repository.Save();
        }

        public void Update(ProductDTO product)
        {
            Product newProduct = _repository.GetById(product.Id);
            if (newProduct != null)
            {
                newProduct.Id = product.Id;
                newProduct.CategoryId = product.CategoryId;
                newProduct.Title = product.Title;
                newProduct.Price = product.Price;
                newProduct.Rate = product.Rate;
                newProduct.Desctiption = product.Description;
            }
            _repository.Save();
        }
    }
}
