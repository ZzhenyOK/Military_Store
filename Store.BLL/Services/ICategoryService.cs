using Store.BLL.Base;
using Store.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BLL.Services
{
    public interface ICategoryService : IEntityBaseRepository<CategoryDTO>
    {
    }
}
