using Microsoft.AspNetCore.Http;
using Store.BLL.Base;
using Store.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BLL.Services
{
    public interface IProductService : IEntityBaseRepository<Product>
    {
        Task AddImagesAsync(ProductImages pimage, List<IFormFile> Images);
    }
}
