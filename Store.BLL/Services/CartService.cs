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

        public void Add(CartDTO cart)
        {
            Cart newCart = new Cart()
            {
                Id = cart.Id,
                UserId = cart.UserId,
                ProductId = cart.ProductId,
            };
            _repository.Add(newCart);
            _repository.Save();
        }

        public void Delete(CartDTO cart)
        {
            Cart delCart = _repository.GetById(cart.Id);
            _repository.Delete(delCart);
            _repository.Save();
        }

        public CartDTO Get(int id)
        {
            Cart cart = _repository.GetById(id);
            CartDTO cartDTO = new CartDTO
            {
                Id = cart.Id,
                UserId = cart.UserId,
                ProductId= cart.ProductId
            };
            return cartDTO;
        }

        public IEnumerable<CartDTO> GetAll()
        {
            return _repository.GetAll()
                .Select(x => new CartDTO
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    ProductId= x.ProductId
                });
        }

        public void Save()
        {
            _repository.Save();
        }

        public void Update(CartDTO cart)
        {
            Cart newCart = _repository.GetById(cart.Id);
            if (newCart != null)
            {
                newCart.Id = cart.Id;
                newCart.UserId = cart.UserId;
                newCart.ProductId = cart.ProductId;
            }
            _repository.Save();
        }
    }
}
