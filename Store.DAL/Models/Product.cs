using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Store.DAL.Models
{
    public partial class Product : IBaseModel
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("FK_Category_1")]
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Rate { get; set; }
        public string Desctiption { get; set; }

        //virtual properties
        [NotMapped]
        public Category Category { get; set; }
    }
}
