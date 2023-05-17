using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DAL.Models
{
    public class ProductImages : IBaseModel
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("FK_Product_1")]
        public int ProductId { get; set; }
        public byte[] Image { get; set; }

        //virtual properties
        [NotMapped]
        public Product Product { get; set; }
        
    }
}
