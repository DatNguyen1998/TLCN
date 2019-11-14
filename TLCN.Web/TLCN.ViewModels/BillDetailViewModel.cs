using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TLCN.Common.Attributes;
using TLCN.Models;
namespace TLCN.ViewModels
{
    [Repository(Action = ActionType.All, Name = "BillDetailViewModel", RepositoryType = typeof(DetailBill))]
    public class BillDetailViewModel
    {
        [StringLength(50)]
        public string Code { get; set; }
        public Guid ProductId { get; set; } // sản phẩm
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public Guid BillId { get; set; }    // hóa đơn
        public string BillCode { get; set; }
        public int Amount { get; set; } // số lượng
        public double PriceTotal { get; set; } //giá = số lượng x giá của sản phẩm
    }
}
