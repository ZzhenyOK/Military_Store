using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using Store.DAL.Models;

namespace Store.DAL.Repositories.Contracts
{
    public interface IGenericRepository<TModel> where TModel : BaseModel
    {
        Task<TModel> AddAsync(TModel t);
        Task<TModel> UpdateAsync(int id, TModel model);
        Task DeleteAsync(TModel entity);
        Task<List<TModel>> GetAllAsync();
        Task<TModel> GetByIdAsync(int id);
        Task SaveAsync();
    }
}
