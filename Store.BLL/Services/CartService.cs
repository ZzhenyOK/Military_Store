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
    public class CartService : IService<CartDTO>
    {
        protected IGenericRepository<Cart> _repository;

        public CartService(IGenericRepository<Cart> repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(CartDTO t)
        {
            Cart newCart = new Cart()
            {
                Id = t.Id,
                UserId = t.UserId,
                ProductId = t.ProductId,
            };
            await _repository.AddAsync(newCart);
            await _repository.SaveAsync();
        }

        public async Task DeleteAsync(CartDTO entity)
        {
            Cart delCart = await _repository.GetByIdAsync(entity.Id);
            if (delCart != null)
            {
                await _repository.DeleteAsync(delCart);
                await _repository.SaveAsync();
            }
        }

        //public IEnumerable<CartDTO> GetAll()
        //{
        //    return _repository.GetAll()
        //        .Select(x => new CartDTO
        //        {
        //            Id = x.Id,
        //            UserId = x.UserId,
        //            ProductId= x.ProductId
        //        });
        //}

        public async Task<IEnumerable<CartDTO>> GetAllAsync()
        {
            return (IEnumerable<CartDTO>)await _repository.GetAllAsync();
        }

        public async Task<CartDTO> GetByIdAsync(int id)
        {
            Cart cart = await _repository.GetByIdAsync(id);
            if (cart != null)
            {
                CartDTO cartDTO = new CartDTO
                {
                    Id = cart.Id,
                    UserId = cart.UserId,
                    ProductId = cart.ProductId
                };
                return cartDTO;
            }
            return null;
        }

        public async Task SaveAsync()
        {
            await _repository.SaveAsync();
        }

        //public void Update(CartDTO cart)
        //{
        //    Cart newCart = _repository.GetById(cart.Id);
        //    if (newCart != null)
        //    {
        //        newCart.Id = cart.Id;
        //        newCart.UserId = cart.UserId;
        //        newCart.ProductId = cart.ProductId;
        //    }
        //    _repository.Save();
        //}

        public async Task<CartDTO> UpdateAsync(CartDTO model)
        {
            Cart newCart = await _repository.GetByIdAsync(model.Id);
            if (newCart != null)
            {
                newCart.Id = model.Id;
                newCart.UserId = model.UserId;
                newCart.ProductId = model.ProductId;
            }
            await _repository.SaveAsync();
            return model;
        }
    }
}
