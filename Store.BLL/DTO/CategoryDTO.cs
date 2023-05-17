using Store.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BLL.DTO
{
    public class CategoryDTO : IBaseModel
    {
        public int Id { get; set; }
        public string? CategoryName { get; set; }
    }
}
