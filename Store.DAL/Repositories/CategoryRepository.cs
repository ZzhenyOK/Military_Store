using Store.DAL.DataContext;
using Store.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DAL.Repositories
{
    public class CategoryRepository : GenericRepository<Category>
    {
        public CategoryRepository(DbmilitaryContext dbmilitary) : base(dbmilitary)
        {
        }
    }
}
