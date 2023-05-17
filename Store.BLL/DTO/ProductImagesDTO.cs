using Store.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BLL.DTO
{
    public class ProductImagesDTO : IBaseModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public byte[] Image { get; set; }
    }
}
