using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.DAL.Models;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.EntityFrameworkCore;
using Store.BLL.Base;
using Store.DAL.DataContext;

namespace Store.BLL.Services
{
    public class CategoryService : EntityBaseRepository<Category>, ICategoryService
    {
        public CategoryService(DbmilitaryContext context) : base(context) { }
    }
}
