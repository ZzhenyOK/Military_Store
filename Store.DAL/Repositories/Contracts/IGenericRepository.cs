using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using Store.DAL.Models;

namespace Store.DAL.Repositories.Contracts
{
    public interface IGenericRepository<TModel> where TModel : class
    {
        void Add(TModel t);
        TModel Update(TModel t);
        void Delete(TModel entity);
        IQueryable<TModel> FindBy(Expression<Func<TModel, bool>> predicate);
        IQueryable<TModel> GetAll();
        TModel GetById(int id);
        void Save();
    }
}
