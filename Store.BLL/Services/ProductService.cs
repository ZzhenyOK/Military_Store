using Microsoft.AspNetCore.Http;
using Store.BLL.Base;
using Store.DAL.DataContext;
using Store.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BLL.Services
{
    public class ProductService : EntityBaseRepository<Product>, IProductService
    {
        private readonly DbmilitaryContext _context;
        public ProductService(DbmilitaryContext context) : base(context) 
        { 
            _context = context;
        }

        public async Task AddImagesAsync(ProductImages pimage, List<IFormFile> Image)
        {
            List<ProductImages> list = new List<ProductImages>();
            foreach (var item in Image)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    item.CopyTo(ms);
                    ms.Seek(0, SeekOrigin.Begin);
                    ProductImages pi = new ProductImages { ProductId = pimage.ProductId, Image = ms.ToArray() };
                    list.Add(pi);
                }
            }
            await _context.ProductImages.AddRangeAsync(list);
            await _context.SaveChangesAsync();
        }
    }
}
