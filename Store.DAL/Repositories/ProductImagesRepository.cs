using Store.DAL.DataContext;
using Store.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DAL.Repositories
{
    public class ProductImagesRepository : GenericRepository<ProductImages>
    {
        public ProductImagesRepository(DbmilitaryContext dbmilitary) : base(dbmilitary)
        {
        }
    }
}
