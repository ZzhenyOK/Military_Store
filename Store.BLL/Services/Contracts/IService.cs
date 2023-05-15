using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Store.DAL.Models;

namespace Store.BLL.Services.Contracts
{
    public interface IService<TModel> where TModel : class
    {
        Task AddAsync(TModel t);
        Task<TModel> UpdateAsync(TModel model);
        Task DeleteAsync(TModel entity);
        Task<IEnumerable<TModel>> GetAllAsync();
        Task<TModel> GetByIdAsync(int id);
        Task SaveAsync();
    }
}