using Store.DAL.DataContext;
using Store.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Store.DAL.Repositories
{
    public class GenericRepository<TModel> : IGenericRepository<TModel> where TModel : class
    {
        private readonly DbmilitaryContext _dbcontext;
        public GenericRepository(DbmilitaryContext dbmilitary)
        {
            _dbcontext= dbmilitary;
        }

        public void Add(TModel t)
        {
            _dbcontext.Set<TModel>().Add(t);
            _dbcontext.SaveChanges();
        }

        public void Delete(TModel entity)
        {
            _dbcontext.Set<TModel>().Remove(entity);
            _dbcontext.SaveChanges();
        }

        public IQueryable<TModel> FindBy(Expression<Func<TModel, bool>> predicate)
        {
            IQueryable<TModel> guery = _dbcontext.Set<TModel>().Where(predicate);
            return guery;
        }

        public TModel GetById(int id)
        {
            return _dbcontext.Set<TModel>().Find(id);
        }

        public IQueryable<TModel> GetAll()
        {
            return _dbcontext.Set<TModel>();
        }

        public void Save()
        {
            _dbcontext.SaveChanges();
        }

        public TModel Update(TModel t)
        {
            if (t == null)
                return null;
            TModel exist = _dbcontext.Set<TModel>().Find(t);
            if (exist != null)
            {
                _dbcontext.Entry(exist).CurrentValues.SetValues(t);
                _dbcontext.SaveChanges();
            }
            return exist;
        }
    }
}
