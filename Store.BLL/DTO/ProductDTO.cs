using Store.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BLL.DTO
{
    public class ProductDTO : IBaseModel
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Rate { get; set; }
        public string Description { get; set; }

    }
}
