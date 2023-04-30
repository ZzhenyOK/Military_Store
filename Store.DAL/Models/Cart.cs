using Identity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DAL.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("FK_Product_123")]
        public int ProductId { get; set; }
        [ForeignKey("FK_User_12")]
        public int UserId { get; set; }

        //virtual properties
        public Product Product { get; set; }
        [NotMapped]
        public ApplicationUser ApplicationUser { get; set; }
    }
}
