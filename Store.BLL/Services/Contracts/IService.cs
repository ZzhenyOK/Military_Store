using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Store.DAL.Models;

namespace Store.BLL.Services.Contracts
{
    public interface IService<T> where T : class
    {
        void Add(T t);
        void Update(T t);
        void Delete(T entity);
        IEnumerable<T> GetAll();
        T Get(int id);
        void Save();
    }
}