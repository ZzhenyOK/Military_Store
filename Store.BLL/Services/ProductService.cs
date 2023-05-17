using Store.BLL.Base;
using Store.BLL.DTO;
using Store.DAL.DataContext;
using Store.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BLL.Services
{
    public class ProductService : EntityBaseRepository<ProductDTO>, IProductService
    {
        public ProductService(DbmilitaryContext context) : base(context) { }
    }
}
