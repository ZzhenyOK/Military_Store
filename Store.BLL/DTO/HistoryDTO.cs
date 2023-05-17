using Store.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BLL.DTO
{
    public class HistoryDTO : IBaseModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public decimal Price { get; set; }
        public DateTime PurchaceDate { get; set; }
    }
}
