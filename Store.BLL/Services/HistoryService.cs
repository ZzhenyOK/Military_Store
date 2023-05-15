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

        public async Task AddAsync(HistoryDTO t)
        {
            History newHistory = new History()
            {
                Id = t.Id,
                ProductId = t.ProductId,
                UserId = t.UserId,
                Price = t.Price,
                PurchaseDate = t.PurchaceDate
            };
            await _repository.AddAsync(newHistory);
            await _repository.SaveAsync();
        }

        public async Task DeleteAsync(HistoryDTO entity)
        {
            History delHistory = await _repository.GetByIdAsync(entity.Id);
            if (delHistory != null)
            {
               await _repository.DeleteAsync(delHistory);
               await _repository.SaveAsync();
            }     
        }

        public async Task<IEnumerable<HistoryDTO>> GetAllAsync()
        {
            return (IEnumerable<HistoryDTO>)await _repository.GetAllAsync();
        }

        public async Task<HistoryDTO> GetByIdAsync(int id)
        {
            History history = await _repository.GetByIdAsync(id);
            if (history != null)
            {
                return new HistoryDTO
                {
                    Id = history.Id,
                    ProductId = history.ProductId,
                    UserId = history.UserId,
                    Price = history.Price,
                    PurchaceDate = history.PurchaseDate
                };
            }
            return null;
        }

        public async Task SaveAsync()
        {
            await _repository.SaveAsync();
        }

        public async Task<HistoryDTO> UpdateAsync(HistoryDTO model)
        {
            History newHistory = await _repository.GetByIdAsync(model.Id);
            if (newHistory != null)
            {
                newHistory.Id = model.Id;
                newHistory.ProductId = model.ProductId;
                newHistory.UserId = model.UserId;
                newHistory.Price = model.Price;
                newHistory.PurchaseDate = model.PurchaceDate;
            }
            await _repository.SaveAsync();
            return model;
        }
    }
}
