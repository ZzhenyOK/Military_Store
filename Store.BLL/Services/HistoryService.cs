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
    public class HistoryService : IService<HistoryDTO>
    {
        protected IGenericRepository<History> _repository;
        public void Add(HistoryDTO history)
        {
            History newHistory = new History()
            {
                Id = history.Id,
                ProductId = history.ProductId,
                UserId = history.UserId,
                Price = history.Price,
                PurchaseDate = history.PurchaceDate
            };
            _repository.Add(newHistory);
            _repository.Save();
        }

        public void Delete(HistoryDTO entity)
        {
            History delHistory = _repository.GetById(entity.Id);
            if (delHistory != null)
            {
                _repository.Delete(delHistory);
            }
            _repository.Save();
        }

        public HistoryDTO Get(int id)
        {
            History history = _repository.GetById(id);
            return new HistoryDTO
            {
                Id = history.Id,
                ProductId = history.ProductId,
                UserId = history.UserId,
                Price = history.Price,
                PurchaceDate = history.PurchaseDate
            };
        }

        public IEnumerable<HistoryDTO> GetAll()
        {
            return _repository.GetAll().Select(x => new HistoryDTO
            {
                Id = x.Id, 
                ProductId = x.ProductId,
                UserId = x.UserId,
                Price = x.Price,
                PurchaceDate = x.PurchaseDate
            });
        }

        public void Save()
        {
            _repository.Save();
        }

        public void Update(HistoryDTO history)
        {
            History newHistory = _repository.GetById(history.Id);
            if (newHistory != null)
            {
                newHistory.Id = history.Id;
                newHistory.ProductId = history.ProductId;
                newHistory.UserId = history.UserId;
                newHistory.Price = history.Price;
                newHistory.PurchaseDate = history.PurchaceDate;
            }
            _repository.Save();
        }
    }
}
