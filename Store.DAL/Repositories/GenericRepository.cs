using Store.DAL.DataContext;
using Store.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Store.DAL.Models;

namespace Store.DAL.Repositories
{
    public class GenericRepository<TModel> : IGenericRepository<TModel> where TModel : BaseModel
    {
        private readonly DbmilitaryContext _context;
        DbSet<TModel> entities;
        public GenericRepository(DbmilitaryContext dbmilitary)
        {
            _context= dbmilitary;
            entities = _context.Set<TModel>();
        }

        public async Task<TModel> AddAsync(TModel model)
        {
            if(model == null) return null;
            await entities.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }
        public async Task<TModel> UpdateAsync(int id, TModel model)
        {
            if(model == null) return null;
            TModel item = await entities.FindAsync(id);
            if (item == null) return null;
            item = model;
            item.Id = id;
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return item;
        }
        public async Task DeleteAsync(TModel entity)
        {
            TModel item = await entities.FindAsync(entity);
            if (item == null) return;
            entities.Remove(item);
            await _context.SaveChangesAsync();
        }
        public async Task<List<TModel>> GetAllAsync()
        {
            return await entities.ToListAsync();
        }
        public async Task<TModel> GetByIdAsync(int id)
        {
            return await entities.FindAsync(id); 
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
