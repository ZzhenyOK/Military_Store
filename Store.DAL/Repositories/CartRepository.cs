using Store.DAL.DataContext;
using Store.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DAL.Repositories
{
    public class CartRepository : GenericRepository<Cart>
    {
        public CartRepository(DbmilitaryContext dbmilitary) : base(dbmilitary)
        {
        }
    }
}
